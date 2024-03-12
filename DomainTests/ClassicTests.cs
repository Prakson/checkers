﻿using Domain;
using Domain.Configurations.Classic;
using Domain.Errors.Board;
using DomainTests.Extensions;
using static DomainTests.Extensions.TestSquare;

namespace DomainTests;

public class ClassicTests
{
    [Test]
    public void NewBoard()
    {
        var configuration = ClassicConfiguration.NewBoard();
        var board = new Board(configuration);

        var snapshot = board.Snapshot.ToTestSquares(); 
        var expected = new[,]
        {
            { Empty, 	BlackMan, 	Empty, 		BlackMan, 	Empty, 		BlackMan, 	Empty, 		BlackMan},
            { BlackMan, Empty, 		BlackMan, 	Empty, 		BlackMan, 	Empty, 		BlackMan, 	Empty},
            { Empty, 	BlackMan, 	Empty, 		BlackMan, 	Empty, 		BlackMan, 	Empty, 		BlackMan},
            { Empty, 	Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty},
            { Empty, 	Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty},
            { WhiteMan,	Empty, 		WhiteMan, 	Empty, 		WhiteMan, 	Empty, 		WhiteMan, 	Empty},
            { Empty, 	WhiteMan, 	Empty, 		WhiteMan, 	Empty, 		WhiteMan, 	Empty, 		WhiteMan},
            { WhiteMan, Empty, 		WhiteMan, 	Empty, 		WhiteMan, 	Empty, 		WhiteMan, 	Empty}
        };

        BoardAssert.ReversedRowsEqualTo(expected, snapshot);
    }

    [Test]
    [TestCase(Position.R3, Position.A, -100, -100)]
    [TestCase(Position.R3, Position.A, -1, -1)]
    [TestCase(Position.R3, Position.A, 0, 8)]
    [TestCase(Position.R3, Position.A, 0, 9)]
    [TestCase(Position.R3, Position.A, 8, 0)]
    [TestCase(Position.R3, Position.A, 9, 0)]
    [TestCase(Position.R3, Position.A, 100, 100)]
    [TestCase(-1, -1, Position.R1, Position.A)]
    [TestCase(100, 100, Position.R1, Position.A)]
    [TestCase(9, 9, Position.R1, Position.A)]
    [TestCase(8, 7, Position.R1, Position.A)]
    [TestCase(7, 8, Position.R1, Position.A)]
    public void MoveOutOfBoard(int sourceRow, int sourceColumn, int targetRow, int targetColumn)
    {
        var configuration = ClassicConfiguration.NewBoard();
        var board = new Board(configuration);

        var result = board.Move(new Position(sourceRow, sourceColumn), new Position(targetRow, targetColumn));
        
        Assert.That(result.HasError<PositionOutOfBoard>());
    }

    [Test]
    public void SquareEmpty()
    {
        var configuration = ClassicConfiguration.NewBoard();
        var board = new Board(configuration);

        var result = board.Move(new Position(Position.R1, Position.B), new Position(Position.R1, Position.A));
        
        Assert.That(result.HasError<EmptySquare>());
    }

    [Test]
    public void MoveNotAllowed()
    {
        var configuration = ClassicConfiguration.NewBoard();
        var board = new Board(configuration);

        var result = board.Move(new Position(Position.R1, Position.A), new Position(Position.R8, Position.H));
        
        Assert.That(result.HasError<MoveNotAllowed>());
    }
    
    [Test]
    public void FirstMove()
    {
        var configuration = ClassicConfiguration.NewBoard();
        var board = new Board(configuration);

        var result = board.Move(new Position(Position.R3, Position.A), new Position(Position.R4, Position.B));
        
        Assert.That(result.IsSuccess);
        
        var snapshot = board.Snapshot.ToTestSquares();
        var expected = new[,]
        {
            { Empty, 	BlackMan, 	Empty, 		BlackMan, 	Empty, 		BlackMan, 	Empty, 		BlackMan},
            { BlackMan, Empty, 		BlackMan, 	Empty, 		BlackMan, 	Empty, 		BlackMan, 	Empty},
            { Empty, 	BlackMan, 	Empty, 		BlackMan, 	Empty, 		BlackMan,	Empty, 		BlackMan},
            { Empty, 	Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty},
            { Empty, 	WhiteMan, 	Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty},
            { Empty,    Empty, 		WhiteMan, 	Empty, 		WhiteMan,	Empty, 		WhiteMan, 	Empty},
            { Empty, 	WhiteMan, 	Empty, 		WhiteMan, 	Empty, 		WhiteMan, 	Empty, 		WhiteMan},
            { WhiteMan, Empty, 		WhiteMan, 	Empty, 		WhiteMan, 	Empty, 		WhiteMan, 	Empty}
        };
        
        BoardAssert.ReversedRowsEqualTo(expected, snapshot);
    }
}