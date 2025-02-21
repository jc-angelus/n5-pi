using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MediatR;
using N5.Permissions.Application.Permissions.Commands.Queries.GetPermissionById;
using N5.Permissions.Presentation.DTO;
using N5.Permissions.Domain.Entities;
using N5.Permissions.Application.Permissions.Commands.UpdatePermission;
using N5.Permissions.Application.Permissions.Commands.Queries.GetPermissions;

namespace N5.Permissions.Presentation.Controllers
{
    /// <summary>
    /// Developer: Johans Cuellar
    /// Date: 02/21/2025
    /// </summary>

    [ApiController]
    [Route("api/[controller]")]    
    public class PermissionController : ApiControllerBase
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public PermissionController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("requestpermission")]
        public async Task<IActionResult> RequestPermission(int idPermission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var query = new GetPermissionByIdQuery()
            {
                Id = idPermission
            };

            var result = await _mediator.Send(query);

            return result.Match(
              result => Ok(_mapper.Map<PermissionResponseDto>(result)),
              errors => Problem(errors));
        }
        
        [HttpGet("getpermissions")]
        public async Task<IActionResult> GetPermissions()
        {

            var query = new GetPermissionsQuery();

            var result = await _mediator.Send(query);

            return result.Match(
                permissions => Ok(_mapper.Map<List<PermissionResponseDto>>(permissions)),
                errors => Problem(errors));
        }

        [HttpPatch("modifypermission")]
        public async Task<IActionResult> ModifyPermission([FromBody] PermissionRequestDto permissionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = new UpdatePermissionCommand()
            {
                Permission = _mapper.Map<Permission>(permissionDto)
            };
            
            var result = await _mediator.Send(command);

            return result.Match(
               permission => Ok(_mapper.Map<PermissionResponseDto>(permission)),
               errors => Problem(errors));

        }
    }
}
