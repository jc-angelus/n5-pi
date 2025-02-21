using ErrorOr;
using MediatR;
using N5.Permissions.Domain.Entities;

namespace N5.Permissions.Application.PermissionTypes.Queries.GetPermissionTypes
{
    /// <summary>
    /// Developer: Johans Cuellar
    /// Date: 02/19/2025
    /// </summary>
    public class GetPermissionTypesQuery : IRequest<ErrorOr<List<PermissionType>>>
    {        
    }
}
