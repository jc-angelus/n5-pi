using ErrorOr;
using Microsoft.EntityFrameworkCore;
using N5.Permissions.Domain.Entities;
using N5.Permissions.Infrastructure.Persistence;
using N5.Permissions.Infrastructure.Persistence.Repositories;

namespace N5.Permissions.Infrastructure.Tests.Repositories
{
    /// <summary>
    /// Developer: Johans Cuellar
    /// Date: 02/21/2025
    /// </summary>
    public class PermissionsTestRepository
    {
        private DbContextOptions<PermissionDbContext> dbContextOptions;

        public PermissionsTestRepository()
        {
            var dbName = $"BDTestPermissions_{DateTime.Now.ToFileTimeUtc()}";
            dbContextOptions = new DbContextOptionsBuilder<PermissionDbContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
        }

        private async Task<PermissionRepository> CreateRepositoryAsync()
        {
            PermissionDbContext context = new PermissionDbContext(dbContextOptions);
            await PopulateDataAsync(context);
            return new PermissionRepository(context);
        }        

        [Fact]
        public async Task GetPermissions_Ok()
        {
            //Arrange
            var repository = await CreateRepositoryAsync();

            //Act
            var permissions = repository.GetPermissions();
            var result = Assert.IsType<List<Permission>>(permissions?.Result.Value);

            //Assert
            Assert.Equal("Johans", result[0].NameEmployee);
        }

        [Fact]
        public async Task GetPermissionById_Ok()
        {
            //Arrange
            var repository = await CreateRepositoryAsync();

            //Act            
            var permission = repository.GetPermissionById(1);
            var result = permission?.Result.Value;

            //Assert            
            Assert.Equal(1, result?.Id);
        }

        [Fact]
        public async Task GetPermissionById_Error()
        {
            //Arrange
            var repository = await CreateRepositoryAsync();

            //Act
            var permission = repository.GetPermissionById(10);
            var result = permission?.Result.Errors;

            //Assert            
            Assert.True(permission?.Result.IsError);
            Assert.Equal("Permission.NotFound", result?[0].Code);
            Assert.Equal("Permission no found", result?[0].Description);
        }

        [Fact]
        public async Task UpdatePermission_Ok()
        {
            //Arrange
            var permission = new Permission()
            {
                Id = 1,
                NameEmployee = "Leo",
                SurnameEmployee = "Cuellar",
                PermissionDate = DateTime.Now,
                PermissionTypeId = 2
            };

            var repository = await CreateRepositoryAsync();

            //Act
            var permissionUpdate = await repository.UpdatePermission(permission, permission.Id);

            //Assert
            var result = Assert.IsType<ErrorOr<Permission>>(permissionUpdate);
            Assert.Equal(1, result.Value.Id);
            Assert.Equal(2, result.Value.PermissionTypeId);
        }

        [Fact]
        public async Task UpdatePermission_Error()
        {
            //Arrange
            var permission = new Permission()
            {
                Id = 9999,
                NameEmployee = "Johans",
                SurnameEmployee = "Cuellar",
                PermissionDate = DateTime.Now,
                PermissionTypeId = 1
            };

            var repository = await CreateRepositoryAsync();

            //Act
            var permissionUpdate = await repository.UpdatePermission(permission, permission.Id);

            //Assert
            var result = Assert.IsType<ErrorOr<Permission>>(permissionUpdate);
            Assert.True(result.IsError);
        }
      
        private static async Task PopulateDataAsync(PermissionDbContext context)
        {

            var permissionType = new PermissionType()
            {
                Id = 1,
                Description = "Permission for marriege"
            };

            var permission1 = new Permission()
            {
                Id = 1,
                NameEmployee = "Johans",
                SurnameEmployee = "Cuellar",
                PermissionDate = DateTime.Now,
                PermissionType = permissionType
            };

            var permission2 = new Permission()
            {
                Id = 2,
                NameEmployee = "Jose",
                SurnameEmployee = "Cuellar",
                PermissionDate = DateTime.Now,
                PermissionType = permissionType
            };

            var permission3 = new Permission()
            {
                Id = 3,
                NameEmployee = "Pedro",
                SurnameEmployee = "Cuellar",
                PermissionDate = DateTime.Now,
                PermissionType = permissionType
            };

            context.Permission.Add(permission1);
            context.Permission.Add(permission2);
            context.Permission.Add(permission3);

            await context.SaveChangesAsync();
        }

    }
}
