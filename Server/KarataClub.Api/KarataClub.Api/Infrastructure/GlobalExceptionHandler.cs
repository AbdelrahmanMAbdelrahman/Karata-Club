using Microsoft.AspNetCore.Diagnostics;

namespace KarataClub.Api.Infrastructure
{
    public class GlobalExceptionHandler(IProblemDetailsService problemDetailsService) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            ProblemDetailsContext context = new ProblemDetailsContext()
            {
                Exception = exception,
                HttpContext = httpContext,
                ProblemDetails=new ProblemDetails()
                {
                    Title="Application Error",
                    Detail=exception.Message,
                    Type=exception.GetType().Name

                }
            };
            return await problemDetailsService.TryWriteAsync(context);
        }
    }
}
