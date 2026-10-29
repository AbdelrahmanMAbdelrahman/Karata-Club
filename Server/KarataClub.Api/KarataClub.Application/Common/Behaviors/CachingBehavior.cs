using Microsoft.Extensions.Caching.Hybrid;

namespace KarataClub.Application.Common.Behaviors;

public sealed class CachingBehavior<TReq, TRes>(ILogger<CachingBehavior<TReq, TRes>> logger,
    HybridCache hybridCache) : IPipelineBehavior<TReq, TRes>
{
    public async Task<TRes> Handle(TReq request, RequestHandlerDelegate<TRes> next, CancellationToken cancellationToken)
    {
        if (request is not ICachedQuery cachedQuery)
            return await next(cancellationToken);

        TRes res = await hybridCache.GetOrCreateAsync(
            cachedQuery.CacheKey,
            token => new ValueTask<TRes>(next(token)),
            new HybridCacheEntryOptions()
            {
                Expiration = cachedQuery.Expiration
            },
            cachedQuery.Tags,
            cancellationToken

            );
        return  res;
    }
}
