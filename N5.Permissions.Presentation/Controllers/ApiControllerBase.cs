using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace N5.Permissions.Presentation.Controllers
{
    /// <summary>
    /// Developer: Johans Cuellar
    /// Date: 02/21/2025
    /// </summary>

    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        protected IActionResult Problem(List<Error> errors)
        {
            if (errors.Count is 0)
            {
                return Problem();
            }

            var statusCode = errors[0].Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                ErrorType.Forbidden => StatusCodes.Status403Forbidden,
                ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
                _ => StatusCodes.Status500InternalServerError,
            };

            var problemDetails = (ProblemDetails?)Problem(statusCode: statusCode).Value;

            var dictionaryErrors = new Dictionary<string, List<string>>();

            // Group errors by code
            foreach (var error in errors)
            {
                if (!dictionaryErrors.TryGetValue(error.Code, out List<string>? value))
                {
                    value = new List<string>();
                    dictionaryErrors.Add(error.Code, value);
                }

                value.Add(error.Description);
            }
            problemDetails?.Extensions.Add("errors", dictionaryErrors);

            return new ObjectResult(problemDetails);
        }
    }
}
