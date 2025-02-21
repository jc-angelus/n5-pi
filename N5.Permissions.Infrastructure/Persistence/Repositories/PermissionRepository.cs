using ErrorOr;
using Microsoft.EntityFrameworkCore;
using N5.Permissions.Application.Persistence.Repositories;
using N5.Permissions.Domain.Entities;
using N5.Permissions.Domain.Errors;

namespace N5.Permissions.Infrastructure.Persistence.Repositories
{
    /// <summary>
    /// Developer: Johans Cuellar
    /// Date: 02/19/2025
    /// </summary>
    public class PermissionRepository : IPermissionRepository
    {
        private readonly PermissionDbContext _context;

        public PermissionRepository(PermissionDbContext context)
        {
            _context = context;
        }        

        public async Task<ErrorOr<List<Permission>>> GetPermissions()
        {
            try
            {
                return await _context.Permission.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<ErrorOr<Permission>> GetPermissionById(int id)
        {
            try
            {
                var permission = await _context.Permission.FindAsync(id);

                if (permission is null)
                {
                    return PermissionsErrors.PermissionNotFound;
                }

                return permission;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            
        }

        public async Task<ErrorOr<Permission>> UpdatePermission(Permission permission, int idPermission)
        {

            try
            {
                Permission? updatePermission = await _context.Permission.FindAsync(idPermission);

                if (updatePermission is null)
                {
                    return PermissionsErrors.PermissionNotFound;
                }

                _context.Entry(updatePermission).CurrentValues.SetValues(permission);

                return updatePermission;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
