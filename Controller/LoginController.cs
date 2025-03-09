using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("v1")]
public class LoginController : ControllerBase
{
  private readonly IUserService _userService;

  public LoginController(IUserService userService)
  {
    _userService = userService;
  }

  [HttpPost]
  [Route("login")]
  public async Task<ActionResult<GenerateTokenResponse>> AuthenticateAsync([FromBody] GenerateTokenRequest request)
  {
    var response = await _userService.GenerateToken(request);

    if (response == null)
    {
      return NotFound(new { message = "Usuário ou senha inválidos" });
    }

    return response;
  }
}