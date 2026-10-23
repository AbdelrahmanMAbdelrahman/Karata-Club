namespace KarataClub.Application.Features.BeltTests.Mappers
{
    public static class BeltTestMappers
    {
        public static BeltTestDto ToDto(this BeltTest BeltTest)
        {
            return new BeltTestDto(BeltTest.Id,BeltTest.BeltRank.ToDto(),
                BeltTest.Instructor.ToDto(),BeltTest.Member.ToDto(),
                BeltTest.Passed,BeltTest.Notes);
        }
    }
}
