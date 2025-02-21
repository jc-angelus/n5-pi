using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using N5.Permissions.Presentation.Controllers;

namespace N5.Permissions.Presentation.Tests
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Date: 02/19/2025
    /// </summary>
    public class ApiControllerBaseTest : ApiControllerBase
    {
        [Fact]
        public void Problem_ReturnErrorCodes()
        {
            var result = Problem(new List<Error> { });
            var objectResult = Assert.IsType<ObjectResult>(result);
            var problemDetails = Assert.IsType<ProblemDetails>(objectResult.Value);
            Assert.Equal(500, problemDetails.Status);

            result = Problem(new List<Error> { Error.Conflict() });
            objectResult = Assert.IsType<ObjectResult>(result);
            problemDetails = Assert.IsType<ProblemDetails>(objectResult.Value);
            Assert.Equal(409, problemDetails.Status);

            result = Problem(new List<Error> { Error.Validation() });
            objectResult = Assert.IsType<ObjectResult>(result);
            problemDetails = Assert.IsType<ProblemDetails>(objectResult.Value);
            Assert.Equal(400, problemDetails.Status);

            result = Problem(new List<Error> { Error.NotFound() });
            objectResult = Assert.IsType<ObjectResult>(result);
            problemDetails = Assert.IsType<ProblemDetails>(objectResult.Value);
            Assert.Equal(404, problemDetails.Status);

            result = Problem(new List<Error> { Error.Forbidden() });
            objectResult = Assert.IsType<ObjectResult>(result);
            problemDetails = Assert.IsType<ProblemDetails>(objectResult.Value);
            Assert.Equal(403, problemDetails.Status);

            result = Problem(new List<Error> { Error.Unauthorized() });
            objectResult = Assert.IsType<ObjectResult>(result);
            problemDetails = Assert.IsType<ProblemDetails>(objectResult.Value);
            Assert.Equal(401, problemDetails.Status);

            result = Problem(new List<Error> { Error.Failure() });
            objectResult = Assert.IsType<ObjectResult>(result);
            problemDetails = Assert.IsType<ProblemDetails>(objectResult.Value);
            Assert.Equal(500, problemDetails.Status);

        }

    }
}
