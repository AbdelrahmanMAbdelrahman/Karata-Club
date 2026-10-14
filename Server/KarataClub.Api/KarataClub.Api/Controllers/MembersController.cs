using KarataClub.Application.Features.People.Members.Commands.CreateMembers;
using KarataClub.Application.Features.People.Members.Commands.UpdateMembers;
using KarataClub.Application.Features.People.Members.Dtos;
using KarataClub.Application.Features.People.Members.Queries.GetMembersQuery;

namespace KarataClub.Api.Controllers
{
    [ApiController()]
    [Route("Api/[Controller]")]

    public class MembersController(IMediator mediator) : ApiController
    {
        [ProducesResponseType(typeof(MemberDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [EndpointName(nameof(CreateMember))]
        [EndpointSummary("Create new member ")]
        [EndpointDescription("This end piont responsible for create member to be able to has membership in the system")]
        [HttpPost()]

        public async Task<IActionResult> CreateMember(CreateMemberCommand command, CancellationToken ct)
        {
            var result = await mediator.Send(command, ct);
            return result.Match(res =>
            CreatedAtAction(nameof(GetMember), new { MemberId = res.Id }, res), Problem);
        }

        [ProducesResponseType(typeof(MemberDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [EndpointName(nameof(GetMember))]
        [EndpointSummary("Get Member By Id")]
        [EndpointDescription("Provide a valid member id to fetch it's data from database ")]
        [HttpGet("{MemberId}")]
        public async Task<IActionResult> GetMember([FromRoute]GetMemberQuery query,CancellationToken ct)
        {
            var result = await mediator.Send(query,ct);
            return result.Match(res=>Ok(res),Problem);
        }
        [ProducesResponseType(typeof(MemberDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [EndpointName(nameof(UpdateMember))]
        [EndpointSummary("update Member By Id")]
        [EndpointDescription("Provide a valid member id to update it's data from database ")]
        [HttpPut("{MemberId}")]
        public async Task<IActionResult> UpdateMember([FromRoute]Guid MemberId,[FromBody]CreateMemberCommand command,CancellationToken ct)
        {
            UpdateMemberCommand updateCommand = 
                new UpdateMemberCommand(MemberId,command.Name,command.Phone,
                command.Email,command.Address);
            var result = await mediator.Send(updateCommand,ct);
            return result.Match(res=>Ok(res),Problem);
        }
    }
}
