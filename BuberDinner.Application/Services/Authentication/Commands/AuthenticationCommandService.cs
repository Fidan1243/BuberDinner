using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Persistence;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication.Commands;

public class AuthenticationCommandService : IAuthenticationCommandService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    public AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Register(string FirstName, string LastName, string Email, string Password)
    {
        // Check if user exists
        if(_userRepository.GetUserByEmail(Email) is not null){
            throw new Exception("This user already exists");
        }

        // Create user (generate uid)
        var user = new User{
            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
            Password = Password,
        };
        _userRepository.AddUser(user);

        // Create Jwt
        Guid userId = Guid.NewGuid();

        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user,token);
    }

}
