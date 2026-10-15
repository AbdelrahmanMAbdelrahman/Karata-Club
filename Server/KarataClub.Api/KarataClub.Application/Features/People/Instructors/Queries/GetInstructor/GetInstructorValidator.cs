namespace KarataClub.Application.Features.People.Instructors.Queries.GetInstructor;

public sealed class GetInstructorValidator:AbstractValidator<GetInstructorQuery>
{
    public GetInstructorValidator()
    {
        RuleFor(i=>i.InstructorId).Must(id=>id!=Guid.Empty)
            .WithMessage("Must provide vaild value for '{PropertyName}'");
    }
}
