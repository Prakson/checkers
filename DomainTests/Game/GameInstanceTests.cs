﻿using Domain.Chessboard.Pieces;
using Domain.Chessboard.Pieces.Classic;
using Domain.Game;
using Domain.Game.Errors;

namespace DomainTests.Game;

public class GameInstanceTests
{
    public static IEnumerable<Piece> WhitePieces
    {
        get
        {
            yield return new Man("ID", Color.White);
            yield return new King("ID", Color.White);
        }
    }

    public static IEnumerable<Piece> BlackPieces
    {
        get
        {
            yield return new Man("ID", Color.Black);
            yield return new King("ID", Color.Black);
        }
    }

    [Test]
    public void NewGame()
    {
        var game = new GameInstance("ID", "BID");

        Assert.That(game.Id, Is.EqualTo("ID"));
        Assert.That(game.Participants, Is.Empty);
    }

    [Test]
    public void NoParticipantsReturnsNull()
    {
        var game = new GameInstance("ID", "BID");

        Assert.That(game.Get(new TestPlayer("123")), Is.Null);
    }

    [Test]
    public void FirstPlayerIsWhitePlayer()
    {
        var game = new GameInstance("ID", "BID");
        var player = new TestPlayer("1");

        var result = game.Join(player);

        var participant = game.Get(player);

        Assert.That(result.IsSuccess);
        Assert.That(participant, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(participant!.Color, Is.EqualTo(Color.White));
            Assert.That(participant!.Id, Is.EqualTo("1"));
        });
    }

    [Test]
    public void SecondPlayerIsBlackPlayer()
    {
        var game = new GameInstance("ID", "BID");
        var white = new TestPlayer("W");
        var black = new TestPlayer("B");

        var whiteJoinResult = game.Join(white);
        var blackJoinResult = game.Join(black);

        var whiteParticipant = game.Get(white);
        var blackParticipant = game.Get(black);

        Assert.That(whiteJoinResult.IsSuccess);
        Assert.That(blackJoinResult.IsSuccess);
        Assert.That(whiteParticipant, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(whiteParticipant!.Color, Is.EqualTo(Color.White));
            Assert.That(whiteParticipant!.Id, Is.EqualTo("W"));
        });

        Assert.That(blackParticipant, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(blackParticipant!.Color, Is.EqualTo(Color.Black));
            Assert.That(blackParticipant!.Id, Is.EqualTo("B"));
        });
    }

    [Test]
    public void OnlyTwoPlayersCanJoinTheGame()
    {
        var game = new GameInstance("ID", "BID");

        var white = new TestPlayer("W");
        var black = new TestPlayer("B");
        var undefined = new TestPlayer("U");

        var whiteJoinResult = game.Join(white);
        var blackJoinResult = game.Join(black);
        var undefinedJoinResult = game.Join(undefined);

        Assert.That(whiteJoinResult.IsSuccess);
        Assert.That(blackJoinResult.IsSuccess);
        Assert.That(undefinedJoinResult.HasError<GameQuotaReached>());
    }

    [Test]
    public void GameWithoutPlayersNooneParticipates()
    {
        var game = new GameInstance("ID", "BID");

        var white = new TestPlayer("W");
        var black = new TestPlayer("B");

        var whiteParticipation = game.Participation(white);
        var blackParticipation = game.Participation(black);

        Assert.That(whiteParticipation.DoesParticipate, Is.False);
        Assert.Throws<InvalidOperationException>(() => _ = whiteParticipation.Participant);
        Assert.That(blackParticipation.DoesParticipate, Is.False);
        Assert.Throws<InvalidOperationException>(() => _ = blackParticipation.Participant);
    }

    [Test]
    public void FirstPlayerCannotJoinTwice()
    {
        var game = new GameInstance("ID", "BID");

        var white = new TestPlayer("W");

        var whiteJoinResult1 = game.Join(white);
        var whiteJoinResult2 = game.Join(white);

        Assert.That(whiteJoinResult1.IsSuccess);
        Assert.That(whiteJoinResult2.HasError<PlayerAlreadyJoined>());
    }

    [Test]
    public void WhitePlayerParticipatesInGame()
    {
        var game = new GameInstance("ID", "BID");

        var white = new TestPlayer("W");
        var black = new TestPlayer("B");

        var whiteJoinResult = game.Join(white);
        var blackJoinResult = game.Join(black);

        var participation = game.Participation(black);

        Assert.That(whiteJoinResult.IsSuccess);
        Assert.That(blackJoinResult.IsSuccess);
        Assert.That(participation.DoesParticipate, Is.True);
        Assert.That(participation.Participant.Id, Is.EqualTo("B"));
        Assert.That(participation.Participant.Color, Is.EqualTo(Color.Black));
    }

    [Test]
    public void BlackPlayerParticipatesInGame()
    {
        var game = new GameInstance("ID", "BID");

        var white = new TestPlayer("W");
        var whiteJoinResult = game.Join(white);

        var participation = game.Participation(white);

        Assert.That(whiteJoinResult.IsSuccess);
        Assert.That(participation.Participant.Id, Is.EqualTo("W"));
        Assert.That(participation.Participant.Color, Is.EqualTo(Color.White));
    }

    [Test]
    [TestCaseSource(nameof(WhitePieces))]
    public void WhitePlayerCanMoveWhitePieces(Piece piece)
    {
        var game = new GameInstance("ID", "BID");

        var white = new TestPlayer("W");

        game.Join(white);

        var participant = game.Get(white);

        Assert.That(participant, Is.Not.Null);
        Assert.That(participant!.CanMove(piece), Is.True);
    }

    [Test]
    [TestCaseSource(nameof(BlackPieces))]
    public void WhitePlayerCannotMoveBlackPieces(Piece piece)
    {
        var game = new GameInstance("ID", "BID");

        var white = new TestPlayer("W");

        game.Join(white);

        var participant = game.Get(white);

        Assert.That(participant, Is.Not.Null);
        Assert.That(participant!.CanMove(piece), Is.False);
    }

    [Test]
    [TestCaseSource(nameof(BlackPieces))]
    public void BlackPlayerCanMoveBlackPieces(Piece piece)
    {
        var game = new GameInstance("ID", "BID");
        var black = new TestPlayer("B");

        game.Join(new TestPlayer("W"));
        game.Join(black);

        var participant = game.Get(black);

        Assert.That(participant, Is.Not.Null);
        Assert.That(participant!.CanMove(piece), Is.True);
    }

    [Test]
    [TestCaseSource(nameof(WhitePieces))]
    public void BlackPlayerCannotMoveWhitePieces(Piece piece)
    {
        var game = new GameInstance("ID", "BID");
        var black = new TestPlayer("B");

        game.Join(new TestPlayer("W"));
        game.Join(black);

        var participant = game.Get(black);

        Assert.That(participant, Is.Not.Null);
        Assert.That(participant!.CanMove(piece), Is.False);
    }

    private record TestPlayer(string Id) : Player;
}