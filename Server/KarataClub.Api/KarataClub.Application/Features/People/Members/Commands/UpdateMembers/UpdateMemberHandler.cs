
using Microsoft.Extensions.Caching.Hybrid;
using System.Collections.Specialized;

namespace KarataClub.Application.Features.People.Members.Commands.UpdateMembers
{
    public class UpdateMemberHandler 
        (IAppDbContext context,ILogger<UpdateMemberHandler>logger,HybridCache hybridCache)
        : IRequestHandler<UpdateMemberCommand, Result<Updated>>
    {
        public async Task<Result<Updated>> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
        {
            var member = await context.Members.Include(m => m.Person)
                .FirstOrDefaultAsync(m => m.Id == request.MemberId);
            if(member is null)
            {
                logger.LogError("No Member found for id = {MemberId}", request.MemberId);
                return ApplicationErrors.MemberNotFound(request.MemberId);
            }
            Result<Updated> updatePersonResult = member.Person.Update(request.Name,request.Email,request.Phone,request.Address);
            if (updatePersonResult.IsFailure)
            {
                logger.LogError(string.Join(" - ", updatePersonResult.Errors));
                return updatePersonResult.Errors;
            }
            await context.SaveChangesAsync(cancellationToken);
            await hybridCache.RemoveByTagAsync("Member");
            return Result.Updated;
        }
    }
}
