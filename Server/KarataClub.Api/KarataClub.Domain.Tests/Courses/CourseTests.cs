using KarataClub.Domain.BeltTests.BeltRanks.Enums;
using KarataClub.Domain.Courses;
using KarataClub.Tests.Common;
using System;

namespace KarataClub.Domain.Tests.Courses;

public class CourseTests
{
    [Fact]
    public void CreateCourse_ShouldPass_ForValidData()
    {
       FakeTimeProvider timeProvider = new FakeTimeProvider();
        string courseName = "white";
        decimal fees = 100;
        int numberOfSessions = 10;
        decimal totalHours = 10;
        DateTimeOffset startAt = timeProvider.GetUtcNow();
        DateTimeOffset endAt = timeProvider.GetUtcNow().AddDays(10);
        Priority priority = Priority.White;
        var courseRes = Course.Create(courseName,fees,numberOfSessions,totalHours,startAt,endAt,priority);
        Assert.True(courseRes.IsSuccess);
        Course course= courseRes.Value;
        Assert.NotNull(course);
        Assert.Equal(course.CourseName,courseName);
        Assert.Equal(course.Fees,fees);
        Assert.Equal(course.NumberOfSessions,numberOfSessions);
        Assert.Equal(course.TotalHours,totalHours);
        Assert.Equal(course.StartAt,startAt);
        Assert.Equal(course.EndAt,endAt);
        Assert.Equal(course.Priority,priority);

    }
    [Fact]
    public void CreateCourse_ShouldPass_ForValidDate()
    {
        FakeTimeProvider timeProvider = new FakeTimeProvider();
        string courseName = "white";
        decimal fees = 100;
        int numberOfSessions = 10;
        decimal totalHours = 10;
        DateTimeOffset startAt = timeProvider.GetUtcNow();
        DateTimeOffset endAt = timeProvider.GetUtcNow();
        Priority priority = Priority.White;
        var courseRes = Course.Create(courseName, fees, numberOfSessions, totalHours, startAt, endAt, priority);
        Assert.True(courseRes.IsFailure); 
    }
        [Theory]
    [InlineData("",100,10,10,Priority.White)]
    [InlineData("White",0,10,10,Priority.White)]
    [InlineData("White",100,0,10,Priority.White)]
    [InlineData("White",100,10,0,Priority.White)]
    public void CreateCourse_ShouldFail_ForInValidData(
            string courseName,decimal fees,int numberOfSessions,int totalHours,Priority priority)
    {
        FakeTimeProvider timeProvider = new FakeTimeProvider();
        DateTimeOffset startAt = timeProvider.GetUtcNow();
        DateTimeOffset endAt = timeProvider.GetUtcNow().AddDays(10);
        var courseRes = Course.Create(courseName, fees, numberOfSessions, totalHours, startAt, endAt, priority);
        Assert.True(courseRes.IsFailure);
    }
}
