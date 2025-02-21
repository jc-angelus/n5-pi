using N5.Permissions.Application.Permissions.Persistence;
using N5.Permissions.Application.Persistence.Repositories;
using N5.Permissions.Infrastructure.Persistence.Repositories;

namespace N5.Permissions.Infrastructure.Persistence
{
    /// <summary>
    /// Developer: Johans Cuellar
    /// Date: 02/19/2025
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PermissionDbContext _context;
        
        private IPermissionRepository _permissionRepository = null!;

        private IPermissionTypeRepository _permissionTypeRepository = null!;


        public UnitOfWork(PermissionDbContext context)
        {
            _context = context;
        }        

        public IPermissionRepository PermissionRepository
        {
            get
            {
                if (_permissionRepository is null)
                {
                    _permissionRepository = new PermissionRepository(_context);
                }

                return _permissionRepository;

            }
        }

        public IPermissionTypeRepository PermissionTypeRepository
        {
            get
            {
                if (_permissionTypeRepository is null)
                {
                    _permissionTypeRepository = new PermissionTypeRepository(_context);
                }

                return _permissionTypeRepository;

            }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
