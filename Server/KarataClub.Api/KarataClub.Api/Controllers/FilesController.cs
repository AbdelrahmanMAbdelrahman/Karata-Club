using Microsoft.AspNetCore.Authorization;

namespace KarataClub.Api.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    //[Authorize(Roles = "Admin")]
    public class FilesController(IMediator mediator):ApiController
    {
        [ProducesResponseType(typeof(DownloadFileDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [EndpointName(nameof(GetFile))]
        [EndpointSummary("Get File By Id")]
        [EndpointDescription("This end point responsible for get Image by providing it's id")]
        [HttpGet("{FileId:guid}")]
        public async Task<IActionResult> GetFile([FromRoute]GetFileQuery query,CancellationToken cancellationToken)
        {
            var result = await mediator.Send(query,cancellationToken);
            return result.Match(res=>File(result.Value.Image,result.Value.ContentType,result.Value.StoredImageName),Problem);
        }
    }
}
