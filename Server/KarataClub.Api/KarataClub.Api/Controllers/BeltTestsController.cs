using KarataClub.Application.Features.BeltTests.Commands.PassBeltTest;
using Microsoft.AspNetCore.Authorization;

namespace KarataClub.Api.Controllers;

[ApiController()]
[Route("Api/[Controller]")]
[Authorize(Roles = "Admin")]

public class BeltTestsController(IMediator mediator) : ApiController
{
    [ProducesResponseType(typeof(BeltTestDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [EndpointName(nameof(CreateBeltTest))]
    [EndpointSummary("Create new BeltTest ")]
    [EndpointDescription("This end piont responsible for create BeltTest to be able to has BeltTestship in the system")]
    [HttpPost()]

    public async Task<IActionResult> CreateBeltTest([FromBody]CreateBeltTestCommand command, CancellationToken ct)
    {
        var result = await mediator.Send(command, ct);
        return result.Match(res =>
        CreatedAtAction(nameof(GetBeltTest), new { BeltTestId = res.BeltTestId }, res), Problem);
    }

    [ProducesResponseType(typeof(BeltTestDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [EndpointName(nameof(GetBeltTest))]
    [EndpointSummary("Get BeltTest By Id")]
    [EndpointDescription("Provide a valid BeltTest id to fetch it's data from database ")]
    [HttpGet("{BeltTestId}")]
    public async Task<IActionResult> GetBeltTest([FromRoute]BeltTestQuery query,CancellationToken ct)
    {
        var result = await mediator.Send(query,ct);
        return result.Match(res=>Ok(res),Problem);
    }
    [ProducesResponseType( StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [EndpointName(nameof(PassBeltTest))]
    [EndpointSummary("update BeltTest By Id")]
    [EndpointDescription("Provide a valid BeltTest id to set belt passed ")]
    [HttpPut("{BeltTestId}/Pass")]
    public async Task<IActionResult> PassBeltTest([FromRoute]PassBeltCommand command,CancellationToken ct)
    {
        var result = await mediator.Send(command,ct);
        return result.Match(res=>NoContent(),Problem);
    }
    //[ProducesResponseType(typeof(PaginatedList< BeltTestDto>), StatusCodes.Status200OK)]
    //[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    //[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    //[EndpointName(nameof(GetBeltTests))]
    //[EndpointSummary("Get BeltTests")]
    //[EndpointDescription("return a paginated list of BeltTest with given creteria")]
    //[HttpGet("")]
    //public async Task<IActionResult> GetBeltTests([FromQuery]MemberBeltTestsQuery query,CancellationToken ct)
    //{
    //    var result = await mediator.Send(query,ct);
    //    return result.Match(res=>Ok(res),Problem);
    //}
    
}
