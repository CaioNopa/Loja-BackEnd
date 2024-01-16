using Loja.Data;
using Loja.Models;
using Loja.Services;
using Loja.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Loja.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost("account/login")]
        public IActionResult Login(
            [FromBody] UserLoginViewModel model,
            [FromServices] AppDbContext context,
            [FromServices] TokenService tokenService)
        {
            var user = context.Users.FirstOrDefault(
                x => x.Email == model.Email);

            if (user == null)
                return StatusCode(401, new { message = "Usuário ou senha inválidos" });
        
            if(user.Password != Settings.GenerateHash(model.Password))
                return StatusCode(401, new { message = "Usuário ou senha inválidos" });

            try 
            {
                var token = tokenService.CreateToken(user);

                return Ok(new { token = token, user });
            }
            catch
            {
                return StatusCode(500, new { 
                    message = "Erro interno no servidor" });
            }
        }

        [HttpPost("account/signup")]
        public IActionResult Signup(
            [FromBody] UserSignupViewModel model,
            [FromServices] AppDbContext context) 
        {
            var user = context.Users.FirstOrDefault(
                x => x.Email == model.Email);

            if (user != null)
                return StatusCode(401, new { 
                    message = "Email já cadastrado" });

            try
            {
                var newUser = new User
                {
                    Email = model.Email,
                    Password = Settings.GenerateHash(model.Password),
                    Name = model.Name,
                    Role = "cliente"
                };

                context.Users.Add(newUser);
                context.SaveChanges();

                return Ok(new
                {
                    message = "Registro realizdo com sucesso"
                });
            }
            catch
            {
                return StatusCode(500, new
                {
                    message = "Erro interno no servidor"
                });
            }
        }

    }
}
