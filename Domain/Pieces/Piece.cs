﻿namespace Domain.Pieces;

public interface Piece
{
    public string Id { get; }
    public Color Color { get; }
    public Type Type { get; }
}

public enum Type
{
    Man, King
}
