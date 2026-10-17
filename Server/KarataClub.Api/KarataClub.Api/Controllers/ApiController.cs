namespace KarataClub.Api.Controllers;

public class ApiController:ControllerBase
{
    protected ActionResult Problem(List<Error> errors)
    {
        if (errors.Count == 0) throw new InvalidOperationException();
        if (errors.All(err => err.ErrorKind == ErrorKind.Validation))
        {
            return ValidationProblems(errors);
        }
        return Problem(errors[0]);
    }

    private ActionResult Problem(Error error)
    {
        int status = error.ErrorKind switch
        {
            ErrorKind.Conflict => StatusCodes.Status409Conflict,
            ErrorKind.NotFound=>StatusCodes.Status404NotFound,
            ErrorKind.BadRequest=>StatusCodes.Status400BadRequest,
            ErrorKind.UnAuthorized=>StatusCodes.Status403Forbidden,
            ErrorKind.Forbidden=>StatusCodes.Status403Forbidden,
            _=>StatusCodes.Status400BadRequest
        };
        return Problem(statusCode:status,title:error.Code,detail:error.Description);
    }

    private ActionResult ValidationProblems(List<Error> errors)
    {
        ModelStateDictionary keyValuePairs = new ModelStateDictionary();
        foreach (var error in errors) {
            keyValuePairs.TryAddModelError(error.Code,error.Description);
        }
        return ValidationProblem(keyValuePairs);
    }
}
