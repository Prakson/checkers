﻿using System.Collections;
using Domain.Chessboard.PieceMoves;
using DomainTests.Chessboard.PieceMoves.Classic.TestData.Dto;
using P = Domain.Chessboard.Position;

namespace DomainTests.Chessboard.PieceMoves.Classic.TestData;

public class WhiteManMovesForward : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        // Row1
        yield return new PieceCaptureTestCase {Source = P.A1, Moves = new List<PossibleMove> {new(P.B2, new[] {P.B2}, 0)}};
        yield return new PieceCaptureTestCase {Source = P.C1, Moves = new List<PossibleMove> {new(P.B2, new[] {P.B2}, 0), new(P.D2, new[] {P.D2}, 0)}};
        yield return new PieceCaptureTestCase {Source = P.E1, Moves = new List<PossibleMove> {new(P.D2, new[] {P.D2}, 0), new(P.F2, new[] {P.F2}, 0)}};
        yield return new PieceCaptureTestCase {Source = P.G1, Moves = new List<PossibleMove> {new(P.F2, new[] {P.F2}, 0), new(P.H2, new[] {P.H2}, 0)}};

        //Row2
        yield return new PieceCaptureTestCase {Source = P.B2, Moves = new List<PossibleMove> {new(P.A3, new[] {P.A3}, 0), new(P.C3, new[] {P.C3}, 0)}};
        yield return new PieceCaptureTestCase {Source = P.D2, Moves = new List<PossibleMove> {new(P.C3, new[] {P.C3}, 0), new(P.E3, new[] {P.E3}, 0)}};
        yield return new PieceCaptureTestCase {Source = P.F2, Moves = new List<PossibleMove> {new(P.E3, new[] {P.E3}, 0), new(P.G3, new[] {P.G3}, 0)}};
        yield return new PieceCaptureTestCase {Source = P.H2, Moves = new List<PossibleMove> {new(P.G3, new[] {P.G3}, 0)}};

        //Row3
        yield return new PieceCaptureTestCase {Source = P.A3, Moves = new List<PossibleMove> {new(P.B4, new[] {P.B4}, 0)}};
        yield return new PieceCaptureTestCase {Source = P.C3, Moves = new List<PossibleMove> {new(P.B4, new[] {P.B4}, 0), new(P.D4, new[] {P.D4}, 0)}};
        yield return new PieceCaptureTestCase {Source = P.E3, Moves = new List<PossibleMove> {new(P.D4, new[] {P.D4}, 0), new(P.F4, new[] {P.F4}, 0)}};
        yield return new PieceCaptureTestCase {Source = P.G3, Moves = new List<PossibleMove> {new(P.F4, new[] {P.F4}, 0), new(P.H4, new[] {P.H4}, 0)}};

        //Row4
        yield return new PieceCaptureTestCase {Source = P.B4, Moves = new List<PossibleMove> {new(P.A5, new[] {P.A5}, 0), new(P.C5, new[] {P.C5}, 0)}};
        yield return new PieceCaptureTestCase {Source = P.D4, Moves = new List<PossibleMove> {new(P.C5, new[] {P.C5}, 0), new(P.E5, new[] {P.E5}, 0)}};
        yield return new PieceCaptureTestCase {Source = P.F4, Moves = new List<PossibleMove> {new(P.E5, new[] {P.E5}, 0), new(P.G5, new[] {P.G5}, 0)}};
        yield return new PieceCaptureTestCase {Source = P.H4, Moves = new List<PossibleMove> {new(P.G5, new[] {P.G5}, 0)}};

        // Row5
        yield return new PieceCaptureTestCase {Source = P.A5, Moves = new List<PossibleMove> {new(P.B6, new[] {P.B6}, 0)}};
        yield return new PieceCaptureTestCase {Source = P.C5, Moves = new List<PossibleMove> {new(P.B6, new[] {P.B6}, 0), new(P.D6, new[] {P.D6}, 0)}};
        yield return new PieceCaptureTestCase {Source = P.E5, Moves = new List<PossibleMove> {new(P.D6, new[] {P.D6}, 0), new(P.F6, new[] {P.F6}, 0)}};
        yield return new PieceCaptureTestCase {Source = P.G5, Moves = new List<PossibleMove> {new(P.F6, new[] {P.F6}, 0), new(P.H6, new[] {P.H6}, 0)}};

        //Row6
        yield return new PieceCaptureTestCase {Source = P.B6, Moves = new List<PossibleMove> {new(P.A7, new[] {P.A7}, 0), new(P.C7, new[] {P.C7}, 0)}};
        yield return new PieceCaptureTestCase {Source = P.D6, Moves = new List<PossibleMove> {new(P.C7, new[] {P.C7}, 0), new(P.E7, new[] {P.E7}, 0)}};
        yield return new PieceCaptureTestCase {Source = P.F6, Moves = new List<PossibleMove> {new(P.E7, new[] {P.E7}, 0), new(P.G7, new[] {P.G7}, 0)}};
        yield return new PieceCaptureTestCase {Source = P.H6, Moves = new List<PossibleMove> {new(P.G7, new[] {P.G7}, 0)}};

        //Row7
        yield return new PieceCaptureTestCase {Source = P.A7, Moves = new List<PossibleMove> {new(P.B8, new[] {P.B8}, 0)}};
        yield return new PieceCaptureTestCase {Source = P.C7, Moves = new List<PossibleMove> {new(P.B8, new[] {P.B8}, 0), new(P.D8, new[] {P.D8}, 0)}};
        yield return new PieceCaptureTestCase {Source = P.E7, Moves = new List<PossibleMove> {new(P.D8, new[] {P.D8}, 0), new(P.F8, new[] {P.F8}, 0)}};
        yield return new PieceCaptureTestCase {Source = P.G7, Moves = new List<PossibleMove> {new(P.F8, new[] {P.F8}, 0), new(P.H8, new[] {P.H8}, 0)}};

        //Row8
        yield return new PieceCaptureTestCase {Source = P.B8, Moves = new List<PossibleMove>()};
        yield return new PieceCaptureTestCase {Source = P.D8, Moves = new List<PossibleMove>()};
        yield return new PieceCaptureTestCase {Source = P.F8, Moves = new List<PossibleMove>()};
        yield return new PieceCaptureTestCase {Source = P.H8, Moves = new List<PossibleMove>()};
    }
}