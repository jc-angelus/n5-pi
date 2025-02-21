using ErrorOr;
using Microsoft.EntityFrameworkCore;
using N5.Permissions.Application.Persistence.Repositories;
using N5.Permissions.Domain.Entities;

namespace N5.Permissions.Infrastructure.Persistence.Repositories
{
    /// <summary>
    /// Developer: Johans Cuellar
    /// Date: 02/19/2025
    /// </summary>
    public class PermissionTypeRepository : IPermissionTypeRepository
    {
        private readonly PermissionDbContext _context;

        public PermissionTypeRepository(PermissionDbContext context)
        {
            _context = context;
        }        

        public async Task<ErrorOr<List<PermissionType>>> GetPermissionTypes()
        {
            try
            {
                return await _context.PermissionType.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }        
    }
}
