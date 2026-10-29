using Microsoft.AspNetCore.Authorization;

namespace KarataClub.Api.Controllers;

[ApiController()]
[Route("Api/[Controller]")]
[Authorize(Roles = "Admin")]

public class CoursesController(IMediator mediator) : ApiController
{
    [ProducesResponseType(typeof(CourseFileDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [EndpointName(nameof(CreateCourse))]
    [EndpointSummary("Create new Courses ")]
    [EndpointDescription("This end piont responsible for create Courses to be able to has Coursesship in the system")]
    [HttpPost()]

    public async Task<IActionResult> CreateCourse([FromForm]CourseReq req, CancellationToken ct)
    {
        CreateCourseCommand command = new CreateCourseCommand(req.CourseName,req.Fees,
            req.NumberOfSessions,req.NumberOfHours,
            req.StartAt,req.Priority,
            req.Image?.OpenReadStream(),
            req.Image?.ContentType,req.Image?.FileName);
        var result = await mediator.Send(command, ct);
        return result.Match(res =>
        CreatedAtAction(nameof(GetCourse), new { CourseFileId = res.CourseFileId }, res), Problem);
    }
    [ProducesResponseType(typeof(CourseFileDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [EndpointName(nameof(GetCourse))]
    [EndpointSummary("Get Course By Id")]
    [EndpointDescription("This end point responsible for get Courses by providing it's id")]
    [HttpGet("{CourseFileId}")]
    public async Task<IActionResult> GetCourse([FromRoute]GetCourseQuery query,CancellationToken ct)
    {
        var result=await mediator.Send(query, ct);  
        return result.Match(res=>Ok(res),Problem);
    }
    [ProducesResponseType(typeof(PaginatedList< CourseFileDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [EndpointName(nameof(GetCourses))]
    [EndpointSummary("Get Courses")]
    [EndpointDescription("This end point responsible for get Courses Filteration , Sorting Options")]
    [HttpGet("")]
    public async Task<IActionResult> GetCourses([FromQuery]GetCoursesQuery query,CancellationToken ct)
    {
        var result=await mediator.Send(query, ct);  
        return result.Match(res=>Ok(res),Problem);
    }

    //[ProducesResponseType(typeof(PaginatedList< CourseDto>), StatusCodes.Status200OK)]
    //[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    //[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    //[EndpointName(nameof(GetCoursess))]
    //[EndpointSummary("Get Coursess")]
    //[EndpointDescription("return a paginated list of Courses with given creteria")]
    //[HttpGet("")]
    //public async Task<IActionResult> GetCoursess([FromQuery]GetCoursesQuery query,CancellationToken ct)
    //{
    //    var result = await mediator.Send(query,ct);
    //    return result.Match(res=>Ok(res),Problem);
    //}
    //[ProducesResponseType(typeof(CourseDto), StatusCodes.Status200OK)]
    //[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    //[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    //[EndpointName(nameof(UpdateCourses))]
    //[EndpointSummary("update Courses By Id")]
    //[EndpointDescription("Provide a valid Courses id to update it's data from database ")]
    //[HttpPut("{CoursesId}")]
    //public async Task<IActionResult> UpdateCourses([FromRoute]Guid CoursesId,[FromBody]CreateCourseCommand command,CancellationToken ct)
    //{
    //    UpdateCourseCommand updateCommand = 
    //        new UpdateCoursesCommand(CoursesId,command.Name,command.Phone,
    //        command.Email,command.Address);
    //    var result = await mediator.Send(updateCommand,ct);
    //    return result.Match(res=>Ok(res),Problem);
    //}
}
