namespace KarataClub.Application.Features.BeltTests.Commands.CreateBeltTests;

public sealed class CreateBeltTestValidator:AbstractValidator<CreateBeltTestCommand>
{
    public CreateBeltTestValidator()
    {
        RuleFor(bt=>bt.BeltRankId).Must(id=>id!=Guid.Empty).WithMessage("Must Provide a valid '{PropertyName}'");
        RuleFor(bt=>bt.InstructorId).Must(id=>id!=Guid.Empty).WithMessage("Must Provide a valid '{PropertyName}'");
        RuleFor(bt=>bt.MemberId).Must(id=>id!=Guid.Empty).WithMessage("Must Provide a valid '{PropertyName}'");
        RuleFor(bt=>bt.Notes).MaximumLength(255).WithMessage("Must Provide a valid '{PropertyName}' with length up to '{MinValue}'");
    }
}
