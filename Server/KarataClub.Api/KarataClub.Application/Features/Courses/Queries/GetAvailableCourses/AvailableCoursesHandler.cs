
//namespace KarataClub.Application.Features.Courses.Queries.GetAvailableCourses;

//public sealed class AvailableCoursesHandler
//    (IAppDbContext context,ILogger<AvailableCoursesHandler>logger)
//    : IRequestHandler<AvailableCoursesQuery, Result<CourseFileDto>>
//{
//    public async Task<Result<CourseFileDto>> Handle(AvailableCoursesQuery request, CancellationToken cancellationToken)
//    {
//        bool memberExist =await context.Members.AnyAsync(m => m.Id == request.MemberId);
//        if (!memberExist) {
//            logger.LogError("NO Member found for id {MemberId}", request.MemberId);
//            return ApplicationErrors.MemberNotFound(request.MemberId);
//        }
//        //Course course=await context.Enrollments.
     
//    }
//    public string GetAvailableCourse(string courseName) {
//        if (courseName.Contains("white")) return "Yellow";
//        if (courseName.Contains("Yellow")) return "Orange";
//        if (courseName.Contains("Orange")) return "Green";
//        if (courseName.Contains("Green")) return "Blue";
//        if (courseName.Contains("Blue")) return "Purple";
//        if (courseName.Contains("Purple")) return "Brown";
//        if (courseName.Contains("Brown")) return "Black";
//        else return "White";
//    }
//}
////    White = 0,
////    Yellow=1,
////    Orange=2,
////    Green=3,
////    Blue=4,
////    Purple=5,
////    Brown=6,
////    Black=7