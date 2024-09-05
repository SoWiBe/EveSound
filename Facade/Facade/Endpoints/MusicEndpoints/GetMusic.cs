using System.Text.Json.Serialization;
using Facade.Infrastructure.Endpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Facade.Endpoints.MusicEndpoints;

public class GetMusic : EndpointBaseAsync.WithoutRequest.WithActionResult<GetMusicResponse>
{
    [AllowAnonymous]
    [HttpGet("/api/v1/music")]
    public override async Task<ActionResult<GetMusicResponse>> HandleAsync(CancellationToken cancellationToken = default)
    {
        return Ok(new GetMusicResponse
        {
            Detail = "succes!"
        });
    }
}

public class GetMusicResponse
{
    [JsonPropertyName("detail")] public string Detail { get; set; }
}