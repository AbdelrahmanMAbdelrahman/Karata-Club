namespace KarataClub.Application.Features.Courses.Enrollments.Queries.GetEnrollments;

public sealed class EnrollmentsHandler
    (IAppDbContext context,ILogger<EnrollmentsHandler>logger): IRequestHandler<EnrollmentsQuery, Result<PaginatedList<EnrollmentDto>>>
{
    public async Task<Result<PaginatedList<EnrollmentDto>>> Handle(EnrollmentsQuery request, CancellationToken cancellationToken)
    {
        IQueryable<CourseEnrollment> query = context.Enrollments
             .Include(e => e.Course)
             .Include(e => e.Member)
               .ThenInclude(m=>m.Person)
             .AsNoTracking();
        query = ApplyFilter(query, request.CourseName,request.MemberName, request.FeesFrom, request.FeesTo);
        query = ApplySorting(query, request.SortColumn, request.SortDirection);
        Result<PaginatedList<EnrollmentDto>> Courses = await PaginatedList<EnrollmentDto>.Create(
             query.ToDto(), request.PageNumber, request.PageSize
             );

        return Courses;
    }

    private IQueryable<CourseEnrollment> ApplyFilter(IQueryable<CourseEnrollment> query, string? courseName,
        string? memberName,decimal? feesFrom, decimal? feesTo)
    {
        if (!string.IsNullOrWhiteSpace(courseName))
            query = query.Where(q => q.Course.CourseName.Contains(courseName));
        
        if (!string.IsNullOrWhiteSpace(memberName))
            query = query.Where(q => q.Member.Person.Name.Contains(memberName));

        if (feesFrom.HasValue)
        {
            query = query.Where(q => q.Course.Fees >= feesFrom.Value);
        }
        if (feesTo.HasValue)
        {
            query = query.Where(q => q.Course.Fees <= feesTo.Value);
        }
        return query;
    }

    private IQueryable<CourseEnrollment> ApplySorting(IQueryable<CourseEnrollment> query, string sortColumn, string sortDirection)
    {
        bool desc = sortDirection.Equals("Desc", StringComparison.CurrentCultureIgnoreCase);
        query = sortColumn switch
        {
            "CourseName" => desc ? query.OrderByDescending(q => q.Course.CourseName) :
            query.OrderBy(q => q.Course.CourseName),
            "MemberName" => desc ? query.OrderByDescending(q => q.Member.Person.Name) :
            query.OrderBy(q => q.Member.Person.Name),
            "Fees" => desc ? query.OrderByDescending(q => q.Course.Fees) : query.OrderBy(q => q.Course.Fees),
            _ => desc ? query.OrderByDescending(q => q.Course.CourseName) :
            query.OrderBy(q => q.Course.CourseName)
        };
        return query;
    }

}
