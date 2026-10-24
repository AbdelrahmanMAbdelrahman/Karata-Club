namespace KarataClub.Application.Features.BeltRanks.Queries.GetAllowedBeltRank;

public sealed class AllowedBeltRankValidator:AbstractValidator<AllowedBeltRankQuery>
{
    public AllowedBeltRankValidator()
    {
        RuleFor(b=>b.MemberId).Must(id=>id!=Guid.Empty).WithMessage("Provide a valid value for '{PropertyName}'");
    }
}
