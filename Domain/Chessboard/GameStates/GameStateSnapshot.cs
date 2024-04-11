﻿using Domain.Chessboard.Pieces;

namespace Domain.Chessboard.GameStates;

public record GameStateSnapshot(IEnumerable<Move> Log, Color CurrentPlayer);