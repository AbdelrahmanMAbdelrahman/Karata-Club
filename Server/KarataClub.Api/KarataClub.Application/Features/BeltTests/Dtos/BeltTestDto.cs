namespace KarataClub.Application.Features.BeltTests.Dtos;
    public sealed record BeltTestDto(
        Guid BeltTestId,BeltRankDto BeltRank,InstructorDto Instructor,
        MemberDto Member,bool Passed,
        DateTimeOffset ReservationDate,DateTimeOffset TestDate, string? Notes
        );
