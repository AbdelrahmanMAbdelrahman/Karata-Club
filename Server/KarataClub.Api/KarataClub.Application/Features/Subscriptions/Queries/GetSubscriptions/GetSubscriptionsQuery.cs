using KarataClub.Application.Features.Courses.Dtos;
using KarataClub.Domain.Common.Models;

namespace KarataClub.Application.Features.Courses.Queries.GetSubscriptions;

public sealed record GetSubscriptionsQuery(int PageNumber = 1, int PageSize = 10,
string SortColumn = "Name", string SortDirection = "Asc",
string? Name = null, string? RankName = null, DateTime? FromDate = null, DateTime? ToDate = null
    )
    : ICachedQuery<Result<PaginatedList<SubscriptionDto>>>
{
    public string CacheKey =>
        $"p:{PageNumber}-pa:{PageSize}-" +
        $"sc:{SortColumn}-sd:{SortDirection}-"+
        $"n:{Name}-rn:{RankName}-"+
        $"fd:{FromDate}-td:{ToDate}-";

    public string[] Tags => ["Subscription"];

    public TimeSpan Expiration => TimeSpan.FromMinutes(10);
}
