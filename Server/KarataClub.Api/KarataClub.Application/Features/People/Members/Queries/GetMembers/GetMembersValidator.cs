namespace KarataClub.Application.Features.People.Members.Queries.GetMembers;

public sealed class GetMembersValidator:AbstractValidator<GetMembersQuery>
{
    public GetMembersValidator()
    {
        RuleFor(i=>i.PageNumber).Must(p=>p>0 &&p<1000).WithMessage("Provide a valid Property Name");
        RuleFor(i=>i.PageNumber).Must(p=>p>0 &&p<50).WithMessage("Provide a valid Property Name");
    }
}
