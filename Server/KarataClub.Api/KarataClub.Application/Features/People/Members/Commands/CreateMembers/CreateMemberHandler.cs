using KarataClub.Application.Features.People.Members.Dtos;
using KarataClub.Application.Features.People.Members.Mappers;

namespace KarataClub.Application.Features.People.Members.Commands.CreateMembers;

public sealed class CreateMemberHandler(IAppDbContext context, ILogger<CreateMemberHandler> logger)
    : IRequestHandler<CreateMemberCommand, Result<MemberDto>>
{
    public async Task<Result<MemberDto>> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
    {
        bool isExist = await context.People.AnyAsync(
          p=>
            p.Email == request.Email ||
            p.Phone == request.Phone, cancellationToken);
        if (isExist)
        {
            logger.LogError("Member Already Exist");
            return ApplicationErrors.MemberAlreadyExist;
        }
        Result<Person> createPersonResult = Person.Create(request.Name,request.Phone,request.Email,request.Address);
        if (createPersonResult.IsFailure)
        {
            logger.LogError(string.Join(" - ",createPersonResult.Errors));
            return createPersonResult.Errors;
        }
        var person = createPersonResult.Value;
        Result<Member> createMemberResult = Member.Create(person.Id);
        if (createMemberResult.IsFailure)
        {
            logger.LogError(string.Join(" - ",createMemberResult.Errors));
            return createMemberResult.Errors;
        }
        var member=createMemberResult.Value;
       
        member.Person = person;
        await context.Members.AddAsync(member,cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return member.ToDto();
    }
}
