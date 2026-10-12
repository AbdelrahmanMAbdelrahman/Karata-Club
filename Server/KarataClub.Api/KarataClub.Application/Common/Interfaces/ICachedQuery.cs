namespace KarataClub.Application.Common.Interfaces;

public interface ICachedQuery
{
    string CacheKey { get; }
    string[] Tags { get; }
    TimeSpan Expiration { get; }

}
public interface ICachedQuery<T>:ICachedQuery,IRequest<T>;
