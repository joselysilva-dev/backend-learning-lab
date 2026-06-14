using Microsoft.AspNetCore.Mvc;
using MinhaPrimeiraApi.DTOs;
using MinhaPrimeiraApi.Services;

namespace MinhaPrimeiraApi.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly TokenService _tokenService;

    public AuthController(TokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginDto login)
    {
        if (login.Email == "admin@email.com" &&
            login.Senha == "123456")
        {
            var token = _tokenService.GerarToken(login.Email);

            return Ok(new
            {
                mensagem = "Login realizado com sucesso",
                token = token
            });
        }

        return Unauthorized(new
        {
            mensagem = "E-mail ou senha inválidos"
        });
    }
}