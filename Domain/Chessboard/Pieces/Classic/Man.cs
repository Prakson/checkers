﻿using Domain.Shared;

namespace Domain.Chessboard.Pieces.Classic;

public class Man(string id, Color color) : Piece
{
    public string Id => id;
    public Color Color => color;
    public Type Type => Type.Man;
}