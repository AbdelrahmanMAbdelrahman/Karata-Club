namespace KarataClub.Domain.Payments;

internal class PaymentErrors
{
    internal static Error InvalidPaymentAmount=Error.Validation("PaymentErrors.InvalidPaymentAmount", "Invalid Payment Amount");
    internal static Error InvalidPaymentDate=Error.Validation("PaymentErrors.InvalidPaymentDate", "Invalid Payment Date");
    internal static Error InvalidMemberId = Error.Validation("PaymentErrors.InvalidMemberId", "Invalid Member Id");
}
