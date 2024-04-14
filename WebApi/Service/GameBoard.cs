﻿using Domain.Chessboard;
using Domain.Chessboard.PieceMoves;
using Domain.Shared;
using FluentResults;
using WebApi.Service.Errors;

namespace WebApi.Service;

public class GameBoard(BoardRepository boardRepository, string boardId)
{
    public async Task<Result<Board>> Get(Player player)
    {
        var boardResult = await GetBoard(player);
        if (boardResult.IsFailed)
        {
            return Result.Fail(boardResult.Errors); 
        }

        var board = boardResult.Value;
        return Result.Ok(board);
    }

    public async Task<Result<IEnumerable<PossibleMove>>> PossibleMoves(Player player, Position position)
    {
        var boardResult = await GetBoard(player);
        if (boardResult.IsFailed)
        {
            return Result.Fail(boardResult.Errors); 
        }
    
        var board = boardResult.Value;
        var moves = board.PossibleMoves(player, position);
        if (moves.IsFailed)
        {
            return Result.Fail(new PossibleMovesUnavailable(moves.Errors));
        }

        return Result.Ok(moves.Value);
    }

    public async Task<Result<Board>> Move(Player player, Position from, Position to)
    {
        var boardResult = await GetBoard(player);
        if (boardResult.IsFailed)
        {
            return Result.Fail(boardResult.Errors); 
        }

        var board = boardResult.Value;
        var result = board.Move(player, from, to);
        if (result.IsFailed)
        {
            return Result.Fail(new MoveFailed(result.Errors));
        }

        await boardRepository.Save(board);

        return Result.Ok(board); 
    }
    
    private async Task<Result<Board>> GetBoard(Player player)
    {
        var board = await boardRepository.Get(boardId);
        if (board is null)
        {
            return Result.Fail(new BoardNotFound(boardId));    
        }

        var participant = board.Participants.For(player);
        if (participant is null)
        {
            return Result.Fail(new NoAccess(player, boardId));
        }

        return Result.Ok(board);
    }
}