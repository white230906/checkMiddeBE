using Microsoft.AspNetCore.Mvc;
using TestRepo.Service.Identity;

namespace TestRepo.Api.Controller;

[ApiController]
[Route("[controller]")]
public class IdentityController: ControllerBase
{
    private readonly IService _identityService;

    public IdentityController(IService identityService)
    {
        _identityService = identityService;
    }

    [HttpGet("login")]
    public async Task<IActionResult> Login(string email, string password)
    {
        var user = await _identityService.Login(email, password);
        return Ok(user);
    }
}