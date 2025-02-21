using ErrorOr;
using N5.Permissions.Domain.Entities;

namespace N5.Permissions.Application.Persistence.Repositories
{
    /// <summary>
    /// Developer: Johans Cuellar
    /// Date: 02/19/2025
    /// </summary>
    public interface IPermissionTypeRepository
    {
        public Task<ErrorOr<List<PermissionType>>> GetPermissionTypes();        
    }
}
