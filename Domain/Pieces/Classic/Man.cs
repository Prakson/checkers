﻿namespace Domain.Pieces.Classic;

public class Man(string id, Color color) : Piece
{
    public string Id => id;
    public Color Color => color;
    public Type Type => Type.Man;
}