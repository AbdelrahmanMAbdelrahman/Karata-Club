namespace KarataClub.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AttendenciesController(IMediator mediator):ApiController
    {
        [ProducesResponseType(typeof(AttendenceDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [EndpointName(nameof(CreateAttendence))]
        [EndpointSummary("Create new Attendence ")]
        [EndpointDescription("This end piont responsible for create Attendence to be able to has Attendenceship in the system")]
        [HttpPost()]

        public async Task<IActionResult> CreateAttendence([FromBody] CreateMemberAttendenceCommand command, CancellationToken ct)
        {
            var result = await mediator.Send(command, ct);
            return result.Match(res =>
            CreatedAtAction(nameof(GetAttendence), new { AttendenceId = res.AttendenceId }, res), Problem);
        }

        [ProducesResponseType(typeof(AttendenceDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [EndpointName(nameof(GetAttendence))]
        [EndpointSummary("Get Attendence By Id")]
        [EndpointDescription("Provide a valid Attendence id to fetch it's data from database ")]
        [HttpGet("{SessionId}")]
        public async Task<IActionResult> GetAttendence([FromRoute] AttendenceQuery query, CancellationToken ct)
        {
            var result = await mediator.Send(query, ct);
            return result.Match(res => Ok(res), Problem);
        }
        [ProducesResponseType(typeof(PaginatedList< MemberAttendenceDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [EndpointName(nameof(GetMemberAttendencies))]
        [EndpointSummary("Get Member Attendence By Id")]
        [EndpointDescription("Provide a valid session id to fetch it's data from database ")]
        [HttpGet()]
        public async Task<IActionResult> GetMemberAttendencies([FromQuery] MemberAttendenceQuery query, CancellationToken ct)
        {
            var result = await mediator.Send(query, ct);
            return result.Match(res => Ok(res), Problem);
        }
    }
}
