
namespace KarataClub.Application.Features.MemberAttendencies.Commands.TakMemberAttendence;

public sealed class TakeMemberAttendenceHandler
    (IAppDbContext context,ILogger<TakeMemberAttendenceHandler> logger)
    : IRequestHandler<TakMemberAttendenceCommand, Result<Updated>>
{
    public async Task<Result<Updated>> Handle(TakMemberAttendenceCommand request, CancellationToken cancellationToken)
    {
        List<Guid> memberIds = request.MemberAttendence.Keys.ToList();
        List<MemberAttendence> memberAttendencies = await context.MemberAttendencies
              .Where(ma => ma.SessionId == request.SessionId&&
              memberIds.Contains(ma.MemberId))
              .ToListAsync(cancellationToken);
        if (memberAttendencies.Count == 0)
        {
            logger.LogWarning("NO Member Found");
            return ApplicationErrors.AttendenceNotFound;
        }
      foreach(MemberAttendence attendence in memberAttendencies)
        {
          Result<Updated>takeAttendenceResult=  attendence.SetExist(request.MemberAttendence[attendence.MemberId]);
            if (takeAttendenceResult.IsFailure)
            {
                logger.LogError(string.Join(" - ", takeAttendenceResult.Errors));
                return takeAttendenceResult.Errors;
            }
        }
      await context.SaveChangesAsync(cancellationToken);
        return Result.Updated;
    }
}
