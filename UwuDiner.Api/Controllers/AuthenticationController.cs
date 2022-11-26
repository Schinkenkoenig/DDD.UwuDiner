using Microsoft.AspNetCore.Mvc;
using UwuDiner.Application.Services.Authentication;
using UwuDiner.Contracts.Authentication;

namespace UwuDiner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
  private readonly IAuthenticationService authenticationService;

  public AuthenticationController(IAuthenticationService authenticationService)
  {
    this.authenticationService = authenticationService;
  }

  [HttpPost("register")]
  public IActionResult Register(RegisterRequest request)
  {
    var authResult = authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);
    var response = new AuthenticationResponse(
      authResult.User.Id,
      authResult.User.FirstName,
      authResult.User.LastName,
      authResult.User.Email,
      authResult.Token);

    return Ok(response);
  }

  [HttpPost("login")]
  public IActionResult Login(LoginRequest request)
  {
    var authResult = authenticationService.Login(request.Email, request.Password);
    var response = new AuthenticationResponse(
      authResult.User.Id,
      authResult.User.FirstName,
      authResult.User.LastName,
      authResult.User.Email,
      authResult.Token);

    return Ok(response);
  }
}
