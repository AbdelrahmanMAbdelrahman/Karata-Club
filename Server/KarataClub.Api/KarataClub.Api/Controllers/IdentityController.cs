using Microsoft.AspNetCore.Authorization;

namespace KarataClub.Api.Controllers
{
    [ApiController()]
    [Route("Api/[Controller]")]
    
    public class IdentityController(IMediator mediator):ApiController
    {
        [ProducesResponseType(typeof(TokenResponse),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails),StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails),StatusCodes.Status404NotFound)]
        [EndpointName(nameof(Login))]
        [EndpointSummary("Login with Email and Password")]
        [EndpointDescription("Use Your Email And Password to Get Access , Refresh Token")]
        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login(LoginQuery query,CancellationToken ct)
        {
            var result=await mediator.Send(query);
            return result.Match(res => Ok(res), Problem);
        }
    }
}
