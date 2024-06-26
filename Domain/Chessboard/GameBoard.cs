﻿using Domain.Chessboard.Configurations;
using Domain.Chessboard.Errors;
using Domain.Chessboard.GameStates;
using Domain.Chessboard.PieceMoves;
using Domain.Chessboard.Pieces;
using Domain.Shared;
using Extension;
using FluentResults;

namespace Domain.Chessboard;

public class GameBoard : Board
{
    private readonly BoardSize _boardSize;
    private readonly GameState _gameState;
    private readonly PieceFactory _pieceFactory;
    private readonly PieceMoveFactory _pieceMoveFactory;
    private readonly Square[,] _squares;
    private readonly Participants _participants;

    public GameBoard(string id, Configuration configuration, IEnumerable<Participant> participants)
    {
        Id = id;
        _participants = new Participants(participants);
        _boardSize = configuration.BoardSize;
        _pieceMoveFactory = configuration.MoveFactory;
        _pieceFactory = configuration.PieceFactory;
        _gameState = configuration.GameState;
        _squares = new Square[_boardSize.Rows, _boardSize.Columns];
        
        for (var row = 0; row < _boardSize.Rows; row++)
        {
            for (var column = 0; column < _boardSize.Columns; column++)
            {
                _squares[row, column] = Square.FromCoordinates(new Position(row, column));
            }
        }
        
        foreach (var (piece, position) in configuration.PiecesPositions)
        {
            if (!position.IsWithinBoard(_boardSize))
            {
                //TODO: Catch an error and throw it in exception?
                throw new NotImplementedException();
            }
            
            var square = _squares[position.Row, position.Column];
            square.Move(piece);
        }
    }

    public string Id { get; }
    public Participants Participants => _participants;
    public BoardSnapshot Snapshot => GenerateSnapshot();
    public GameStateSnapshot GameState => _gameState.Snapshot;

    public Result<IEnumerable<PossibleMove>> PossibleMoves(Player player, Position source)
    {
        if (!source.IsWithinBoard(_boardSize))
        {
            return Result.Fail(new PositionOutOfBoard(source));
        }

        var square = _squares[source.Row, source.Column];
        if (!square.IsOccupied)
        {
            return Result.Fail(new EmptySquare(source));
        }

        var piece = square.Piece;
        var participant = _participants.For(player);
        if (participant is null)
        {
            return Result.Fail(new PlayerDoesNotParticipate(player));
        }
        
        if (!participant.CanMove(piece))
        {
            return Result.Fail(new PieceBelongsToTheOtherPlayer());
        }
        
        var pieceMove = _pieceMoveFactory.For(piece);
        var possibleMoves = pieceMove.PossibleMoves(square.Position, Snapshot);
        return Result.Ok(possibleMoves);
    }

    public Result Move(Player player, Position source, Position target)
    {
        if (!source.IsWithinBoard(_boardSize))
        {
            return Result.Fail(new PositionOutOfBoard(source));
        }

        if (!target.IsWithinBoard(_boardSize))
        {
            return Result.Fail(new PositionOutOfBoard(target));
        }

        var square = _squares[source.Row, source.Column];
        if (!square.IsOccupied)
        {
            return Result.Fail(new EmptySquare(source));
        }

        var piece = square.Piece;
        var participant = _participants.For(player);
        if (participant is null)
        {
            return Result.Fail(new PlayerDoesNotParticipate(player));
        }
        
        if (!participant.CanMove(piece))
        {
            return Result.Fail(new PieceBelongsToTheOtherPlayer(source, target));
        }
        
        if (!_gameState.IsMoveAllowed(piece))
        {
            return Result.Fail(new InvalidMoveOrder(_gameState.Snapshot.CurrentPlayer));
        }

        // It may need to be changed later. It's not a most effective way to do it.
        // Maybe that list could be generated in advance after each move?
        // At least there are tests for it.
        var movesForPlayer = FlatListOfPossibleMovesForPlayer(participant);
        // It's done twice. Maybe it could be extracted from the list above in the future?
        var pieceMove = _pieceMoveFactory.For(piece);
        var possibleMoves = pieceMove.PossibleMoves(square.Position, Snapshot);
        var move = possibleMoves.FirstOrDefault(x => x.To == target);

        if (move is null)
        {
            return Result.Fail(new MoveNotAllowed());
        }

        if (!movesForPlayer.Any(x => x.From == source && x.To == move.To))
        {
            return Result.Fail(new UnderperformingCaptureError(source, movesForPlayer.Select(x => x.From)));
        }

        foreach (var affectedSquarePosition in move.AffectedSquares)
        {
            var affectedSquare = _squares[affectedSquarePosition.Row, affectedSquarePosition.Column];
            if (affectedSquare.IsOccupied) affectedSquare.RemovePiece();
        }

        var newSquare = _squares[target.Row, target.Column];

        if (pieceMove.UpgradeRequired(target))
        {
            var upgradedPiece = _pieceFactory.ReplacementFor(piece);
            square.RemovePiece();
            newSquare.Move(upgradedPiece);
        }
        else
        {
            square.RemovePiece();
            newSquare.Move(piece);
        }

        _gameState.RegisterMove(piece, source, target);

        return Result.Ok();
    }

    private List<(Position From, Position To)> FlatListOfPossibleMovesForPlayer(Participant participant)
    {
        // Whole concept may need to be changed later. It's just a quick solution to make it work.
        // It's covered by tests so it's safe to refactor it later.
        var tmp = new List<(Position From, PossibleMove Move)>();
        foreach (var s in _squares.Flatten().Where(x => x.IsOccupied && participant.CanMove(x.Piece)))
        {
            if (s.IsOccupied)
            {
                var p = s.Piece;
                var pm = _pieceMoveFactory.For(p);
                var pms = pm.PossibleMoves(s.Position, Snapshot);
                tmp.AddRange(pms.Select(x => (s.Position, x)));
            }
        }
        
        var maxCapturedPieces = tmp.Max(x => x.Move.CapturedPieces);
        var availableMoves = tmp
            .Where(x => x.Move.CapturedPieces == maxCapturedPieces)
            .Select(x => (x.From, x.Move.To))
            .ToList();
        
        return availableMoves;
    }

    private BoardSnapshot GenerateSnapshot()
    {
        return new BoardSnapshot(_boardSize, _gameState.Snapshot, _squares.Transform(s => s.Snapshot()));
    }
}