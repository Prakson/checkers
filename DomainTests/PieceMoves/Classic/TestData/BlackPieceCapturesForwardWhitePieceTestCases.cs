﻿using System.Collections;
using Domain.PieceMoves;
using DomainTests.PieceMoves.Classic.TestData.Dto;
using P = Domain.Position;

namespace DomainTests.PieceMoves.Classic.TestData;

public class BlackPieceCapturesForwardWhitePieceTestCases : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.B8, CapturedPieces = new[] {P.C7, P.A7},
            Moves = new[] {new Move(P.D6, new[] {P.C7}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.D8, CapturedPieces = new[] {P.C7},
            Moves = new[] {new Move(P.B6, new[] {P.C7}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.D8, CapturedPieces = new[] {P.E7},
            Moves = new[] {new Move(P.F6, new[] {P.E7}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.F8, CapturedPieces = new[] {P.E7},
            Moves = new[] {new Move(P.D6, new[] {P.E7}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.F8, CapturedPieces = new[] {P.G7},
            Moves = new[] {new Move(P.H6, new[] {P.G7}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.H8, CapturedPieces = new[] {P.G7},
            Moves = new[] {new Move(P.F6, new[] {P.G7}, 1)}
        };


        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.D8, CapturedPieces = new[] {P.C7, P.E7},
            Moves = new[]
            {
                new Move(P.B6, new[] {P.C7}, 1),
                new Move(P.F6, new[] {P.E7}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.F8, CapturedPieces = new[] {P.E7, P.G7},
            Moves = new[]
            {
                new Move(P.D6, new[] {P.E7}, 1),
                new Move(P.H6, new[] {P.G7}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.A7, CapturedPieces = new[] {P.B6},
            Moves = new[] {new Move(P.C5, new[] {P.B6}, 1)}
        };

        
        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.C7, CapturedPieces = new[] {P.B6},
            Moves = new[] {new Move(P.A5, new[] {P.B6}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.C7, CapturedPieces = new[] {P.D6},
            Moves = new[] {new Move(P.E5, new[] {P.D6}, 1)}
        };

        // Black piece on E7, capturing towards D6 or F6
        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.E7, CapturedPieces = new[] {P.D6},
            Moves = new[] {new Move(P.C5, new[] {P.D6}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.E7, CapturedPieces = new[] {P.F6},
            Moves = new[] {new Move(P.G5, new[] {P.F6}, 1)}
        };

        // Cases with multiple capturing options

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.C7, CapturedPieces = new[] {P.B6, P.D6},
            Moves = new[]
            {
                new Move(P.A5, new[] {P.B6}, 1),
                new Move(P.E5, new[] {P.D6}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.E7, CapturedPieces = new[] {P.D6, P.F6},
            Moves = new[]
            {
                new Move(P.C5, new[] {P.D6}, 1),
                new Move(P.G5, new[] {P.F6}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.B6, CapturedPieces = new[] {P.C5},
            Moves = new[] {new Move(P.D4, new[] {P.C5}, 1)}
        };

        // Black piece on D6, capturing towards C5 or E5
        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.D6, CapturedPieces = new[] {P.C5},
            Moves = new[] {new Move(P.B4, new[] {P.C5}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.D6, CapturedPieces = new[] {P.E5},
            Moves = new[] {new Move(P.F4, new[] {P.E5}, 1)}
        };

        // Cases with multiple capturing options

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.B6, CapturedPieces = new[] {P.A5, P.C5},
            Moves = new[]
            {
                new Move(P.D4, new[] {P.C5}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.D6, CapturedPieces = new[] {P.C5, P.E5},
            Moves = new[]
            {
                new Move(P.B4, new[] {P.C5}, 1),
                new Move(P.F4, new[] {P.E5}, 1)
            }
        };
        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.C5, CapturedPieces = new[] {P.B4},
            Moves = new[] {new Move(P.A3, new[] {P.B4}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.C5, CapturedPieces = new[] {P.D4},
            Moves = new[] {new Move(P.E3, new[] {P.D4}, 1)}
        };

        // Black piece on E5, capturing towards D4 or F4
        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.E5, CapturedPieces = new[] {P.D4},
            Moves = new[] {new Move(P.C3, new[] {P.D4}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.E5, CapturedPieces = new[] {P.F4},
            Moves = new[] {new Move(P.G3, new[] {P.F4}, 1)}
        };

        // Cases with multiple capturing options

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.C5, CapturedPieces = new[] {P.B4, P.D4},
            Moves = new[]
            {
                new Move(P.A3, new[] {P.B4}, 1),
                new Move(P.E3, new[] {P.D4}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.E5, CapturedPieces = new[] {P.D4, P.F4},
            Moves = new[]
            {
                new Move(P.C3, new[] {P.D4}, 1),
                new Move(P.G3, new[] {P.F4}, 1)
            }
        };
        
        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.B4, CapturedPieces = new[] {P.C3, P.A3},
            Moves = new[] {new Move(P.D2, new[] {P.C3}, 1)}
        };

        // Black piece on D4, capturing towards C3 or E3
        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.D4, CapturedPieces = new[] {P.C3},
            Moves = new[] {new Move(P.B2, new[] {P.C3}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.D4, CapturedPieces = new[] {P.E3},
            Moves = new[] {new Move(P.F2, new[] {P.E3}, 1)}
        };

        // Cases with multiple capturing options

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.B4, CapturedPieces = new[] {P.A3, P.C3},
            Moves = new[]
            {
                new Move(P.D2, new[] {P.C3}, 1),
            }
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.D4, CapturedPieces = new[] {P.C3, P.E3},
            Moves = new[]
            {
                new Move(P.B2, new[] {P.C3}, 1),
                new Move(P.F2, new[] {P.E3}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.C3, CapturedPieces = new[] {P.B2},
            Moves = new[] {new Move(P.A1, new[] {P.B2}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.C3, CapturedPieces = new[] {P.D2},
            Moves = new[] {new Move(P.E1, new[] {P.D2}, 1)}
        };

        // Black piece on E3, capturing towards D2 or F2
        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.E3, CapturedPieces = new[] {P.D2},
            Moves = new[] {new Move(P.C1, new[] {P.D2}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.E3, CapturedPieces = new[] {P.F2},
            Moves = new[] {new Move(P.G1, new[] {P.F2}, 1)}
        };
        
        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.C3, CapturedPieces = new[] {P.B2, P.D2},
            Moves = new[]
            {
                new Move(P.A1, new[] {P.B2}, 1),
                new Move(P.E1, new[] {P.D2}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.E3, CapturedPieces = new[] {P.D2, P.F2},
            Moves = new[]
            {
                new Move(P.C1, new[] {P.D2}, 1),
                new Move(P.G1, new[] {P.F2}, 1)
            }
        };
    }
}