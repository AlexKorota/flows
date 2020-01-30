using flows.Controllers;
using flows.Domain.DTO;
using flows.Domain.Services.Interfaces;
using flows.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace flows.Tests.ControllersTests
{
    public class UserControllerTests
    {
        [Fact]
        public async Task Register_User_With_Invalid_DTO_Returns_BadRequest()
        {
            var mock = new Mock<IUserService>();
            var controller = new UserController(mock.Object);
            controller.ModelState.AddModelError("Password", "One or more validation errors occurred.");

            var badResult = await controller.Register(invalidRegistrationDto);

            Assert.IsType<BadRequestResult>(badResult);
        }

        [Fact]
        public async Task Register_UserWith_Valid_DTO_Returns_OkResult()
        {
            var mock = new Mock<IUserService>();
            var controller = new UserController(mock.Object);

            var okResult = await controller.Register(validRegistrationDto);

            Assert.IsType<OkResult>(okResult);
        }

        [Fact]
        public async Task Login_With_Invalid_CredentialsDTO_Returns_BadRequest()
        {
            var mock = new Mock<IUserService>();
            var controller = new UserController(mock.Object);
            controller.ModelState.AddModelError("Password", "One or more validation errors occurred.");

            var badResult = await controller.Login(invalidCredentialsDTO);

            Assert.IsType<BadRequestResult>(badResult);
        }

        [Fact]
        public async Task Login_With_Valid_CredentialsDTO_Returns_Unauthorized()
        {
            var mock = new Mock<IUserService>();
            mock.Setup(s => s.GetUserIdentityAsync(validCredentialsDTO)).ReturnsAsync((List<Claim>)null);
            var controller = new UserController(mock.Object);

            var unathorizedResult = await controller.Login(validCredentialsDTO);

            Assert.IsType<UnauthorizedResult>(unathorizedResult);
        }

        [Fact]
        public async Task Login_With_Valid_CredentialsDTO_Returns_OkObjectResult()
        {
            var mock = new Mock<IUserService>();
            mock.Setup(s => s.GetUserIdentityAsync(validCredentialsDTO)).ReturnsAsync(new List<Claim>());
            var controller = new UserController(mock.Object);

            var okObjectResult = await controller.Login(validCredentialsDTO);

            Assert.IsType<OkObjectResult>(okObjectResult);
            Assert.NotEqual(string.IsNullOrEmpty(""), ((OkObjectResult)okObjectResult).Value);
        }

        [Fact]
        public async Task Get_Me_Method_Test_Return_BadRequest()
        {
            var identity = new ClaimsIdentity(new List<Claim> { });

            var contextMock = new Mock<HttpContext>();
            contextMock.Setup(x => x.User).Returns(new ClaimsPrincipal(identity));

            var serviceMock = new Mock<IUserService>();
            serviceMock.Setup(s => s.GetUserAsync(email)).ReturnsAsync(new UserDTO() { Email = email });

            var controller = new UserController(serviceMock.Object);
            controller.ControllerContext.HttpContext = contextMock.Object;

            var badRequestResult = await controller.GetMe();
            Assert.IsType<BadRequestResult>(badRequestResult);
        }

        [Fact]
        public async Task Get_Me_Method_Test_Return_User()
        {
            var identity = new ClaimsIdentity(new List<Claim> { new Claim(ClaimTypes.Email, email) });

            var contextMock = new Mock<HttpContext>();
            contextMock.Setup(x => x.User).Returns(new ClaimsPrincipal(identity));

            var serviceMock = new Mock<IUserService>();
            serviceMock.Setup(s => s.GetUserAsync(email)).ReturnsAsync(new UserDTO() { Email = email });

            var controller = new UserController(serviceMock.Object);
            controller.ControllerContext.HttpContext = contextMock.Object;

            var okObjectResult = await controller.GetMe();
            Assert.IsType<OkObjectResult>(okObjectResult);
            var value = ((OkObjectResult)okObjectResult).Value;
            Assert.Equal(email, ((UserDTO)value).Email);
        }

        string email = "test@test.ru";

        RegistrationDTO invalidRegistrationDto = new RegistrationDTO() { };
        RegistrationDTO validRegistrationDto = new RegistrationDTO()
        {
            Email = "test@test.ru",
            Name = "testname",
            Password = "testpassword"
        };

        CredentialsDTO invalidCredentialsDTO = new CredentialsDTO() { };
        CredentialsDTO validCredentialsDTO = new CredentialsDTO() 
        {
            Email = "test@aaa.ru",
            Password = "testpassword"
        };
    }
}
