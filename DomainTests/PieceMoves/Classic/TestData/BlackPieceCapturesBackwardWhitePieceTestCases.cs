﻿using System.Collections;
using Domain.PieceMoves;
using DomainTests.PieceMoves.Classic.TestData.Dto;
using P = Domain.Position;

namespace DomainTests.PieceMoves.Classic.TestData;

public class BlackPieceCapturesBackwardWhitePieceTestCases : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.B6, CapturedPieces = new[] {P.A7, P.C7},
            Moves = new[] {new Move(P.D8, new[] {P.C7}, 1)}
        };
        
        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.D6, CapturedPieces = new[] {P.C7, P.E7},
            Moves = new[]
            {
                new Move(P.B8, new[] {P.C7}, 1),
                new Move(P.F8, new[] {P.E7}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.F6, CapturedPieces = new[] {P.E7, P.G7},
            Moves = new[]
            {
                new Move(P.D8, new[] {P.E7}, 1),
                new Move(P.H8, new[] {P.G7}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.H6, CapturedPieces = new[] {P.G7},
            Moves = new[]
            {
                new Move(P.F8, new[] {P.G7}, 1),
            }
        };
        
        
        
        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.A5, CapturedPieces = new[] {P.B6},
            Moves = new[] {new Move(P.C7, new[] {P.B6}, 1)}
        };
        
        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.C5, CapturedPieces = new[] {P.B6, P.D6},
            Moves = new[]
            {
                new Move(P.A7, new[] {P.B6}, 1),
                new Move(P.E7, new[] {P.D6}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.E5, CapturedPieces = new[] {P.D6, P.F6},
            Moves = new[]
            {
                new Move(P.C7, new[] {P.D6}, 1),
                new Move(P.G7, new[] {P.F6}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.G5, CapturedPieces = new[] {P.F6, P.H6},
            Moves = new[]
            {
                new Move(P.E7, new[] {P.F6}, 1),
            }
        };
        

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.B4, CapturedPieces = new[] {P.A5, P.C5},
            Moves = new[] {new Move(P.D6, new[] {P.C5}, 1)}
        };
        
        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.D4, CapturedPieces = new[] {P.C5, P.E5},
            Moves = new[]
            {
                new Move(P.B6, new[] {P.C5}, 1),
                new Move(P.F6, new[] {P.E5}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.F4, CapturedPieces = new[] {P.E5, P.G5},
            Moves = new[]
            {
                new Move(P.D6, new[] {P.E5}, 1),
                new Move(P.H6, new[] {P.G5}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.H4, CapturedPieces = new[] {P.G5},
            Moves = new[]
            {
                new Move(P.F6, new[] {P.G5}, 1),
            }
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.A3, CapturedPieces = new[] {P.B4},
            Moves = new[] {new Move(P.C5, new[] {P.B4}, 1)}
        };
        
        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.C3, CapturedPieces = new[] {P.B4, P.D4},
            Moves = new[]
            {
                new Move(P.A5, new[] {P.B4}, 1),
                new Move(P.E5, new[] {P.D4}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.E3, CapturedPieces = new[] {P.D4, P.F4},
            Moves = new[]
            {
                new Move(P.C5, new[] {P.D4}, 1),
                new Move(P.G5, new[] {P.F4}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.G3, CapturedPieces = new[] {P.F4, P.H4},
            Moves = new[]
            {
                new Move(P.E5, new[] {P.F4}, 1),
            }
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.B2, CapturedPieces = new[] {P.A3, P.C3},
            Moves = new[] {new Move(P.D4, new[] {P.C3}, 1)}
        };
        
        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.D2, CapturedPieces = new[] {P.C3, P.E3},
            Moves = new[]
            {
                new Move(P.B4, new[] {P.C3}, 1),
                new Move(P.F4, new[] {P.E3}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.F2, CapturedPieces = new[] {P.E3, P.G3},
            Moves = new[]
            {
                new Move(P.D4, new[] {P.E3}, 1),
                new Move(P.H4, new[] {P.G3}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.H2, CapturedPieces = new[] {P.G3},
            Moves = new[]
            {
                new Move(P.F4, new[] {P.G3}, 1),
            }
        };
    }
}