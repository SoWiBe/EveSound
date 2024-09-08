using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Facade.Abstractions.Services.Music;
using Facade.Infrastructure.Endpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Facade.Endpoints.MusicEndpoints;

public class DeleteMusic : EndpointBaseAsync.WithRequest<DeleteMusicRequest>.WithActionResult<DeleteMusicResponse>
{
    private readonly IMusicService _musicService;

    public DeleteMusic(IMusicService musicService)
    {
        _musicService = musicService;
    }
    
    [AllowAnonymous]
    [HttpDelete(DeleteMusicRequest.Route)]
    public override async Task<ActionResult<DeleteMusicResponse>> HandleAsync([FromRoute] DeleteMusicRequest request, 
        CancellationToken cancellationToken = default)
    {
        var result = await _musicService.DeleteMusic(request);
        if (result.IsError) return StatusCode(500);
        return Ok();
    }
}

public class DeleteMusicRequest
{
    public const string Route = "/api/v1/music/{id_test}";
    
    [Required]
    [FromRoute(Name = "id_test")] 
    public string Id { get; set; }
}

public class DeleteMusicResponse
{
}