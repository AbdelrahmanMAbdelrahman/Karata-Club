
using KarataClub.Application.Features.Subscriptions.Queries.GetSubscriptions;
using KarataClub.Domain.Common.Models;

namespace KarataClub.Api.Controllers;

[ApiController()]
[Route("api/[Controller]")]
public class SubscriptionsController(IMediator mediator):ApiController
{
    [ProducesResponseType(typeof(SubscriptionDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [EndpointName(nameof(CreateSubscription))]
    [EndpointSummary("Create new Subscription ")]
    [EndpointDescription("This end point responsible for create Subscription to be able to has Subscriptionship in the system")]
    [HttpPost()]

    public async Task<IActionResult> CreateSubscription(CreateSubscriptionCommand command, CancellationToken ct)
    {
        var result = await mediator.Send(command, ct);
        return result.Match(res =>
        CreatedAtAction(nameof(GetSubscription), new { SubscriptionId = res.Id }, res), Problem);
    }

    [ProducesResponseType(typeof(SubscriptionDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [EndpointName(nameof(GetSubscription))]
    [EndpointSummary("Get Subscription By Id")]
    [EndpointDescription("Provide a valid Subscription id to fetch it's data from database ")]
    [HttpGet("{SubscriptionId}")]
    public async Task<IActionResult> GetSubscription([FromRoute] GetSubscriptionQuery query, CancellationToken ct)
    {
        var result = await mediator.Send(query, ct);
        return result.Match(res => Ok(res), Problem);
    }

    [ProducesResponseType(typeof(PaginatedList<SubscriptionDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [EndpointName(nameof(GetSubscriptions))]
    [EndpointSummary("Get Subscriptions")]
    [EndpointDescription("return a paginated list of Subscription with given creteria")]
    [HttpGet("")]
    public async Task<IActionResult> GetSubscriptions([FromQuery] GetSubscriptionsQuery query, CancellationToken ct)
    {
        var result = await mediator.Send(query, ct);
        return result.Match(res => Ok(res), Problem);
    }
}
