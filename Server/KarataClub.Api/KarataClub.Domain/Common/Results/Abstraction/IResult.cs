namespace KarataClub.Domain.Common.Results.Abstraction;

public interface IResult
{
    List<Error>? Errors { get; }
    bool IsSuccess { get; }
}
public interface IResult<T>:IResult  
{
    T Value { get; }
}