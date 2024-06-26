﻿using System.Collections;
using Domain.Chessboard.PieceMoves;
using DomainTests.Chessboard.PieceMoves.Classic.TestData.Dto;
using P = Domain.Chessboard.Position;

namespace DomainTests.Chessboard.PieceMoves.Classic.TestData;

public class BlackManMovesForwardBlockingMoves : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        // Piece on B8, completely blocked by pieces on A7 and C7
        yield return new PieceCaptureTestCase
        {
            Source = P.B8, Blocking = new List<P> {P.A7, P.C7},
            Moves = Enumerable.Empty<PossibleMove>()
        };

        // Piece on D8, completely blocked by pieces on C7 and E7
        yield return new PieceCaptureTestCase
        {
            Source = P.D8, Blocking = new List<P> {P.C7, P.E7},
            Moves = Enumerable.Empty<PossibleMove>()
        };

        // Piece on F8, completely blocked by pieces on E7 and G7
        yield return new PieceCaptureTestCase
        {
            Source = P.F8, Blocking = new List<P> {P.E7, P.G7},
            Moves = Enumerable.Empty<PossibleMove>()
        };

        // Piece on H8, completely blocked by piece on G7
        yield return new PieceCaptureTestCase
        {
            Source = P.H8, Blocking = new List<P> {P.G7},
            Moves = Enumerable.Empty<PossibleMove>()
        };

        // Side blocked scenarios
        // Piece on B8, blocked by piece on A7, move available to C7
        yield return new PieceCaptureTestCase
        {
            Source = P.B8, Blocking = new List<P> {P.A7},
            Moves = new List<PossibleMove> {new(P.C7, new List<P> {P.C7}, 0)}
        };

        // Piece on B8, blocked by piece on C7, move available to A7
        yield return new PieceCaptureTestCase
        {
            Source = P.B8, Blocking = new List<P> {P.C7},
            Moves = new List<PossibleMove> {new(P.A7, new List<P> {P.A7}, 0)}
        };

        // Piece on D8, blocked by piece on C7, move available to E7
        yield return new PieceCaptureTestCase
        {
            Source = P.D8, Blocking = new List<P> {P.C7},
            Moves = new List<PossibleMove> {new(P.E7, new List<P> {P.E7}, 0)}
        };

        // Piece on D8, blocked by piece on E7, move available to C7
        yield return new PieceCaptureTestCase
        {
            Source = P.D8, Blocking = new List<P> {P.E7},
            Moves = new List<PossibleMove> {new(P.C7, new List<P> {P.C7}, 0)}
        };

        // Piece on F8, blocked by piece on E7, move available to G7
        yield return new PieceCaptureTestCase
        {
            Source = P.F8, Blocking = new List<P> {P.E7},
            Moves = new List<PossibleMove> {new(P.G7, new List<P> {P.G7}, 0)}
        };

        // Piece on F8, blocked by piece on G7, move available to E7
        yield return new PieceCaptureTestCase
        {
            Source = P.F8, Blocking = new List<P> {P.G7},
            Moves = new List<PossibleMove> {new(P.E7, new List<P> {P.E7}, 0)}
        };

        // Completely blocked scenarios
        // Piece on A7, moving to B6 (only one move available due to board limits)
        yield return new PieceCaptureTestCase
        {
            Source = P.A7, Blocking = new List<P> {P.B6}, // A7 can only move to B6
            Moves = Enumerable.Empty<PossibleMove>()
        };

        // Piece on C7, completely blocked by pieces on B6 and D6
        yield return new PieceCaptureTestCase
        {
            Source = P.C7, Blocking = new List<P> {P.B6, P.D6},
            Moves = Enumerable.Empty<PossibleMove>()
        };

        // Piece on E7, completely blocked by pieces on D6 and F6
        yield return new PieceCaptureTestCase
        {
            Source = P.E7, Blocking = new List<P> {P.D6, P.F6},
            Moves = Enumerable.Empty<PossibleMove>()
        };

        // Piece on G7, completely blocked by pieces on F6 and H6
        yield return new PieceCaptureTestCase
        {
            Source = P.G7, Blocking = new List<P> {P.F6, P.H6},
            Moves = Enumerable.Empty<PossibleMove>()
        };

        // Side blocked scenarios
        // Piece on C7, blocked by piece on B6, move available to D6
        yield return new PieceCaptureTestCase
        {
            Source = P.C7, Blocking = new List<P> {P.B6},
            Moves = new List<PossibleMove> {new(P.D6, new List<P> {P.D6}, 0)}
        };

        // Piece on C7, blocked by piece on D6, move available to B6
        yield return new PieceCaptureTestCase
        {
            Source = P.C7,
            Blocking = new List<P> {P.D6},
            Moves = new List<PossibleMove> {new(P.B6, new List<P> {P.B6}, 0)}
        };

        // Piece on E7, blocked by piece on D6, move available to F6
        yield return new PieceCaptureTestCase
        {
            Source = P.E7, Blocking = new List<P> {P.D6},
            Moves = new List<PossibleMove> {new(P.F6, new List<P> {P.F6}, 0)}
        };

        // Piece on E7, blocked by piece on F6, move available to D6
        yield return new PieceCaptureTestCase
        {
            Source = P.E7, Blocking = new List<P> {P.F6},
            Moves = new List<PossibleMove> {new(P.D6, new List<P> {P.D6}, 0)}
        };

        // Piece on G7, blocked by piece on F6, move available to H6
        yield return new PieceCaptureTestCase
        {
            Source = P.G7, Blocking = new List<P> {P.F6},
            Moves = new List<PossibleMove> {new(P.H6, new List<P> {P.H6}, 0)}
        };

        // Piece on G7, blocked by piece on H6, move available to F6
        yield return new PieceCaptureTestCase
        {
            Source = P.G7, Blocking = new List<P> {P.H6},
            Moves = new List<PossibleMove> {new(P.F6, new List<P> {P.F6}, 0)}
        };


        // Completely blocked scenarios

        // Piece on B6, completely blocked by pieces on A5 and C5
        yield return new PieceCaptureTestCase
        {
            Source = P.B6, Blocking = new List<P> {P.A5, P.C5},
            Moves = Enumerable.Empty<PossibleMove>()
        };

        // Piece on D6, completely blocked by pieces on C5 and E5
        yield return new PieceCaptureTestCase
        {
            Source = P.D6, Blocking = new List<P> {P.C5, P.E5},
            Moves = Enumerable.Empty<PossibleMove>()
        };

        // Piece on F6, completely blocked by pieces on E5 and G5
        yield return new PieceCaptureTestCase
        {
            Source = P.F6, Blocking = new List<P> {P.E5, P.G5},
            Moves = Enumerable.Empty<PossibleMove>()
        };

        // Piece on H6, completely blocked by piece on G5
        yield return new PieceCaptureTestCase
        {
            Source = P.H6, Blocking = new List<P> {P.G5}, // H6 can only move to G5
            Moves = Enumerable.Empty<PossibleMove>()
        };

        // Side blocked scenarios

        // Piece on B6, blocked by piece on A5, move available to C5
        yield return new PieceCaptureTestCase
        {
            Source = P.B6, Blocking = new List<P> {P.A5},
            Moves = new List<PossibleMove> {new(P.C5, new List<P> {P.C5}, 0)}
        };

        // Piece on B6, blocked by piece on C5, move available to A5
        yield return new PieceCaptureTestCase
        {
            Source = P.B6, Blocking = new List<P> {P.C5},
            Moves = new List<PossibleMove> {new(P.A5, new List<P> {P.A5}, 0)}
        };

        // Piece on D6, blocked by piece on C5, move available to E5
        yield return new PieceCaptureTestCase
        {
            Source = P.D6, Blocking = new List<P> {P.C5},
            Moves = new List<PossibleMove> {new(P.E5, new List<P> {P.E5}, 0)}
        };

        // Piece on D6, blocked by piece on E5, move available to C5
        yield return new PieceCaptureTestCase
        {
            Source = P.D6, Blocking = new List<P> {P.E5},
            Moves = new List<PossibleMove> {new(P.C5, new List<P> {P.C5}, 0)}
        };

        // Piece on F6, blocked by piece on E5, move available to G5
        yield return new PieceCaptureTestCase
        {
            Source = P.F6, Blocking = new List<P> {P.E5},
            Moves = new List<PossibleMove> {new(P.G5, new List<P> {P.G5}, 0)}
        };

        // Piece on F6, blocked by piece on G5, move available to E5
        yield return new PieceCaptureTestCase
        {
            Source = P.F6, Blocking = new List<P> {P.G5},
            Moves = new List<PossibleMove> {new(P.E5, new List<P> {P.E5}, 0)}
        };

        // Completely blocked scenarios

        // Piece on A5, completely blocked by piece on B4
        yield return new PieceCaptureTestCase
        {
            Source = P.A5, Blocking = new List<P> {P.B4},
            Moves = Enumerable.Empty<PossibleMove>()
        };

        // Piece on C5, completely blocked by pieces on B4 and D4
        yield return new PieceCaptureTestCase
        {
            Source = P.C5, Blocking = new List<P> {P.B4, P.D4},
            Moves = Enumerable.Empty<PossibleMove>()
        };

        // Piece on E5, completely blocked by pieces on D4 and F4
        yield return new PieceCaptureTestCase
        {
            Source = P.E5, Blocking = new List<P> {P.D4, P.F4},
            Moves = Enumerable.Empty<PossibleMove>()
        };

        // Piece on G5, completely blocked by pieces on F4 and H4
        yield return new PieceCaptureTestCase
        {
            Source = P.G5, Blocking = new List<P> {P.F4, P.H4},
            Moves = Enumerable.Empty<PossibleMove>()
        };

        // Side blocked scenarios

        // Piece on A5, blocked by piece on B4, no other option due to edge
        // A5 has only one forward move, thus if blocked, no other moves available

        // Piece on C5, blocked by piece on B4, move available to D4
        yield return new PieceCaptureTestCase
        {
            Source = P.C5, Blocking = new List<P> {P.B4},
            Moves = new List<PossibleMove> {new(P.D4, new List<P> {P.D4}, 0)}
        };

        // Piece on C5, blocked by piece on D4, move available to B4
        yield return new PieceCaptureTestCase
        {
            Source = P.C5, Blocking = new List<P> {P.D4},
            Moves = new List<PossibleMove> {new(P.B4, new List<P> {P.B4}, 0)}
        };

        // Piece on E5, blocked by piece on D4, move available to F4
        yield return new PieceCaptureTestCase
        {
            Source = P.E5, Blocking = new List<P> {P.D4},
            Moves = new List<PossibleMove> {new(P.F4, new List<P> {P.F4}, 0)}
        };

        // Piece on E5, blocked by piece on F4, move available to D4
        yield return new PieceCaptureTestCase
        {
            Source = P.E5, Blocking = new List<P> {P.F4},
            Moves = new List<PossibleMove> {new(P.D4, new List<P> {P.D4}, 0)}
        };

        // Piece on G5, blocked by piece on F4, move available to H4
        // Note: Since G5 moving to H4 is an edge case, ensure your game rules accommodate for edge movements.
        yield return new PieceCaptureTestCase
        {
            Source = P.G5, Blocking = new List<P> {P.F4},
            Moves = new List<PossibleMove> {new(P.H4, new List<P> {P.H4}, 0)}
        };

        // Piece on G5, blocked by piece on H4, move available to F4
        yield return new PieceCaptureTestCase
        {
            Source = P.G5, Blocking = new List<P> {P.H4},
            Moves = new List<PossibleMove> {new(P.F4, new List<P> {P.F4}, 0)}
        };

        // Piece on B4, completely blocked by pieces on A3 and C3
        yield return new PieceCaptureTestCase
        {
            Source = P.B4, Blocking = new List<P> {P.A3, P.C3},
            Moves = Enumerable.Empty<PossibleMove>()
        };

        // Piece on D4, completely blocked by pieces on C3 and E3
        yield return new PieceCaptureTestCase
        {
            Source = P.D4, Blocking = new List<P> {P.C3, P.E3},
            Moves = Enumerable.Empty<PossibleMove>()
        };

        // Piece on F4, completely blocked by pieces on E3 and G3
        yield return new PieceCaptureTestCase
        {
            Source = P.F4, Blocking = new List<P> {P.E3, P.G3},
            Moves = Enumerable.Empty<PossibleMove>()
        };

        // Piece on H4, completely blocked by piece on G3
        yield return new PieceCaptureTestCase
        {
            Source = P.H4, Blocking = new List<P> {P.G3},
            Moves = Enumerable.Empty<PossibleMove>()
        };

        // Side blocked scenarios
        // Piece on B4, blocked by piece on A3, move available to C3
        yield return new PieceCaptureTestCase
        {
            Source = P.B4, Blocking = new List<P> {P.A3},
            Moves = new List<PossibleMove> {new(P.C3, new List<P> {P.C3}, 0)}
        };

        // Piece on B4, blocked by piece on C3, move available to A3
        yield return new PieceCaptureTestCase
        {
            Source = P.B4, Blocking = new List<P> {P.C3},
            Moves = new List<PossibleMove> {new(P.A3, new List<P> {P.A3}, 0)}
        };

        // Piece on D4, blocked by piece on C3, move available to E3
        yield return new PieceCaptureTestCase
        {
            Source = P.D4, Blocking = new List<P> {P.C3},
            Moves = new List<PossibleMove> {new(P.E3, new List<P> {P.E3}, 0)}
        };

        // Piece on D4, blocked by piece on E3, move available to C3
        yield return new PieceCaptureTestCase
        {
            Source = P.D4, Blocking = new List<P> {P.E3},
            Moves = new List<PossibleMove> {new(P.C3, new List<P> {P.C3}, 0)}
        };

        // Piece on F4, blocked by piece on E3, move available to G3
        yield return new PieceCaptureTestCase
        {
            Source = P.F4, Blocking = new List<P> {P.E3},
            Moves = new List<PossibleMove> {new(P.G3, new List<P> {P.G3}, 0)}
        };

        // Piece on F4, blocked by piece on G3, move available to E3
        yield return new PieceCaptureTestCase
        {
            Source = P.F4, Blocking = new List<P> {P.G3},
            Moves = new List<PossibleMove> {new(P.E3, new List<P> {P.E3}, 0)}
        };

        // Piece on A3, completely blocked by piece on B2
        yield return new PieceCaptureTestCase
        {
            Source = P.A3, Blocking = new List<P> {P.B2},
            Moves = Enumerable.Empty<PossibleMove>()
        };

        // Piece on C3, completely blocked by pieces on B2 and D2
        yield return new PieceCaptureTestCase
        {
            Source = P.C3, Blocking = new List<P> {P.B2, P.D2},
            Moves = Enumerable.Empty<PossibleMove>()
        };

        // Piece on E3, completely blocked by pieces on D2 and F2
        yield return new PieceCaptureTestCase
        {
            Source = P.E3, Blocking = new List<P> {P.D2, P.F2},
            Moves = Enumerable.Empty<PossibleMove>()
        };

        // Piece on G3, completely blocked by pieces on F2 and H2
        yield return new PieceCaptureTestCase
        {
            Source = P.G3, Blocking = new List<P> {P.F2, P.H2},
            Moves = Enumerable.Empty<PossibleMove>()
        };

        // Side blocked scenarios
        // Piece on C3, blocked by piece on B2, move available to D2
        yield return new PieceCaptureTestCase
        {
            Source = P.C3, Blocking = new List<P> {P.B2},
            Moves = new List<PossibleMove>
            {
                new(P.D2, new List<P> {P.D2}, 0)
            }
        };

        // Piece on C3, blocked by piece on D2, move available to B2
        yield return new PieceCaptureTestCase
        {
            Source = P.C3, Blocking = new List<P> {P.D2},
            Moves = new List<PossibleMove> {new(P.B2, new List<P> {P.B2}, 0)}
        };

        // Piece on E3, blocked by piece on D2, move available to F2
        yield return new PieceCaptureTestCase
        {
            Source = P.E3, Blocking = new List<P> {P.D2},
            Moves = new List<PossibleMove> {new(P.F2, new List<P> {P.F2}, 0)}
        };

        // Piece on E3, blocked by piece on F2, move available to D2
        yield return new PieceCaptureTestCase
        {
            Source = P.E3, Blocking = new List<P> {P.F2},
            Moves = new List<PossibleMove> {new(P.D2, new List<P> {P.D2}, 0)}
        };

        // Piece on G3, blocked by piece on F2, move available to H2
        // Note: The move to H2 is an edge scenario; ensure your game rules cover edge movements.
        yield return new PieceCaptureTestCase
        {
            Source = P.G3, Blocking = new List<P> {P.F2},
            Moves = new List<PossibleMove> {new(P.H2, new List<P> {P.H2}, 0)}
        };

        // Piece on G3, blocked by piece on H2, move available to F2
        yield return new PieceCaptureTestCase
        {
            Source = P.G3, Blocking = new List<P> {P.H2},
            Moves = new List<PossibleMove> {new(P.F2, new List<P> {P.F2}, 0)}
        };

        // Piece on B2, completely blocked by pieces on A1 and C1
        yield return new PieceCaptureTestCase
        {
            Source = P.B2, Blocking = new List<P> {P.A1, P.C1},
            Moves = Enumerable.Empty<PossibleMove>()
        };

        // Piece on D2, completely blocked by pieces on C1 and E1
        yield return new PieceCaptureTestCase
        {
            Source = P.D2, Blocking = new List<P> {P.C1, P.E1},
            Moves = Enumerable.Empty<PossibleMove>()
        };

        // Piece on F2, completely blocked by pieces on E1 and G1
        yield return new PieceCaptureTestCase
        {
            Source = P.F2, Blocking = new List<P> {P.E1, P.G1},
            Moves = Enumerable.Empty<PossibleMove>()
        };

        // Piece on H2, completely blocked by piece on G1
        yield return new PieceCaptureTestCase
        {
            Source = P.H2, Blocking = new List<P> {P.G1}, // H2 can only move to G1
            Moves = Enumerable.Empty<PossibleMove>()
        };

        // Side blocked scenarios
        // Piece on B2, blocked by piece on A1, move available to C1
        yield return new PieceCaptureTestCase
        {
            Source = P.B2, Blocking = new List<P> {P.A1},
            Moves = new List<PossibleMove>
            {
                new(P.C1, new List<P> {P.C1}, 0)
            }
        };

        // Piece on B2, blocked by piece on C1, move available to A1
        yield return new PieceCaptureTestCase
        {
            Source = P.B2, Blocking = new List<P> {P.C1},
            Moves = new List<PossibleMove> {new(P.A1, new List<P> {P.A1}, 0)}
        };

        // Piece on D2, blocked by piece on C1, move available to E1
        yield return new PieceCaptureTestCase
        {
            Source = P.D2, Blocking = new List<P> {P.C1},
            Moves = new List<PossibleMove> {new(P.E1, new List<P> {P.E1}, 0)}
        };

        // Piece on D2, blocked by piece on E1, move available to C1
        yield return new PieceCaptureTestCase
        {
            Source = P.D2, Blocking = new List<P> {P.E1},
            Moves = new List<PossibleMove> {new(P.C1, new List<P> {P.C1}, 0)}
        };

        // Piece on F2, blocked by piece on E1, move available to G1
        yield return new PieceCaptureTestCase
        {
            Source = P.F2, Blocking = new List<P> {P.E1},
            Moves = new List<PossibleMove> {new(P.G1, new List<P> {P.G1}, 0)}
        };

        // Piece on F2, blocked by piece on G1, move available to E1
        yield return new PieceCaptureTestCase
        {
            Source = P.F2, Blocking = new List<P> {P.G1},
            Moves = new List<PossibleMove> {new(P.E1, new List<P> {P.E1}, 0)}
        };
    }
}