using KarataClub.Domain.Common.Models;

namespace KarataClub.Application.Features.People.Instructors.Queries.GetInstructors;

public sealed class GetInstructorsHandler
    (IAppDbContext context,ILogger<GetInstructorsHandler>logger)
    : IRequestHandler<GetInstructorsQuery, Result<PaginatedList<InstructorDto>>>
{
    public async Task<Result<PaginatedList<InstructorDto>>> Handle(GetInstructorsQuery request, CancellationToken cancellationToken)
    {
       IQueryable<Instructor> query= context.Instructors
            .Include(i=>i.Person)
            .AsNoTracking();
        query = ApplyFilter(query,request.Name,request.Qualifications);
        query = ApplySorting(query,request.SortColumn,request.SortDirection);
       Result< PaginatedList<InstructorDto>> instructors =await PaginatedList<InstructorDto>.Create(
            query.ToDto(),request.PageNumber,request.PageSize
            );

        return instructors;
    }

    private IQueryable<Instructor> ApplySorting(IQueryable<Instructor> query, string sortColumn, string sortDirection)
    {
        bool desc = sortDirection.Equals("Desc",StringComparison.CurrentCultureIgnoreCase);
        query = sortColumn switch
        {
            "Name" => desc ? query.OrderByDescending(q => q.Person.Name) : query.OrderBy(q => q.Person.Name),
            "Email" => desc ? query.OrderByDescending(q => q.Person.Email) : query.OrderBy(q => q.Person.Email),
            "Phone" => desc ? query.OrderByDescending(q => q.Person.Phone) : query.OrderBy(q => q.Person.Phone),
            "Address" => desc ? query.OrderByDescending(q => q.Person.Address) : query.OrderBy(q => q.Person.Address),
            "Qualifications" => desc ? query.OrderByDescending(q => q.Qualifications) : query.OrderBy(q => q.Qualifications),
            _=> desc ? query.OrderByDescending(q => q.Person.Name) : query.OrderBy(q => q.Person.Name)
        };
        return query;
    }

    private IQueryable<Instructor> ApplyFilter(IQueryable<Instructor> query, string? name, string? qualifications)
    {
        if (!string.IsNullOrWhiteSpace(name))
            query = query.Where(q=>q.Person.Name.Contains( name));
        if (!string.IsNullOrWhiteSpace(qualifications))
            query = query.Where(q => q.Qualifications!.Contains(qualifications));
        return query;
    }
}
