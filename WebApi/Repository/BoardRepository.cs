﻿using Domain;

namespace WebApi.Repository;

public interface BoardRepository
{
    public Task<Board> Get();
    public void Save(Board board);
}