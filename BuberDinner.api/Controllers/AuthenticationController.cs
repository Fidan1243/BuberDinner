using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController: ControllerBase{
    private readonly ISender _mediator;

    public AuthenticationController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request){
        var command = new RegisterCommand(request.FirstName,request.LastName,request.Email,request.Password);
        var authRes = await _mediator.Send(command);
        
        return Ok(authRes);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request){
        var authRes = new LoginQuery(request.Email,request.Password);
        var response = await _mediator.Send(authRes);
        return Ok(authRes);
    }
}