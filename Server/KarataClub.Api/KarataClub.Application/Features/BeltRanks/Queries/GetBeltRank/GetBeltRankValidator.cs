using KarataClub.Application.Features.BeltRanks.Queries.GetBeltRank;

namespace KarataClub.Application.Features.BeltRanks.Queries.GetCourse;

public sealed class GetBeltRankValidator:AbstractValidator<GetBeltRankQuery>
{
    public GetBeltRankValidator()
    {
        RuleFor(c => c.BeltRankId).Must(id => id != Guid.Empty).WithMessage("Must provide a valid '{PropertyName}'");
    }
}
