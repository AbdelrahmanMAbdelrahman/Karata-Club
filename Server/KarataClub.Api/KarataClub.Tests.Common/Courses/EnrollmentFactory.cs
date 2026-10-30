using KarataClub.Domain.Common.Results;
using KarataClub.Domain.Courses.Enrollments;

namespace KarataClub.Tests.Common.Courses;

public static class EnrollmentFactory
{
    public static Result<CourseEnrollment> Create(
        Guid? courseId=null,
        Guid? memberId=null,
        Guid? paymentId = null,
        DateTimeOffset? enrollmentDate = null,
        DateTimeOffset? endDate=null
        )
    {
        FakeTimeProvider fakeTimeProvider = new FakeTimeProvider();
        return CourseEnrollment.Create(
            courseId??Guid.NewGuid(),
            memberId??Guid.NewGuid(),
            paymentId??Guid.NewGuid(),
            enrollmentDate??fakeTimeProvider.GetUtcNow(),
            enrollmentDate??fakeTimeProvider.GetUtcNow().AddDays(30));

    }
}
