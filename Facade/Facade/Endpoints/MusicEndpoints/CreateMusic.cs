using System.Text.Json.Serialization;
using Common.Models;
using Facade.Abstractions.Services.Music;
using Facade.Infrastructure.Endpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Facade.Endpoints.MusicEndpoints;

public class CreateMusic : EndpointBaseAsync.WithRequest<CreateMusicRequest>.WithActionResult<CreateMusicResponse>
{
    private readonly IMusicService _musicService;

    public CreateMusic(IMusicService musicService)
    {
        _musicService = musicService;
    }
    
    [AllowAnonymous]
    [HttpPost("/api/v1/music")]
    public override async Task<ActionResult<CreateMusicResponse>> HandleAsync(CreateMusicRequest request, 
        CancellationToken cancellationToken = default)
    {
        var result = await _musicService.CreateMusic(request);
        return Ok(result.Value);
    }
}

public class CreateMusicResponse
{
    [JsonPropertyName("id")] public string Id { get; set; }
    [JsonPropertyName("title")] public string Title { get; set; }
    [JsonPropertyName("time")] public int Time { get; set; }
    [JsonPropertyName("played")] public bool Played { get; set; }
}

public class CreateMusicRequest
{
    [JsonPropertyName("title")] public string Title { get; set; }
}