using Moq;
using N5.Permissions.Application.Permissions.Persistence;
using N5.Permissions.Application.Permissions.Commands.Queries.GetPermissionById;
using N5.Permissions.Domain.Entities;
using N5.Permissions.Application.Permissions.Commands.Queries.GetPermissions;
using N5.Permissions.Application.Permissions.Commands.UpdatePermission;
using N5.Permissions.Shared.Kafka;

namespace N5.Permissions.Application.Test
{
    /// <summary>
    /// Developer: Johans Cuellar
    /// Date: 02/21/2025
    /// </summary>
    public class PermissionsTest
    {
        private Mock<IUnitOfWork> mockRepo = new Mock<IUnitOfWork>();
        private Mock<IKafkaMessageBus<string, Operation>> mockKakfa = new Mock<IKafkaMessageBus<string, Operation>>();

        public PermissionsTest()
        {
            mockRepo = new Mock<IUnitOfWork>();
            mockKakfa = new Mock<IKafkaMessageBus<string, Operation>>();
        }

        [Fact]
        public async Task GetPermissions_Ok()
        {
            //Act
            var permissions = new List<Permission>()
            {
                new Permission()
                {
                     Id = 1,
                    NameEmployee = "Johans",
                    SurnameEmployee = "Cuellar",
                    PermissionDate = DateTime.Now,
                    PermissionTypeId = 1
                }
            };
            //Act
            GetPermissionsQuery obtenerPaisQuery = new GetPermissionsQuery();
            mockRepo.Setup(repo => repo.PermissionRepository.GetPermissions()).ReturnsAsync(permissions);
            var handler = new GetPermissionsQueryHandler(mockRepo.Object, mockKakfa.Object);
            var result = await handler.Handle(obtenerPaisQuery, default);

            //Assert
            Assert.False(result.IsError);
            Assert.IsType<List<Permission>>(result.Value);
        }

        [Fact]
        public async Task GetPermissionById_Ok()
        {
            //Arange
            var permission = new Permission()
            {
                Id = 1,
                NameEmployee = "Johans",
                SurnameEmployee = "Cuellar",
                PermissionDate = DateTime.Now,
                PermissionTypeId = 1                
            };

            //Act
            GetPermissionByIdQuery getPermissionByIdQuery = new GetPermissionByIdQuery();
            mockRepo.Setup(repo => repo.PermissionRepository.GetPermissionById(1)).ReturnsAsync(permission);
            var handler = new GetPermissionByIdQueryHandler(mockRepo.Object, mockKakfa.Object);
            var result = await handler.Handle(getPermissionByIdQuery, default);

            //Assert
            Assert.False(result.IsError);
        }		

		[Fact]
        public async Task UpdatePermission_Ok()
        {
            //Arrange
            var permission = new Permission()
            {
                Id = 1,
                NameEmployee = "Pedro",
                SurnameEmployee = "Cuellar",
                PermissionDate = DateTime.Now,
                PermissionTypeId = 2
            };

            //Act
            UpdatePermissionCommand command = new UpdatePermissionCommand() { Permission = permission };            
            mockRepo.Setup(repo => repo.PermissionRepository.UpdatePermission(permission, permission.Id)).ReturnsAsync(permission);

            var handler = new UpdatePermissionCommandHandler(mockRepo.Object, mockKakfa.Object);
            var result = await handler.Handle(command, default);

            //Assert
            Assert.False(result.IsError);
            Assert.Equal(1, result.Value.Id);            
        }

        [Fact]
        public async Task UpdatePermission_Error()
        {
            //Arrange
            var permission = new Permission()
            {
                Id = 1,
                NameEmployee = "Pedro",
                SurnameEmployee = "Cuellar",
                PermissionDate = DateTime.Now,
                PermissionTypeId = 2
            };

            var errorIsError = ErrorOr.Error.Unexpected();

            //Act
            UpdatePermissionCommand command = new UpdatePermissionCommand() { Permission = permission };
            mockRepo.Setup(repo => repo.PermissionRepository.UpdatePermission(permission, permission.Id)).ReturnsAsync(errorIsError);

            var handler = new UpdatePermissionCommandHandler(mockRepo.Object, mockKakfa.Object);
            var result = await handler.Handle(command, default);

            //Assert
            Assert.True(result.IsError);
        }

    }
}
