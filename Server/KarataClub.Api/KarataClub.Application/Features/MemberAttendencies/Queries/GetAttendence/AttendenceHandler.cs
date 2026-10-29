
namespace KarataClub.Application.Features.MemberAttendencies.Queries.GetMemberAttendence;

public sealed class AttendenceHandler
    (IAppDbContext context,ILogger<AttendenceHandler> logger)
    : IRequestHandler<AttendenceQuery, Result<AttendenceDto>>
{
    public async Task<Result<AttendenceDto>> Handle(AttendenceQuery request, CancellationToken cancellationToken)
    {
        Attendence? attendence = await context.Attendancies
            .AsNoTracking()
            .Include(a => a.Session)
              .ThenInclude(s=>s.Course)
            .Where(a => a.SessionId == request.SessionId)
            .FirstOrDefaultAsync(cancellationToken);
        if(attendence is null)
        {
            logger.LogError("no attendence found with session id {SessionId}", request.SessionId);
            return ApplicationErrors.AttendenceNotFound;
        }
        attendence.Session.Course.NumberOfEnrollments = 
            await context.Enrollments.CountAsync(e=>e.CourseId==attendence.Session.CourseId,cancellationToken);

        return attendence.ToDto();
    }
}
