using Microsoft.AspNetCore.Authorization;

namespace KarataClub.Api.Controllers;
[ApiController]
[Route("Api/[Controller]")]
[Authorize(Roles = "Admin")]
public class InstructorsController(IMediator mediator):ApiController
{

    [ProducesResponseType(typeof(InstructorDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [EndpointName(nameof(CreateInstructor))]
    [EndpointSummary("Create new Instructor ")]
    [EndpointDescription("This end point responsible for create Instructor ")]
    [HttpPost()]
    public async Task<IActionResult> CreateInstructor([FromBody]CreateInstructorCommand command, CancellationToken ct)
    {
        var result = await mediator.Send(command, ct);
        return result.Match(res =>
        CreatedAtAction(nameof(GetInstructor), new { InstructorId = res.InstructorId }, res), Problem);
    }
    [ProducesResponseType(typeof(InstructorDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [EndpointName(nameof(GetInstructor))]
    [EndpointSummary("Get Instructor By Id")]
    [EndpointDescription("Provide a valid Instructor id to fetch it's data from database ")]
    [HttpGet("{InstructorId}")]
    public async Task<IActionResult> GetInstructor([FromRoute] GetInstructorQuery query, CancellationToken ct)
    {
        var result = await mediator.Send(query, ct);
        return result.Match(res => Ok(res), Problem);
    }
    [ProducesResponseType(typeof(Updated), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [EndpointName(nameof(UpdateInstructor))]
    [EndpointSummary("update Instructor By Id")]
    [EndpointDescription("Provide a valid Instructor id to update it's data from database ")]
    [HttpPut("{InstructorId}")]
    public async Task<IActionResult> UpdateInstructor([FromRoute] Guid InstructorId, [FromBody] CreateInstructorCommand command, CancellationToken ct)
    {
        UpdateInstructorCommand updateCommand =
            new UpdateInstructorCommand(InstructorId, command.Name, command.Email,
            command.Phone, command.Address, command.Qualifications);
        var result = await mediator.Send(updateCommand, ct);
        return result.Match(res => Ok(res), Problem);
    }
    [ProducesResponseType(typeof(PaginatedList<InstructorDto>), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [EndpointName(nameof(GetInstructors))]
    [EndpointSummary("Get Instructors")]
    [EndpointDescription("Get paginated list of instructors with filter ,sorting")]
    [HttpGet("")]
    public async Task<IActionResult> GetInstructors([FromQuery]  GetInstructorsQuery query, CancellationToken ct)
    {
        var result = await mediator.Send(query, ct);
        return result.Match(res => Ok(res), Problem);
    }
}
