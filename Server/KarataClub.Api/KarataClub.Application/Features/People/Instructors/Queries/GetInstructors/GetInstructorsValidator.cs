using KarataClub.Application.Features.People.Instructors.Queries.GetInstructor;

namespace KarataClub.Application.Features.People.Instructors.Queries.GetInstructors;

public sealed class GetMembersValidator:AbstractValidator<GetInstructorsQuery>
{
    public GetMembersValidator()
    {
        RuleFor(i=>i.PageNumber).Must(p=>p>0 &&p<1000).WithMessage("Provide a valid Property Name");
        RuleFor(i=>i.PageNumber).Must(p=>p>0 &&p<50).WithMessage("Provide a valid Property Name");
    }
}
