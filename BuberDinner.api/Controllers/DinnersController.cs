using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("dinners")]
[Authorize]
public class DinnersController: ControllerBase{
    private readonly ISender _mediator;

    public DinnersController(ISender mediator)
    {
        _mediator = mediator;
    }

    public IActionResult ListDinners(){
        
        return Ok(Array.Empty<string>());
    }
}