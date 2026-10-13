using KarataClub.Domain.People.Members.Attendencies;

namespace KarataClub.Domain.Courses.Sessions;

public sealed class Session: AuditEntity
{

    public Guid CourseId { get;private set; }
    public int NumberOfHours { get; private set; }
    public DateTime SessionDate { get; private set; }
    public Course Course { get; set; } = default!;
    public ICollection<Attendance> Attendances=default!;
    public Session(){}
    public Session(Guid id,Guid courseId,int numberOfHours,DateTime sessionDate):base(id){
    CourseId = courseId;
        NumberOfHours = numberOfHours;
        SessionDate = sessionDate;
    }
    public Result<Session> Create(Guid courseId, int numberOfHours, DateTime sessionDate)
    {
        if (courseId == Guid.Empty) return SessionErrors.InvalidCourseId;
        if (numberOfHours <= 0) return SessionErrors.InvalidNumberOfHours;
        if (sessionDate < DateTime.UtcNow) return SessionErrors.InvalidSessionDate;

        return new Session(Guid.NewGuid(),courseId,numberOfHours,sessionDate);
    }
}

