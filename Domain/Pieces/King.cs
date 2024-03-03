﻿namespace Domain.Pieces;

public class King(string id, Color color) : Piece
{
    public string Id => id;
    public Color Color => color;
    public string Type => "king";
}