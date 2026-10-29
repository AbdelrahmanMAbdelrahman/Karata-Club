using KarataClub.Domain.Common.Results.Abstraction;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace KarataClub.Domain.Common.Results;

public static class Result
{
    public static Success Success => default!;
    public static Failure Failure =>default!;
    public static Deleted Deleted =>default!;
    public static Updated Updated =>default!;
}
public class Result<T> : IResult<T>
{
    
    public bool IsSuccess { get; }
    public T Value  {get;}
    public List<Error> Errors { get; }
    public bool IsFailure => !IsSuccess;
    public Error TopError =>IsFailure? Errors[0]:default!;

    [JsonConstructor]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Result(T value,List<Error>errors,bool isSuccess)
    {
        errors ??= [];
        if (errors.Any() && !isSuccess || isSuccess && errors.Any()) throw new InvalidOperationException();
        Value = value;
        Errors = errors;
        IsSuccess = isSuccess;
    }

    public Result(Error error)
    {
        Errors = [error];
        IsSuccess = false;
    }

    public Result(List<Error> errors)
    {
        Errors = errors;
        IsSuccess = false;
    }
    public Result(T value)
    {
        if (value is null) throw new InvalidOperationException();
        Value = value;
        IsSuccess = true;
    }

    public TNextValue Match<TNextValue>(Func<T,TNextValue>OnSuccess,Func<List<Error>,TNextValue>OnError)=>
        IsSuccess?OnSuccess(Value):OnError(Errors);
    public static implicit operator Result<T>(Error error) => new(error);
    public static implicit operator Result<T>(List<Error> errors) => new(errors);
    public static implicit operator Result<T>(T val) => new(val);

}

public readonly record struct Success;
public readonly record struct Failure;
public readonly record struct Deleted;
public readonly record struct Updated;
