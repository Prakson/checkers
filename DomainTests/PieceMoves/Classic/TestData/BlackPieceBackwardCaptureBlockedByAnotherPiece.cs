﻿using System.Collections;
using Domain.PieceMoves;
using P = Domain.Position;
using TestCase = DomainTests.PieceMoves.Classic.TestData.Dto.PieceBackwardCaptureBlockTestCase;
namespace DomainTests.PieceMoves.Classic.TestData;

public class BlackPieceBackwardCaptureBlockedByAnotherPiece : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new TestCase {SourcePiece = P.B2, CapturedPieces = [P.A3, P.C3], BlockingPieces = [P.D4],       Moves = [new Move(P.A1, [P.A1], 0), new Move(P.C1, [P.C1], 0)]};
        yield return new TestCase {SourcePiece = P.D2, CapturedPieces = [P.C3, P.E3], BlockingPieces = [P.B4, P.F4], Moves = [new Move(P.C1, [P.C1], 0), new Move(P.E1, [P.E1], 0)]};
        yield return new TestCase {SourcePiece = P.F2, CapturedPieces = [P.E3, P.G3], BlockingPieces = [P.D4, P.H4], Moves = [new Move(P.E1, [P.E1], 0), new Move(P.G1, [P.G1], 0)]};
        yield return new TestCase {SourcePiece = P.H2, CapturedPieces = [P.G3],       BlockingPieces = [P.F4],       Moves = [new Move(P.G1, [P.G1], 0)]};
        
        yield return new TestCase {SourcePiece = P.A3, CapturedPieces = [P.B4],       BlockingPieces = [P.C5],       Moves = [new Move(P.B2, [P.B2], 0)]};
        yield return new TestCase {SourcePiece = P.C3, CapturedPieces = [P.B4, P.D4], BlockingPieces = [P.A5, P.E5], Moves = [new Move(P.B2, [P.B2], 0), new Move(P.D2, [P.D2], 0)]};
        yield return new TestCase {SourcePiece = P.E3, CapturedPieces = [P.D4, P.F4], BlockingPieces = [P.C5, P.G5], Moves = [new Move(P.D2, [P.D2], 0), new Move(P.F2, [P.F2], 0)]};
        yield return new TestCase {SourcePiece = P.G3, CapturedPieces = [P.F4, P.H4], BlockingPieces = [P.E5],       Moves = [new Move(P.F2, [P.F2], 0), new Move(P.H2, [P.H2], 0)]};
        
        yield return new TestCase {SourcePiece = P.B4, CapturedPieces = [P.A5, P.C5], BlockingPieces = [P.D6],       Moves = [new Move(P.A3, [P.A3], 0), new Move(P.C3, [P.C3], 0)]};
        yield return new TestCase {SourcePiece = P.D4, CapturedPieces = [P.C5, P.E5], BlockingPieces = [P.B6, P.F6], Moves = [new Move(P.C3, [P.C3], 0), new Move(P.E3, [P.E3], 0)]};
        yield return new TestCase {SourcePiece = P.F4, CapturedPieces = [P.E5, P.G5], BlockingPieces = [P.D6, P.H6], Moves = [new Move(P.E3, [P.E3], 0), new Move(P.G3, [P.G3], 0)]};
        yield return new TestCase {SourcePiece = P.H4, CapturedPieces = [P.G5],       BlockingPieces = [P.F6],       Moves = [new Move(P.G3, [P.G3], 0)]};
        
        yield return new TestCase {SourcePiece = P.A5, CapturedPieces = [P.B6],       BlockingPieces = [P.C7],       Moves = [new Move(P.B4, [P.B4], 0)]};
        yield return new TestCase {SourcePiece = P.C5, CapturedPieces = [P.B6, P.D6], BlockingPieces = [P.A7, P.E7], Moves = [new Move(P.B4, [P.B4], 0), new Move(P.D4, [P.D4], 0)]};
        yield return new TestCase {SourcePiece = P.E5, CapturedPieces = [P.D6, P.F6], BlockingPieces = [P.C7, P.G7], Moves = [new Move(P.D4, [P.D4], 0), new Move(P.F4, [P.F4], 0)]};
        yield return new TestCase {SourcePiece = P.G5, CapturedPieces = [P.F6, P.H6], BlockingPieces = [P.E7],       Moves = [new Move(P.F4, [P.F4], 0), new Move(P.H4, [P.H4], 0)]};
        
        yield return new TestCase {SourcePiece = P.B6, CapturedPieces = [P.A7, P.C7], BlockingPieces = [P.D8],       Moves = [new Move(P.A5, [P.A5], 0), new Move(P.C5, [P.C5], 0)]};
        yield return new TestCase {SourcePiece = P.D6, CapturedPieces = [P.C7, P.E7], BlockingPieces = [P.B8, P.F8], Moves = [new Move(P.C5, [P.C5], 0), new Move(P.E5, [P.E5], 0)]};
        yield return new TestCase {SourcePiece = P.F6, CapturedPieces = [P.E7, P.G7], BlockingPieces = [P.D8, P.H8], Moves = [new Move(P.E5, [P.E5], 0), new Move(P.G5, [P.G5], 0)]};
        yield return new TestCase {SourcePiece = P.H6, CapturedPieces = [P.G7],       BlockingPieces = [P.F8],       Moves = [new Move(P.G5, [P.G5], 0)]};
    }
}