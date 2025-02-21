using Moq;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using N5.Permissions.Domain.Entities;
using N5.Permissions.Application.Permissions.Commands.Queries.GetPermissionById;
using N5.Permissions.Presentation.Controllers;
using N5.Permissions.Domain.Errors;
using N5.Permissions.Presentation.DTO;
using N5.Permissions.Application.Permissions.Commands.UpdatePermission;
using N5.Permissions.Application.Permissions.Commands.Queries.GetPermissions;

namespace N5.Permissions.Presentation.Tests
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Date: 02/21/2025
    /// </summary>
    public class PermissionsControllerTest
    {
        private Mock<ISender> mockMediator = new Mock<ISender>();


        [Fact]
        public async Task GetPermission_Ok()
        {

            //Arrange
            
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

            mockMediator.Setup(m => m.Send(It.IsAny<GetPermissionsQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(permissions);
            var controller = new PermissionController(mockMediator.Object, AutoMapperSingleton.Mapper);
            var result = await controller.GetPermissions();

            var okResult = Assert.IsType<OkObjectResult>(result);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetPermission_Error()
        {

            //Arrange

            var error = PermissionsErrors.PermissionsNotFound;

            //Act

            mockMediator.Setup(m => m.Send(It.IsAny<GetPermissionsQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(error);
            var controller = new PermissionController(mockMediator.Object, AutoMapperSingleton.Mapper);
            var result = await controller.GetPermissions();            

            //Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            var problemDetails = Assert.IsType<ProblemDetails>(objectResult.Value);
            Assert.Equal(404, problemDetails.Status);
        }


        [Fact]
        public async Task GetPermissionById_Ok()
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

            //Act

            mockMediator.Setup(m => m.Send(It.IsAny<GetPermissionByIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(permission);
            var controller = new PermissionController(mockMediator.Object, AutoMapperSingleton.Mapper);
            var result = await controller.RequestPermission(1);

            var okResult = Assert.IsType<OkObjectResult>(result);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetPermissionById_Error()
        {

            //Arrange

            var error = PermissionsErrors.PermissionNotFound;

            //Act                       

            mockMediator.Setup(m => m.Send(It.IsAny<GetPermissionByIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(error);
            var controller = new PermissionController(mockMediator.Object, AutoMapperSingleton.Mapper);
            var result = await controller.RequestPermission(1);

            //Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            var problemDetails = Assert.IsType<ProblemDetails>(objectResult.Value);
            Assert.Equal(404, problemDetails.Status);
        }

        [Fact]
        public async Task GetPermissionById_InvalidModel()
        {
            // Arrange
            var mockSender = new Mock<ISender>();

            //Act
            var controller = new PermissionController(mockSender.Object, AutoMapperSingleton.Mapper);
            controller.ModelState.AddModelError("error", "some error");

            //Assert
            var result = await controller.RequestPermission(1);
            Assert.IsType<BadRequestObjectResult>(result);
        }		

		[Fact]
        public async Task UpdatePermission_ReturnUpdated()
        {
            // Arrange
            var permissionDto = new PermissionRequestDto()
            {
                Id = 1,
                NameEmployee = "Leo",
                SurnameEmployee = "Cuellar",
                PermissionDate = DateTime.Now,
                PermissionTypeId = 2

            };

            var permission = new Permission()
            {
                Id = 1,
                NameEmployee = "Leo",
                SurnameEmployee = "Cuellar",
                PermissionDate = DateTime.Now,
                PermissionTypeId = 2
            };
            
            //Act
            Mock<ISender> mockMediator = new Mock<ISender>();
            mockMediator.Setup(m => m.Send(It.IsAny<UpdatePermissionCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(permission);
            var controller = new PermissionController(mockMediator.Object, AutoMapperSingleton.Mapper);

            //Assert
            var result = await controller.ModifyPermission(permissionDto);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task UpdatePermission_ReturnBadRequest()
        {
            // Arrange

            var permissionDto = new PermissionRequestDto()
            {
                Id = 1,
                NameEmployee = "Leo",
                SurnameEmployee = "Cuellar",
                PermissionDate = DateTime.Now,
                PermissionTypeId = 2

            };

            var permission = new Permission()
            {
                Id = 1,
                NameEmployee = "Leo",
                SurnameEmployee = "Cuellar",
                PermissionDate = DateTime.Now,
                PermissionTypeId = 2
            };

            //Act
            Mock<ISender> mockMediator = new Mock<ISender>();
            mockMediator.Setup(m => m.Send(It.IsAny<UpdatePermissionCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(permission);
            var controller = new PermissionController(mockMediator.Object, AutoMapperSingleton.Mapper);
            controller.ModelState.AddModelError("action", "test");

            //Assert
            var result = await controller.ModifyPermission(permissionDto);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task UpdatePermission_DevuelveProblem()
        {
            // Arrange

            var permissionDto = new PermissionRequestDto()
            {
                Id = 1,
                NameEmployee = "Leo",
                SurnameEmployee = "Cuellar",
                PermissionDate = DateTime.Now,
                PermissionTypeId = 2

            };

            var permission = Error.Failure();

            //Act
            Mock<ISender> mockMediator = new Mock<ISender>();
            mockMediator.Setup(m => m.Send(It.IsAny<UpdatePermissionCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(permission);

            var controller = new PermissionController(mockMediator.Object, AutoMapperSingleton.Mapper);
            var result = await controller.ModifyPermission(permissionDto);
            
            //Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            var problemDetails = Assert.IsType<ProblemDetails>(objectResult.Value);
            Assert.Equal(500, problemDetails.Status);
        }

    }
}
