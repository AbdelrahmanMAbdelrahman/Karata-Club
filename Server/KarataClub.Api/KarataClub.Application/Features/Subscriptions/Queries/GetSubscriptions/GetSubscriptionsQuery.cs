using KarataClub.Domain.Common.Models;

namespace KarataClub.Application.Features.Subscriptions.Queries.GetSubscriptions;

public sealed record GetSubscriptionsQuery(int PageNumber = 1, int PageSize = 10,
string SortColumn = "Name", string SortDirection = "Desc",
string? Name = null, string? RankName = null,string?Notes=null
    ,bool?Active=true,
    DateTimeOffset?StartDateFrom=null,DateTimeOffset? StartDateTo=null)
    :IRequest<Result<PaginatedList< SubscriptionDto>>>
{
}
