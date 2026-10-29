using Microsoft.AspNetCore.Authorization;

namespace KarataClub.Api.Controllers;

[ApiController()]
[Route("Api/[Controller]")]
[Authorize(Roles = "Admin")]
public class EnrollmentsController(IMediator mediator) : ApiController
{
    [ProducesResponseType(typeof(EnrollmentDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [EndpointName(nameof(CreateEnrollment))]
    [EndpointSummary("Create new Enrollment ")]
    [EndpointDescription("This end piont responsible for create Enrollment to be able to has Enrollmentship in the system")]
    [HttpPost()]

    public async Task<IActionResult> CreateEnrollment([FromBody]EnrollmentCommand command, CancellationToken ct)
    {
        var result = await mediator.Send(command, ct);
        return result.Match(res =>
        CreatedAtAction(nameof(GetEnrollment), new { EnrollmentId = res.EnrollmentId }, res), Problem);
    }

    [ProducesResponseType(typeof(EnrollmentDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [EndpointName(nameof(GetEnrollment))]
    [EndpointSummary("Get Enrollment By Id")]
    [EndpointDescription("Provide a valid Enrollment id to fetch it's data from database ")]
    [HttpGet("{EnrollmentId}")]
    public async Task<IActionResult> GetEnrollment([FromRoute]EnrollmentQuery query,CancellationToken ct)
    {
        var result = await mediator.Send(query,ct);
        return result.Match(res=>Ok(res),Problem);
    }
    [ProducesResponseType(typeof(PaginatedList< EnrollmentDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [EndpointName(nameof(GetEnrollments))]
    [EndpointSummary("Get Enrollments")]
    [EndpointDescription("return a paginated list of Enrollment with given creteria")]
    [HttpGet("")]
    public async Task<IActionResult> GetEnrollments([FromQuery]EnrollmentsQuery query,CancellationToken ct)
    {
        var result = await mediator.Send(query,ct);
        return result.Match(res=>Ok(res),Problem);
    }
    
}
