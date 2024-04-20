﻿using Domain.Chessboard;
using Domain.Chessboard.Configurations.Classic;
using Domain.Chessboard.Pieces;
using Domain.Chessboard.Pieces.Classic;
using Domain.Shared;
using DomainTests.Chessboard.TestData;

namespace DomainTests.Chessboard.PieceMoves.Classic.TestData.Dto;

public static class PieceCaptureTestCaseExtensions
{
    public static Board BuildBoard(this PieceCaptureTestCase testCase, Color player, Color opponent, Color blocking)
    {
        // var piece1 = (Piece) new Man("ID", Color.Black);
        // var pieces = new List<(Piece Piece, Position Position)> {(piece1, testCase.SourcePiece)};
        // var blockingPieces = testCase.BlockingPieces
        //     .Select(x => ((Piece) new Man("ID", Color.Black), x));
        //
        // var configuration = ClassicConfiguration.FromSnapshot(pieces.Union(blockingPieces));
        
        
        var playerPiece = (Piece) new Man("P", player);
        var opponentPiece = (Piece) new Man("O", opponent);
        var blockingPiece = (Piece) new Man("B", blocking);
        
        var piece = new List<(Piece Piece, Position Position)> {(playerPiece, testCase.SourcePiece)};
        var capturedPieces = testCase.CapturedPieces.Select(x => (white: opponentPiece, x));
        var blockingPieces = testCase.BlockingPieces.Select(x => (blockingPiece, x));
        var configuration = ClassicConfiguration.FromSnapshot(piece.Union(capturedPieces).Union(blockingPieces));
        // var configuration = ClassicConfiguration.FromSnapshot(piece.Union(blockingPieces));
        
        
        return new GameBoard("ID", configuration, ParticipantTestData.Participants.All);
    }
}