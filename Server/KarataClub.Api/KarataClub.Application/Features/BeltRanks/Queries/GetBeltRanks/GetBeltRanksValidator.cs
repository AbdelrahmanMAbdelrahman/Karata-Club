using KarataClub.Application.Features.BeltRanks.Queries.GetBeltRank;

namespace KarataClub.Application.Features.BeltRanks.Queries.GetBeltRanks;

public sealed class GetBeltRanksValidator:AbstractValidator<GetBeltRanksQuery>
{
    public GetBeltRanksValidator()
    {
        RuleFor(i => i.PageNumber).Must(p => p > 0 && p < 1000).WithMessage("Provide a valid Property Name");
        RuleFor(i => i.PageNumber).Must(p => p > 0 && p < 50).WithMessage("Provide a valid Property Name");
    }
}
