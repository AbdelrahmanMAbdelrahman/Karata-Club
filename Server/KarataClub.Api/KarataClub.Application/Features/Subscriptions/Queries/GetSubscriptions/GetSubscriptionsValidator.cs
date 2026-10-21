namespace KarataClub.Application.Features.Courses.Queries.GetSubscriptions;

public sealed class GetSubscriptionsValidator:AbstractValidator<GetSubscriptionsQuery>
{
    public GetSubscriptionsValidator()
    {
        RuleFor(i => i.PageNumber).Must(p => p > 0 && p < 1000).WithMessage("Provide a valid Property Name");
        RuleFor(i => i.PageNumber).Must(p => p > 0 && p < 50).WithMessage("Provide a valid Property Name");
    }
}
