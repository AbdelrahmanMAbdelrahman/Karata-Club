

using KarataClub.Domain.Common.Models;

namespace KarataClub.Application.Features.People.Instructors.Queries.GetInstructors;

public sealed record GetInstructorsQuery(
    int PageNumber=1,int PageSize=10,
    string SortColumn="Name",string SortDirection="Desc",
    string?Name=null,string? Qualifications=null
    ):IRequest<Result<PaginatedList<InstructorDto>>>
{
}
