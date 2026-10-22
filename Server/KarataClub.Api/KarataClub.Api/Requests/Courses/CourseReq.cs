namespace KarataClub.Api.Requests.Courses;

public sealed record CourseReq(string CourseName,decimal Fees,int NumberOfHours,
    int NumberOfSessions,IFormFile?Image);
