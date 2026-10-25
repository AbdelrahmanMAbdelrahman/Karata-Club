using KarataClub.Application.Features.Sessions.Commands.CreateSession;
using KarataClub.Application.Features.Sessions.Dtos;
using KarataClub.Application.Features.Sessions.Queries.GetSession;
using KarataClub.Application.Features.Sessions.Queries.GetSessions;

namespace KarataClub.Api.Controllers;
[ApiController]
[Route("Api/[Controller]")]
public class SessionsController(IMediator mediator) : ApiController
{

    [ProducesResponseType(typeof(SessionDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [EndpointName(nameof(CreateSession))]
    [EndpointSummary("Create new Session ")]
    [EndpointDescription("This end point responsible for create Session ")]
    [HttpPost()]
    public async Task<IActionResult> CreateSession([FromBody] CreateSessionCommand command, CancellationToken ct)
    {
        var result = await mediator.Send(command, ct);
        return result.Match(res =>
        CreatedAtAction(nameof(GetSession), new { SessionId = res.SessionId }, res), Problem);
    }
    [ProducesResponseType(typeof(SessionDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [EndpointName(nameof(GetSession))]
    [EndpointSummary("Get Session By Id")]
    [EndpointDescription("Provide a valid Session id to fetch it's data from database ")]
    [HttpGet("{SessionId}")]
    public async Task<IActionResult> GetSession([FromRoute] SessionQuery query, CancellationToken ct)
    {
        var result = await mediator.Send(query, ct);
        return result.Match(res => Ok(res), Problem);
    }
    //[ProducesResponseType(typeof(Updated), StatusCodes.Status204NoContent)]
    //[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    //[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    //[EndpointName(nameof(UpdateSession))]
    //[EndpointSummary("update Session By Id")]
    //[EndpointDescription("Provide a valid Session id to update it's data from database ")]
    //[HttpPut("{SessionId}")]
    //public async Task<IActionResult> UpdateSession([FromRoute] Guid SessionId, [FromBody] CreateSessionCommand command, CancellationToken ct)
    //{
    //    UpdateSessionCommand updateCommand =
    //        new UpdateSessionCommand(SessionId, command.Name, command.Email,
    //        command.Phone, command.Address, command.Qualifications);
    //    var result = await mediator.Send(updateCommand, ct);
    //    return result.Match(res => Ok(res), Problem);
    //}
    [ProducesResponseType(typeof(PaginatedList<SessionDto>), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [EndpointName(nameof(GetSessions))]
    [EndpointSummary("Get Sessions")]
    [EndpointDescription("Get paginated list of Sessions with filter ,sorting")]
    [HttpGet("")]
    public async Task<IActionResult> GetSessions([FromQuery] SessionsQuery query, CancellationToken ct)
    {
        var result = await mediator.Send(query, ct);
        return result.Match(res => Ok(res), Problem);
    }
}
