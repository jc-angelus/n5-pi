
using Moq;
using Microsoft.EntityFrameworkCore;
using N5.Permissions.Infrastructure.Persistence;
using N5.Permissions.Infrastructure.Persistence.Repositories;

namespace N5.Permissions.Infrastructure.Tests
{
    /// <summary>
    /// Developer: Johans Cuellar
    /// Date: 02/21/2025
    /// </summary>
    public class UnitOfWorkTest
    {
        [Fact]
        public async Task GetRepositories_Ok()
        {
            //Arrange            
            var mockContext = new Mock<PermissionDbContext>(new DbContextOptions<PermissionDbContext>());
            mockContext.Setup(c => c.SaveChangesAsync(CancellationToken.None));

            //Act
            var unitOfWork = new UnitOfWork(mockContext.Object);
            await unitOfWork.Save();
            //Assert
            Assert.IsType<PermissionRepository>(unitOfWork.PermissionRepository);            
        }
    }
}
