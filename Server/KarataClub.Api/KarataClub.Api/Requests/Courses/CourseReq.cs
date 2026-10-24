using KarataClub.Domain.BeltTests.BeltRanks.Enums;

namespace KarataClub.Api.Requests.Courses;

public sealed record CourseReq(string CourseName,decimal Fees,int NumberOfHours,
    int NumberOfSessions,DateTimeOffset StartAt,Priority Priority,IFormFile?Image);
