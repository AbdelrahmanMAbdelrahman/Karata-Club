using KarataClub.Domain.People.Members.Attendencies;

namespace KarataClub.Domain.Courses.Sessions;

public sealed class Session: AuditEntity
{

    public Guid CourseId { get;private set; }
    public int NumberOfHours { get; private set; }
    public DateTimeOffset SessionDate { get; private set; }
    public Course Course { get; set; } = default!;
    public ICollection<Attendance> Attendances=default!;
    public Session(){}
    public Session(Guid id,Guid courseId,int numberOfHours,DateTimeOffset sessionDate):base(id){
    CourseId = courseId;
        NumberOfHours = numberOfHours;
        SessionDate = sessionDate;
    }
    public static Result<Session> Create(Guid courseId, int numberOfHours, DateTimeOffset sessionDate)
    {
        if (courseId == Guid.Empty) return SessionErrors.InvalidCourseId;
        if (numberOfHours <= 0) return SessionErrors.InvalidNumberOfHours;

        return new Session(Guid.NewGuid(),courseId,numberOfHours,sessionDate);
    }
}

