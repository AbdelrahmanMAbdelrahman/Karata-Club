

using KarataClub.Domain.Common.Models;

namespace KarataClub.Application.Features.People.Instructors.Queries.GetInstructors;

public sealed record GetInstructorsQuery(
    int PageNumber = 1, int PageSize = 10,
    string SortColumn = "Name", string SortDirection = "Desc",
    string? Name = null, string? Qualifications = null
    ) : ICachedQuery<Result<PaginatedList<InstructorDto>>>
{
    public string CacheKey =>
        $"p:{PageNumber}-pa:{PageSize}-" +
        $"sc:{SortColumn}-sd:{SortDirection}-"+
        $"n:{Name}-sd:{Qualifications}-";

    public string[] Tags => ["Instructor"];

    public TimeSpan Expiration => TimeSpan.FromMinutes(10);
}
