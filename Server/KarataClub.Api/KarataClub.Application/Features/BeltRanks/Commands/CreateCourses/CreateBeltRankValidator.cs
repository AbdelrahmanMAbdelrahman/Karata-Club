namespace KarataClub.Application.Features.BeltRanks.Commands.CreateBeltRanks;

public sealed class CreateBeltRankValidator:AbstractValidator<CreateBeltRankCommand>
{
    public CreateBeltRankValidator()
    {
        RuleFor(c=>c.RankName).Must(r=>r!=string.Empty).WithMessage("Provide a valid '{PropertyName}'");
        RuleFor(c=>c.Fees).Must(s=>s>0).WithMessage("Provide a valid '{PropertyName}'");
        RuleFor(c=>c.Priority).NotEmpty().WithMessage("Provide a valid '{PropertyName}'");
       
    }
}
