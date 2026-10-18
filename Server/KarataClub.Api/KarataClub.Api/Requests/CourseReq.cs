namespace KarataClub.Api.Requests;

public sealed record CourseReq(string CourseName,decimal Fees,int NumberOfHours,
    int NumberOfSessions,IFormFile?Image);
