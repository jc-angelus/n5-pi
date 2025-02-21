using ErrorOr;
using N5.Permissions.Domain.Entities;

namespace N5.Permissions.Application.Persistence.Repositories
{
    /// <summary>
    /// Developer: Johans Cuellar
    /// Date: 02/19/2025
    /// </summary>
    public interface IPermissionRepository
    {
        public Task<ErrorOr<List<Permission>>> GetPermissions();
        public Task<ErrorOr<Permission>> GetPermissionById(int id);        
        public Task<ErrorOr<Permission>> UpdatePermission(Permission permission, int idPermission);
    }
}
