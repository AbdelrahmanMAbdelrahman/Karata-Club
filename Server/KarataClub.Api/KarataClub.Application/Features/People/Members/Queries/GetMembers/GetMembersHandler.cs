using KarataClub.Domain.Common.Models;

namespace KarataClub.Application.Features.People.Members.Queries.GetMembers;

public sealed class GetMembersHandler
    (IAppDbContext context,ILogger<GetMembersHandler>logger)
    : IRequestHandler<GetMembersQuery, Result<PaginatedList<MemberDto>>>
{
    public async Task<Result<PaginatedList<MemberDto>>> Handle(GetMembersQuery request, CancellationToken cancellationToken)
    {
       IQueryable<Member> query= context.Members
            .Include(m=>m.Person)
            .Include(m=>m.LastBeltRank)
            .AsNoTracking();
        query = ApplyFilter(query,request.Name,request.RankName);
        query = ApplySorting(query,request.SortColumn,request.SortDirection);
       Result< PaginatedList<MemberDto>> Members =await PaginatedList<MemberDto>.Create(
            query.ToDto(),request.PageNumber,request.PageSize
            );

        return Members;
    }

    private IQueryable<Member> ApplySorting(IQueryable<Member> query, string sortColumn, string sortDirection)
    {
        bool desc = sortDirection.Equals("Desc",StringComparison.CurrentCultureIgnoreCase);
        query = sortColumn switch
        {
            "Name" => desc ? query.OrderByDescending(q => q.Person.Name) : query.OrderBy(q => q.Person.Name),
            "Email" => desc ? query.OrderByDescending(q => q.Person.Email) : query.OrderBy(q => q.Person.Email),
            "Phone" => desc ? query.OrderByDescending(q => q.Person.Phone) : query.OrderBy(q => q.Person.Phone),
            "Address" => desc ? query.OrderByDescending(q => q.Person.Address) : query.OrderBy(q => q.Person.Address),
            "RankName" => desc ? query.OrderByDescending(q => q.LastBeltRank.RankName) : query.OrderBy(q => q.LastBeltRank.RankName),
            _=> desc ? query.OrderByDescending(q => q.Person.Name) : query.OrderBy(q => q.Person.Name)
        };
        return query;
    }

    private IQueryable<Member> ApplyFilter(IQueryable<Member> query, string? name, string? qualifications)
    {
        query = query.Where(m => m.Active);
        if (!string.IsNullOrWhiteSpace(name))
            query = query.Where(q=>q.Person.Name.Contains( name));
        if (!string.IsNullOrWhiteSpace(qualifications))
            query = query.Where(q => q.LastBeltRank.RankName!.Contains(qualifications));
        return query;
    }
}
