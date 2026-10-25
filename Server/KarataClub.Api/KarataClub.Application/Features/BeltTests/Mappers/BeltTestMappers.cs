namespace KarataClub.Application.Features.BeltTests.Mappers
{
    public static class BeltTestMappers
    {
        public static BeltTestDto ToDto(this BeltTest BeltTest)
        {
            return new BeltTestDto(BeltTest.Id,BeltTest.BeltRank.ToDto(),
                BeltTest.Instructor.ToDto(),BeltTest.Member.ToDto(),
                BeltTest.Passed,BeltTest.ReservationDate,BeltTest.TestDate,BeltTest.Notes);
        }

        public static IQueryable<BeltTestDto> ToDto(this IQueryable<BeltTest> BeltTests)
        {
            return BeltTests.Select(
                bt => new BeltTestDto(
                    bt.Id, bt.BeltRank.ToDto(), bt.Instructor.ToDto(), 
                    bt.Member.ToDto(), bt.Passed, bt.ReservationDate, bt.TestDate, bt.Notes
                    )
                );
        }
    }
}
