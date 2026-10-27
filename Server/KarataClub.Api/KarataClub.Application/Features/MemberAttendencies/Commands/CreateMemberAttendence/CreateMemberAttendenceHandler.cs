namespace KarataClub.Application.Features.MemberAttendencies.Commands.CreateMemberAttendence;

public sealed class CreateMemberAttendenceHandler(
    IAppDbContext context, ILogger<CreateMemberAttendenceHandler> logger)
    : IRequestHandler<CreateMemberAttendenceCommand, Result<AttendenceDto>>
{
    async Task<Result<AttendenceDto>> IRequestHandler<CreateMemberAttendenceCommand,
        Result<AttendenceDto>>.Handle(CreateMemberAttendenceCommand request, CancellationToken cancellationToken)
    {
        Session? session = await context.Sessions
            .Include(s=>s.Course)
             .AsNoTracking()
             .FirstOrDefaultAsync(s => s.Id == request.SessionId,cancellationToken);
        if (session is null)
        {
            logger.LogError("no session found with id : {sessionId}", request.SessionId);
            return ApplicationErrors.SessionNotFound(request.SessionId);
        }

        bool isSessionAlreadyasAttendence=await context.Attendancies
            .AnyAsync(a=>a.SessionId==session.Id,cancellationToken);
        if (isSessionAlreadyasAttendence) {
            logger.LogError("Attendence already exist");
            return ApplicationErrors.AttendenceAlreadyExist;
        }

        Result<Attendence> createAttendenceResult = Attendence.Create(request.SessionId);
        if (createAttendenceResult.IsFailure)
        {
            logger.LogError(string.Join(" - ", createAttendenceResult.Errors));
            return createAttendenceResult.Errors;
        }

        Attendence attendence = createAttendenceResult.Value;
        List<Guid> membersIds = await context.Enrollments
            .AsNoTracking()
            .Where(e => e.CourseId == session.CourseId && e.Course.EndAt>DateTime.UtcNow &&
            e.Member.Active)
            .Select(e => e.MemberId)
            .ToListAsync(cancellationToken);
        List<MemberAttendence> memberAttendencies = [];
        Result<MemberAttendence> createMemberAttendence;
        foreach (Guid id in membersIds)
        {
            createMemberAttendence = MemberAttendence.Create(id, session.Id, attendence.Id);
            if (createMemberAttendence.IsFailure)
            {
                logger.LogError(string.Join(" - ", createMemberAttendence.Errors));
                return createMemberAttendence.Errors;
            }
            memberAttendencies.Add(createMemberAttendence.Value);
        }

        await context.Attendancies.AddAsync(attendence, cancellationToken);
        context.MemberAttendencies.AddRange(memberAttendencies);
        await context.SaveChangesAsync(cancellationToken);
        attendence.Session = session;
        attendence.MemberAttendencies = await context.MemberAttendencies
            .AsNoTracking()
            .Include(ma=>ma.Member)
             .ThenInclude(m=>m.Person)
            .Include(ma=>ma.Member)
              .ThenInclude(m=>m.LastBeltRank)
            .Where(ma=>membersIds.Contains(ma.MemberId)).ToListAsync(cancellationToken);
        return attendence.ToDto();
    }
}
