﻿using WebApi.Dto.Response;

namespace WebApi.Hubs;

public interface BoardHubClient
{
    public Task BoardUpdated(BoardDto board);
}