using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Persistence;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication.Queries;

public class AuthenticationQueryService : IAuthenticationQueryService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    
    public AuthenticationResult Login(string Email, string Password)
    {
        if(_userRepository.GetUserByEmail(Email) is not User user){
            throw new Exception("This user doesn't exists");
        }

        if(user.Password != Password){
            throw new Exception("Invalid Password");

        }

        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user,token);
    }


}
