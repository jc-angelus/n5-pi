using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MediatR;
using N5.Permissions.Presentation.DTO;
using N5.Permissions.Application.PermissionTypes.Queries.GetPermissionTypes;

namespace N5.Permissions.Presentation.Controllers
{
    /// <summary>
    /// Developer: Johans Cuellar
    /// Date: 02/21/2025
    /// </summary>

    [ApiController]
    [Route("api/[controller]")]    
    public class PermissionTypesController : ApiControllerBase
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public PermissionTypesController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }        
        
        [HttpGet("getpermissiontypes")]
        public async Task<IActionResult> GetPermissions()
        {

            var query = new GetPermissionTypesQuery();

            var result = await _mediator.Send(query);

            return result.Match(
                permissionTypes => Ok(_mapper.Map<List<PermissionTypesResponseDto>>(permissionTypes)),
                errors => Problem(errors));
        }        
    }
}
