using MicroCommerce.Application.Common.Interfaces;
using MicroCommerce.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace MicroCommerce.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IIdentityService _identityService;

    public AuthController(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto request)
    {
        var result = await _identityService.RegisterAsync(request);
        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto request)
    {
        var result = await _identityService.LoginAsync(request);
        if (!result.IsSuccess)
            return Unauthorized(result);

        return Ok(result);
    }
}
