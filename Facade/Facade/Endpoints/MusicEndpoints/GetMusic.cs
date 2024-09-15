using System.Text.Json.Serialization;
using Common.Models;
using Facade.Abstractions.Services.Music;
using Facade.Infrastructure.Endpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Facade.Endpoints.MusicEndpoints;

public class GetMusic : EndpointBaseAsync.WithoutRequest.WithActionResult<GetMusicResponse>
{
    private readonly IMusicService _musicService;

    public GetMusic(IMusicService musicService)
    {
        _musicService = musicService;
    }
    
    [AllowAnonymous]
    [HttpGet("/api/v1/music")]
    public override async Task<ActionResult<GetMusicResponse>> HandleAsync(CancellationToken cancellationToken = default)
    {
        var result = await _musicService.GetMusic();
        if (result.IsError)
            return NotFound();
        
        return Ok(result.Value);
    }
}

public class GetMusicResponse
{
    public IEnumerable<Music> Musics { get; set; }
}