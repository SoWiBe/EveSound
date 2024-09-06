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
        return Ok(new CreateMusicResponse());
    }
}

public class CreateMusicResponse
{
    public Music Music { get; set; }
}

public class CreateMusicRequest
{
    [JsonPropertyName("title")] public string Title { get; set; }
}