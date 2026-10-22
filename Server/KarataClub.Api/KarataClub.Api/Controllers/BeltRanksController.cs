namespace KarataClub.Api.Controllers;

[ApiController()]
[Route("Api/[Controller]")]

public class BeltRanksController(IMediator mediator) : ApiController
{
    [ProducesResponseType(typeof(BeltRankFileDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [EndpointName(nameof(CreateBeltRank))]
    [EndpointSummary("Create new BeltRanks ")]
    [EndpointDescription("This end piont responsible for create Belt Ranks ")]
    [HttpPost()]

    public async Task<IActionResult> CreateBeltRank([FromForm] BeltRankReq req , CancellationToken ct)
    {
        CreateBeltRankCommand command = new CreateBeltRankCommand(req.RankName,req.TestFees,req.Priority,
            req.Image.OpenReadStream(),req.Image.ContentType,req.Image.FileName);
        var result = await mediator.Send(command, ct);
        return result.Match(res =>
        CreatedAtAction(nameof(GetBeltRank), new { BeltRankId = res.BeltRank.Id }, res), Problem);
    }
    [ProducesResponseType(typeof(BeltRankFileDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [EndpointName(nameof(GetBeltRank))]
    [EndpointSummary("Get BeltRank By Id")]
    [EndpointDescription("This end point responsible for get BeltRanks by providing it's id")]
    [HttpGet("{BeltRankId}")]
    public async Task<IActionResult> GetBeltRank([FromRoute]GetBeltRankQuery query,CancellationToken ct)
    {
        var result=await mediator.Send(query, ct);  
        return result.Match(res=>Ok(res),Problem);
    }
    [ProducesResponseType(typeof(PaginatedList< BeltRankFileDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [EndpointName(nameof(GetBeltRanks))]
    [EndpointSummary("Get BeltRanks")]
    [EndpointDescription("This end point responsible for get BeltRanks Filteration , Sorting Options")]
    [HttpGet("")]
    public async Task<IActionResult> GetBeltRanks([FromQuery]GetBeltRanksQuery query,CancellationToken ct)
    {
        var result=await mediator.Send(query, ct);  
        return result.Match(res=>Ok(res),Problem);
    }

    //[ProducesResponseType(typeof(PaginatedList< BeltRankFileDto>), StatusCodes.Status200OK)]
    //[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    //[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    //[EndpointName(nameof(GetBeltRankss))]
    //[EndpointSummary("Get BeltRankss")]
    //[EndpointDescription("return a paginated list of BeltRanks with given creteria")]
    //[HttpGet("")]
    //public async Task<IActionResult> GetBeltRankss([FromQuery]GetBeltRanksQuery query,CancellationToken ct)
    //{
    //    var result = await mediator.Send(query,ct);
    //    return result.Match(res=>Ok(res),Problem);
    //}
    //[ProducesResponseType(typeof(BeltRankFileDto), StatusCodes.Status200OK)]
    //[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    //[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    //[EndpointName(nameof(UpdateBeltRanks))]
    //[EndpointSummary("update BeltRanks By Id")]
    //[EndpointDescription("Provide a valid BeltRanks id to update it's data from database ")]
    //[HttpPut("{BeltRanksId}")]
    //public async Task<IActionResult> UpdateBeltRanks([FromRoute]Guid BeltRanksId,[FromBody]CreateBeltRankCommand command,CancellationToken ct)
    //{
    //    UpdateBeltRankCommand updateCommand = 
    //        new UpdateBeltRanksCommand(BeltRanksId,command.Name,command.Phone,
    //        command.Email,command.Address);
    //    var result = await mediator.Send(updateCommand,ct);
    //    return result.Match(res=>Ok(res),Problem);
    //}
}
