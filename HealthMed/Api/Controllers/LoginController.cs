using Core.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Api.Controllers;

[Route("[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private const string CHAVE_TOKEN = "**__CHAVE__TOKEN__**";

    /// <summary>
    /// Gerar token de autenticação
    /// </summary>
    /// <param name="loginDto">usuário e senha</param>
    /// <returns>token de autenticação</returns>
    [HttpPost]
    public IActionResult Post([FromBody] LoginDto loginDto)
    {
        if (loginDto.Usuario == "usuario-fiap" && loginDto.Senha == "senha-fiap")
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(CHAVE_TOKEN));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var Sectoken = new JwtSecurityToken(null,
              null,
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

            return Ok(token);
        }
        else
        {
            return Unauthorized("Usuário ou senha incorretos");
        }
    }
}
