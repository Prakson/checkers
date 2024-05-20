﻿using System.Text.RegularExpressions;
using AIPlayers.Algorithms.Shared;
using AIPlayers.Extensions;
using AIPlayers.MessageHub;
using Contracts.Dto;
using Microsoft.Extensions.Logging;
using OpenAI.Interfaces;
using Status = Contracts.AiPlayers.AiPlayerStatus;

namespace AIPlayers.Algorithms.OpenAIGpt4Turbo;

public class OpenAiGpt4Turbo(IOpenAIService openAi, ILogger<OpenAiGpt4Turbo> logger) : AIAlgorithm
{
    private const int MaxFindMoveIterations = 3;
    private const int MaxMoveIterations = 3;

    private const bool RefereeEnabled = false;

    public async Task Move(ParticipantDto participant, BoardDto board, Services services)
    {
        var color = participant.Color;
        if (color != board.CurrentPlayer)
        {
            logger.LogInformation("It's not the AI player's turn");
            return;
        }

        var boardState = board.ToBoardState();
        var currentPlayer = $"Current player: {color}";
        
        var playerChat = new PlayerChat(openAi, services.StatusPublisher);
        var playerPrompt = $"{boardState}\n{currentPlayer}";
        
        var counter = 0;
        while (counter < MaxMoveIterations)
        {
            var (f, t) = await FindMove(playerChat, services, boardState, currentPlayer, playerPrompt);

            var from = PositionDto.FromName(f);
            var to = PositionDto.FromName(t);
            
            var result = await Move(from, to, services);

            if (!result.IsSuccessful)
            {
                playerPrompt = $"Move failed: {result.ErrorMessage}";
            }
            else
            {
                return;
            }
            
            counter++;
        }
    }



    private async Task<(string From, string To)> FindMove(PlayerChat playerChat, Services services, string boardState, string currentPlayer, string initialPlayerPrompt)
    {
        var playerPrompt = initialPlayerPrompt;
        var counter = 0;
        
        while (counter <= MaxFindMoveIterations) {
            var playerResult = await playerChat.Prompt(playerPrompt);
            if (!TryExtractMove(playerResult, out var value, out var from, out var to))
            {
                logger.LogError("Move Regex match failed for player result: {PlayerResult}", playerResult);
            }

            if (RefereeEnabled)
            {
                var refereeChat = new RefereeChat(openAi, services.StatusPublisher);
                var refereeResult = await refereeChat.Check(boardState, currentPlayer, value);
                var (valid, reason) = ExtractReason(refereeResult);
                if (!valid)
                {
                    playerPrompt = $"Suggested move is invalid: {reason}";
                }
                else
                {
                    return (from, to);
                }
            }
            else
            {
                return (from, to);
            }
            

            counter++;
        }

        return ("", "");
    }

    private async Task<(bool IsSuccessful, string ErrorMessage)> Move(PositionDto from, PositionDto to, Services services)
    {
        var move = new MoveDto(from, to);
        var result = await services.MoveClient.Move(move);
        
        await services.StatusPublisher.Publish(Status.Command("API", $"Move from {from.ToName()} to {to.ToName()}"));

        if (result.IsSuccess)
        {
            await services.StatusPublisher.Publish(Status.Successful("API", $"Move from {from.ToName()} to {to.ToName()} successful"));
            return (true, "");
        }
        var error = result.Errors.First().Message ?? "Unknown error";
        await services.StatusPublisher.Publish(Status.Failed("API", $"Move from {from.ToName()} to {to.ToName()} failed: {error}"));
        return (false, error);
    }

    private bool TryExtractMove(string input, out string raw, out string from, out string to)
    {
        const string pattern = @"(?<=\bMOVE\s)(\w+\d+)\sTO\s(\w+\d+)";
        
        var match = Regex.Match(input, pattern);

        if (!match.Success)
        {
            raw = "";
            from = "";
            to = "";
            return false;
        }

        raw = match.Value;
        from = match.Groups[1].Value;
        to = match.Groups[2].Value;
        
        return true;
    }

    private (bool IsValid, string Reason) ExtractReason(string input)
    {
        if (input.Contains("Valid: Yes"))
        {
            return (true, "");
        }
        
        const string pattern = "(?<=Reason: )(.*)";

        var match = Regex.Match(input, pattern);

        if (!match.Success)
        {
            return (false, "Unparsable reason");
        }

        return (false, match.Value);
    }
}