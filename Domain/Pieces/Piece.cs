﻿namespace Domain.Pieces;

public interface Piece : ObservablePiece
{
    public Square? Square { get; }
    public void Attach(Square square);
    public void Remove();
}