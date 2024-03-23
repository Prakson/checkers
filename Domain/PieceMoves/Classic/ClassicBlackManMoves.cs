﻿using Domain.Pieces;

namespace Domain.PieceMoves.Classic;

public class ClassicBlackManMoves : PieceMove
{
    // To be refactored later
    // So far it's a copy & paste of white man moves
    // Once most of test cases are ready, refactoring will be needed
    public IEnumerable<Move> PossibleMoves(Position currentPosition, BoardSnapshot boardSnapshot)
    {
        var column = currentPosition.Column;
        var row = currentPosition.Row;
        
        if (row == Position.R1)
        {
            return Enumerable.Empty<Move>();
        }
        
        if (column == Position.A)
        {
            var newPosition = new Position(row - 1, column + 1);
            var newSquare = boardSnapshot.Squares[newPosition.Row, newPosition.Column];

            if (newSquare.Piece is not null && newSquare.Piece.Color == Color.White)
            {
                var newPositionAfterCapture = new Position(row - 2, column + 2);
                var newSquareAfterCapture = boardSnapshot.Squares[newPositionAfterCapture.Row, newPositionAfterCapture.Column];
                if (newSquareAfterCapture.Piece is not null)
                {
                    //TODO: Square is already occupied
                }

                return new[] {new Move(newPositionAfterCapture, new[] {newPosition}, 1)};
            }
            
            if (newSquare.Piece is not null)
            {
                return Enumerable.Empty<Move>();
            }
            
            return new[] {new Move(newPosition, new[] {newPosition}, 0)};
        }

        if (column == boardSnapshot.Columns - 1)
        {
            var newPosition = new Position(row - 1, column - 1);
            var newSquare = boardSnapshot.Squares[newPosition.Row, newPosition.Column];

            if (newSquare.Piece is not null && newSquare.Piece.Color == Color.White)
            {
                var newPositionAfterCapture = new Position(row - 2, column - 2);
                var newSquareAfterCapture = boardSnapshot.Squares[newPositionAfterCapture.Row, newPositionAfterCapture.Column];
                if (newSquareAfterCapture.Piece is not null)
                {
                    //TODO: Square is already occupied
                }

                return new[] {new Move(newPositionAfterCapture, new[] {newPosition}, 1)};
            }
            
            if (newSquare.Piece is not null)
            {
                return Enumerable.Empty<Move>();
            }
            
            return new[] {new Move(newPosition, new[] {newPosition}, 0)};
        }

        var maxCapturedPieces = 0;
        var moves = new List<Move>();
        
        // To the left
        var newPosition1 = new Position(row - 1, column - 1);
        var newSquare1 = boardSnapshot.Squares[newPosition1.Row, newPosition1.Column];
        if (newSquare1.Piece is not null && newPosition1.Column > 0 && newSquare1.Piece.Color == Color.White)
        {
            var newPositionAfterCapture = new Position(newPosition1.Row - 1, newPosition1.Column - 1);
            var newSquareAfterCapture = boardSnapshot.Squares[newPositionAfterCapture.Row, newPositionAfterCapture.Column];
            if (newSquareAfterCapture.Piece is not null)
            {
                //TODO: Square is already occupied
            }

            maxCapturedPieces = 1;
            moves.Add(new Move(newPositionAfterCapture, new[] {newPosition1}, 1));
        }
        
        //To the right
        var newPosition2 = new Position(row - 1, column + 1);
        var newSquare2 = boardSnapshot.Squares[newPosition2.Row, newPosition2.Column];
        if (newSquare2.Piece is not null && newSquare2.Piece.Color == Color.White)
        {
            var newPositionAfterCapture = new Position(row - 2, column + 2);
            var newSquareAfterCapture = boardSnapshot.Squares[newPositionAfterCapture.Row, newPositionAfterCapture.Column];
            if (newSquareAfterCapture.Piece is not null)
            {
                //TODO: Square is already occupied
            }

            maxCapturedPieces = 1;
            moves.Add(new Move(newPositionAfterCapture, new[] {newPosition2}, 1));
        }
        
        if (newSquare1.Piece is null && maxCapturedPieces == 0)
        {
            moves.Add(new Move(newPosition1, new[] {newPosition1}, 0));
        }
        
        if (newSquare2.Piece is null && maxCapturedPieces == 0)
        {
            moves.Add(new Move(newPosition2, new[] {newPosition2}, 0));
        }

        return moves;
    }
        // var column = currentPosition.Column;
        // var row = currentPosition.Row;
        //
        // if (row == Position.R1)
        // {
        //     return Enumerable.Empty<Move>();
        // }
        //
        // if (column == Position.A)
        // {
        //     var newPosition = new Position(row - 1, column + 1);
        //     var newSquare = boardSnapshot.Squares[newPosition.Row, newPosition.Column];
        //
        //     if (newSquare.Piece is not null)
        //     {
        //         return Enumerable.Empty<Move>();
        //     }
        //
        //     var move = new Move(newPosition, new[] {newPosition}, 0);
        //     return new[] {move};
        // }
        //
        // if (column == boardSnapshot.Columns - 1)
        // {
        //     var newPosition = new Position(row - 1, column - 1);
        //     var newSquare = boardSnapshot.Squares[newPosition.Row, newPosition.Column];
        //
        //     if (newSquare.Piece is not null)
        //     {
        //         return Enumerable.Empty<Move>();
        //     }
        //     
        //     var move = new Move(newPosition, new[] {newPosition}, 0);
        //     return new[] {move};
        // }
        //
        // var moves = new List<Move>();
        //
        // var newPosition1 = new Position(row - 1, column - 1);
        // var newPosition2 = new Position(row - 1, column + 1);
        //
        // var newSquare1 = boardSnapshot.Squares[newPosition1.Row, newPosition1.Column];
        // var newSquare2 = boardSnapshot.Squares[newPosition2.Row, newPosition2.Column];
        //
        // if (newSquare1.Piece is null)
        // {
        //     moves.Add(new Move(newPosition1, new[] {newPosition1}, 0));
        // }
        //
        // if (newSquare2.Piece is null)
        // {
        //     moves.Add(new Move(newPosition2, new[] {newPosition2}, 0));
        //
        // }
        //
        // return moves;
    // }
}