using ErrorOr;
using MediatR;
using N5.Permissions.Domain.Entities;

namespace N5.Permissions.Application.Permissions.Commands.UpdatePermission
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Date: 02/19/2025
    /// </summary>
    public class UpdatePermissionCommand : IRequest<ErrorOr<Permission>>
    {
        public Permission Permission { get; set; } = null!;
    }
}
