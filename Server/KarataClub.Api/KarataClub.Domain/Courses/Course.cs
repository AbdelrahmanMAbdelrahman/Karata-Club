using KarataClub.Domain.BeltTests.BeltRanks.Enums;

namespace KarataClub.Domain.Courses;

public class Course:AuditEntity
{
    public string CourseName { get; private set; } = default!;
    public decimal Fees { get; private set; }
    public bool Active { get; private set; }
    public int NumberOfSessions { get; private set; }
    public decimal TotalHours { get; private set; }
    public DateTimeOffset StartAt { get; private set; }
    public DateTimeOffset EndAt { get; private set; }
    public Priority Priority { get; private set; }
    public ICollection<CourseEnrollment> CourseEnrollments = [];
    public ICollection<CourseFile> CourseFiles = [];
    public ICollection<Session> Session { get; private set; }
    public Course(){}
    public Course(Guid id,string courseName,decimal fees,int numberOfSessions,decimal totalHours,
        DateTimeOffset startAt,DateTimeOffset endAt,Priority priority
        ):base(id){
    CourseName = courseName;
        Fees = fees;
        Active = true;
        NumberOfSessions = numberOfSessions;
        TotalHours = totalHours;
        StartAt = startAt;
        EndAt = endAt;
        Priority = priority;
    }
    public static Result<Course> Create(string courseName, decimal fees, int numberOfSessions,
        decimal totalHours, DateTimeOffset startAt, DateTimeOffset endAt, Priority priority)
    {
        if (startAt > endAt) return CourseErrors.InvalidCourseStartDate;
        if (!Enum.IsDefined(priority)) return CourseErrors.InvalidPriority;
        if (string.IsNullOrWhiteSpace(courseName)) return CourseErrors.InvalidCourseName;
        if (fees < 0 || fees > 10000) return CourseErrors.InvalidCourseFees;
        if (numberOfSessions <= 0 || numberOfSessions > 100) return CourseErrors.InvalidCourseSessions;
        if (totalHours <= 0 || totalHours > 500) return CourseErrors.InvalidCourseTotalHours;

        return new Course(Guid.NewGuid(),courseName,fees,numberOfSessions,totalHours,
            startAt,endAt,priority);
    }
}
