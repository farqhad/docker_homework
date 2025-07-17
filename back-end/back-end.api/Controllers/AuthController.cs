using Microsoft.AspNetCore.Mvc;
using Backend.Api.Routes;
using Backend.Api.Requests;
using Backend.Domain.Models;
using Backend.Domain.Abstractions.Repositories;

namespace Backend.Api.Controllers;

[ApiController]
[Route(ApiRoutes.AuthController.Base)]
public class AuthController : ControllerBase
{
    private readonly IUsersRepository _repository;

    public AuthController(IUsersRepository repo)
    {
        _repository = repo;
    }
    
    [HttpPost(ApiRoutes.AuthController.Register)]
    public async Task<ActionResult> Register([FromBody] RegisterRequest request)
    {
        User user = new User
        {
            Id = Guid.NewGuid(),
            Nickname = request.Nickname,
            Password = request.Password
        };

        User result = await _repository.CreateUser(user);
        
        if(result.Id == Guid.Empty){
            return StatusCode(500);
        }

        return Ok(result);
    }
}
