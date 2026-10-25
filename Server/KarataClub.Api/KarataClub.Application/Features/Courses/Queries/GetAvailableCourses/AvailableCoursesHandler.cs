

namespace KarataClub.Application.Features.Courses.Queries.GetAvailableCourses;

public sealed class AvailableCoursesHandler
    (IAppDbContext context, ILogger<AvailableCoursesHandler> logger)
    : IRequestHandler<AvailableCoursesQuery, Result<CourseFileDto>>
{
    public async Task<Result<CourseFileDto>> Handle(AvailableCoursesQuery request, CancellationToken cancellationToken)
    {
        bool memberExist = await context.Members.AnyAsync(m => m.Id == request.MemberId);
        if (!memberExist)
        {
            logger.LogError("NO Member found for id {MemberId}", request.MemberId);
            return ApplicationErrors.MemberNotFound(request.MemberId);
        }
        CourseEnrollment? enrollment = await context.Enrollments
            .AsNoTracking()
            .Include(e=>e.Course)
            .Where(e => e.MemberId == request.MemberId)
            .OrderBy(e => e.EndDate)
            .FirstOrDefaultAsync(cancellationToken);
        if(enrollment is null)
        {
            string courseName = GetAvailableCourse("");
            CourseFile? firstCourse = await context.CourseFiles
                .Include(c => c.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Course.CourseName.Contains( courseName),cancellationToken);
            if (firstCourse is null) {
                logger.LogError("no course found with name = {CourseName}", courseName);
                return ApplicationErrors.CourseNotFound(Guid.Empty);
            }
            return firstCourse.ToDto();
        }
        string availableCourse = GetAvailableCourse(enrollment.Course.CourseName);
        CourseFile? course = await context.CourseFiles
                .Include(c=>c.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Course.CourseName.Contains(availableCourse), cancellationToken);
        if (course is null)
        {
            logger.LogError("no course found with name = {availableCourse}", availableCourse);
            return ApplicationErrors.CourseNotFound(Guid.Empty);
        }
        return course.ToDto();

    }
    public string GetAvailableCourse(string courseName)
    {
        if (courseName.Contains("white")) return "Yellow";
        if (courseName.Contains("Yellow")) return "Orange";
        if (courseName.Contains("Orange")) return "Green";
        if (courseName.Contains("Green")) return "Blue";
        if (courseName.Contains("Blue")) return "Purple";
        if (courseName.Contains("Purple")) return "Brown";
        if (courseName.Contains("Brown")) return "Black";
        else return "White";
    }
}
//    White = 0,
//    Yellow=1,
//    Orange=2,
//    Green=3,
//    Blue=4,
//    Purple=5,
//    Brown=6,
//    Black=7