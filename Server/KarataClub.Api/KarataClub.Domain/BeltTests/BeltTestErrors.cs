namespace KarataClub.Domain.BeltTests;

internal class BeltTestErrors
{
    internal static Error InvalidTestDate(DateTime testDate) => Error.Validation("BeltTestErrors.InvalidTestDate",$"provide a valid test date greated than {testDate}");
    internal static Error InvalidReservationDate(DateTime reservationDate) => Error.Validation("BeltTestErrors.ReservationDate", $"provide a valid Reservation Date greated than {reservationDate}");
    internal static Error InvalidBeltRankId=> Error.Validation("BeltTestErrors.InvalidBeltRankId", $"provide a valid Belt rank id");
    internal static Error InvalidMemberId => Error.Validation("BeltTestErrors.InvalidMemberId", $"provide a valid Member Id");
    internal static Error InvalidPaymentId => Error.Validation("BeltTestErrors.InvalidPaymentId", $"provide a valid Payment Id");
    internal static Error InvalidPaymentStatus => Error.Validation("BeltTestErrors.InvalidPaymentStatus", $"provide a valid Payment Status ");

}
