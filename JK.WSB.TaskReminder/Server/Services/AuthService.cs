using JK.WSB.TaskReminder.Server.Repositories;
using JK.WSB.TaskReminder.Shared.Dtos;
using JK.WSB.TaskReminder.Shared.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace JK.WSB.TaskReminder.Server.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public AuthService(
            IUserRepository userRepository,
            IConfiguration configuration)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }

        public async Task<ServiceResponse<LoggedUserDto>> Login(LoginDto userDto)
        {
            var response = new ServiceResponse<LoggedUserDto>();
            var user = await _userRepository.GetUserByEmailAsync(userDto.Email!);
            if (user == null)
            {
                response.Success = false;
                response.Message = "User not found.";
            }
            else if (!VerifyPasswordHash(userDto.Password!, user.PasswordHash!, user.PasswordSalt!))
            {
                response.Success = false;
                response.Message = "Wrong password.";
            }
            else
            {
                response.Data = new LoggedUserDto
                {
                    Token = CreateToken(user),
                    Id = user.Id
                };
                response.Message = "You are logged successfully";
            }

            return response;
        }

        public async Task<ServiceResponse<int>> Register(RegisterDto registerDto)
        {
            var response = new ServiceResponse<int>();

            var user = await _userRepository.GetUserByEmailAsync(registerDto.Email!);

            if (user is null)
            {
                try
                {
                    CreatePasswordHash(registerDto.Password!, out byte[] passwordHash, out byte[] passwordSalt);

                    _userRepository.Add(new User
                    {
                        Id = Guid.NewGuid(),
                        Name = registerDto.Name,
                        FirstName = registerDto.FirstName,
                        LastName = registerDto.LastName,
                        Email = registerDto.Email,
                        PasswordHash = passwordHash,
                        PasswordSalt = passwordSalt,
                    });
                }
                catch
                {
                    response.Message = "Internal Server Error occurred";
                    response.Success = false;

                    return response;
                }
            }
            else
            {
                response.Message = "User with this email already exists";
                response.Success = false;

                return response;
            }

            response.Message = "User created successfully";

            return response;
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }

        private static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var computedHash =
                hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email!)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(_configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
