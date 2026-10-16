namespace KarataClub.Domain.Subscriptions;

internal  sealed class SubscriptionErrors:AuditEntity
{
    
    internal static Error InvalidSubscriptionFees=Error.Validation("SubscriptionErrors.InvalidSubscriptionFees", "InvalidSubscriptionFees");
    internal static Error InvalidEndDate=Error.Validation("SubscriptionErrors.InvalidEndDate", "InvalidEndDate");
    internal static Error InvalidStartDate=Error.Validation("SubscriptionErrors.InvalidStartDate", "InvalidStartDate");
    internal static Error InvalidMemberId=Error.Validation("SubscriptionErrors.InvalidMemberId", "Invalid Member Id");
    internal static Error InvalidPaymentId = Error.Validation("SubscriptionErrors.InvalidPaymentId", "Invalid Payment Id");

    


}
