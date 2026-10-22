namespace KarataClub.Application.Features.Courses.Queries.GetCourses;

public sealed class GetCoursesHandler
    (IAppDbContext context)
    : IRequestHandler<GetCoursesQuery, Result<PaginatedList<CourseFileDto>>>
{
    public async Task<Result<PaginatedList<CourseFileDto>>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
    {
        IQueryable<CourseFile> query = context.CourseFiles
            .Include(m => m.Course)
            .Include(m => m.UploadedFile)
            .AsNoTracking();
        query = ApplyFilter(query, request.CourseName, request.FeesFrom,request.FeesTo);
        query = ApplySorting(query, request.SortColumn, request.SortDirection);
        Result<PaginatedList<CourseFileDto>> Courses = await PaginatedList<CourseFileDto>.Create(
             query.ToDto(), request.PageNumber, request.PageSize
             );

        return Courses;
    }

    private IQueryable<CourseFile> ApplyFilter(IQueryable<CourseFile> query, string? courseName, 
         decimal? feesFrom, decimal? feesTo)
    {
        if (!string.IsNullOrWhiteSpace(courseName))
            query = query.Where(q => q.Course.CourseName.Contains(courseName));
        
        if (feesFrom.HasValue)
        {
            query=query.Where(q=>q.Course.Fees>=feesFrom.Value); 
        }
        if (feesTo.HasValue)
        {
            query=query.Where(q=>q.Course.Fees<=feesTo.Value); 
        }
        return query;
    }

    private IQueryable<CourseFile> ApplySorting(IQueryable<CourseFile> query, string sortColumn, string sortDirection)
    {
        bool desc = sortDirection.Equals("Desc", StringComparison.CurrentCultureIgnoreCase);
        query = sortColumn switch
        {
            "CourseName" => desc ? query.OrderByDescending(q => q.Course.CourseName) :
            query.OrderBy(q => q.Course.CourseName),
            "Fees" => desc ? query.OrderByDescending(q => q.Course.Fees) : query.OrderBy(q => q.Course.Fees),
            _ => desc ? query.OrderByDescending(q => q.Course.CourseName) :
            query.OrderBy(q => q.Course.CourseName)
        };
        return query;
    }

   

}
