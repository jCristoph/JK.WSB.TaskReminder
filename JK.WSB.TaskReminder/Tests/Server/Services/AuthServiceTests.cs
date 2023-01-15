using JK.WSB.TaskReminder.Server.Repositories;
using JK.WSB.TaskReminder.Server.Services;
using JK.WSB.TaskReminder.Shared.Dtos;
using JK.WSB.TaskReminder.Shared.Models;
using Microsoft.Extensions.Configuration;
using Moq;
using System.Security.Cryptography;

namespace JK.WSB.TaskReminder.Tests.Server.Services
{
    [TestClass]
    public class AuthServiceTests
    {
        [TestMethod]
        public async Task Login_UserDoesNotExists_LoginFailed()
        {
            Mock<IConfiguration> configurationMock = new();
            Mock<IUserRepository> userRepositoryMock = new();

            LoginDto loginDto = new()
            {
                Email = Guid.NewGuid().ToString(),
                Password = Guid.NewGuid().ToString(),
            };


            AuthService authService = new AuthService(userRepositoryMock.Object, configurationMock.Object);


            ServiceResponse<LoggedUserDto> result = await authService.Login(loginDto);


            Assert.IsNull(result.Data);
            Assert.IsFalse(result.Success);
        }

        [TestMethod]
        public async Task Login_UserExists_LoginSuccess()
        {
            var email = Guid.NewGuid().ToString();

            Mock<IConfiguration> configurationMock = new();
            Mock<IUserRepository> userRepositoryMock = new();

            LoginDto loginDto = new()
            {
                Email = Guid.NewGuid().ToString(),
                Password = Guid.NewGuid().ToString(),
            };

            CreatePasswordHash(loginDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            userRepositoryMock.Setup(x => x.GetUserByEmailAsync(loginDto.Email))
                .Returns(Task.FromResult<User?>(new User
                {
                    Email = email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                }));
            configurationMock.Setup(x => x.GetSection("AppSettings:Token").Value)
                .Returns(Guid.NewGuid().ToString());

            AuthService authService = new AuthService(userRepositoryMock.Object, configurationMock.Object);


            ServiceResponse<LoggedUserDto> result = await authService.Login(loginDto);


            Assert.IsNotNull(result.Data);
            Assert.IsTrue(result.Success);
        }

        [TestMethod]
        public async Task Register_UserWithEmailAlreadyExists_RegisterFailed()
        {
            var email = Guid.NewGuid().ToString();

            Mock<IConfiguration> configurationMock = new();
            Mock<IUserRepository> userRepositoryMock = new();

            RegisterDto registerDto = new()
            {
                Email = Guid.NewGuid().ToString(),
            };

            userRepositoryMock.Setup(x => x.GetUserByEmailAsync(registerDto.Email))
                .Returns(Task.FromResult<User?>(new User
                {
                    Email = email
                }));

            AuthService authService = new AuthService(userRepositoryMock.Object, configurationMock.Object);


            ServiceResponse<int> result = await authService.Register(registerDto);


            Assert.IsFalse(result.Success);
            Assert.AreEqual(result.Message, "User with this email already exists");
        }

        [TestMethod]
        public async Task Register_UserWithEmailDoesNotExists_RegisterSuccess()
        {
            var email = Guid.NewGuid().ToString();

            Mock<IConfiguration> configurationMock = new();
            Mock<IUserRepository> userRepositoryMock = new();

            RegisterDto registerDto = new()
            {
                Email = Guid.NewGuid().ToString(),
                Password = Guid.NewGuid().ToString(),
            };

            AuthService authService = new AuthService(userRepositoryMock.Object, configurationMock.Object);


            ServiceResponse<int> result = await authService.Register(registerDto);


            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Data);
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}
