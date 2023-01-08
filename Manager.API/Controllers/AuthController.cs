using Manager.API.Token;
using Manager.API.Utilities;
using Manager.API.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace Manager.API.Controllers;

[ApiController]
[Route("api/auth/[action]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly ITokenGenerator _tokenGenerator;

    public AuthController(IConfiguration configuration, ITokenGenerator tokenGenerator)
    {
        _configuration = configuration;
        _tokenGenerator = tokenGenerator;
    }

    [HttpPost]
    [Route("")]
    public IActionResult Login([FromBody] LoginViewModel loginViewModel)
    {
        try
        {
            var tokenLogin = _configuration["Jwt:Login"];
            var tokenPassword = _configuration["Jwt:Password"];

            if (loginViewModel.Login == tokenLogin && loginViewModel.Password ==tokenPassword)
            {
                return Ok(
                    new ResultViewModel
                    {
                        Message = "Usuario autenticado com sucesso.",
                        Success = true,
                        Data = new
                        {
                            Token = _tokenGenerator.GenerateToken(),
                            TokenExpires = DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:HoursToExpire"]))
                        }
                    }
                    );
            }
            else
            {
                return StatusCode(401, Responses.UnauthorizedErrorMessage());
            }
            
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
}