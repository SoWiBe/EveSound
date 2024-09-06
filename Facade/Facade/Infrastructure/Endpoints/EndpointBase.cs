using Facade.Abstractions.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Facade.Infrastructure.Endpoints;

[Authorize]
[ApiController]
public abstract class EndpointBase : ControllerBase
{
    protected string Token => Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);
    protected string DomainName => HttpContext.Request.GetDisplayUrl().Split(HttpContext.Request.Path.Value)[0];

    [NonAction]
    public virtual ActionResult GetActionResult(IErrorOr entity)
    {
        var error = entity.Errors.First();
        
        if (error.Description.Equals("Can not update with same login"))
            return BadRequest(error);
        
        return error.Type switch
        {
            ErrorType.BadRequest => BadRequest(error),
            ErrorType.Conflict => Conflict(error),
            ErrorType.NotFound => NotFound(error),
            ErrorType.Unauthorized => Unauthorized(error),
            ErrorType.UnprocessableContent => UnprocessableEntity(error),
        };
    }
}