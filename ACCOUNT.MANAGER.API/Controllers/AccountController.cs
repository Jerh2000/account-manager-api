using ACCOUNT.MANAGER.API.Data.Models.ParametersEndPoints.Account;
using ACCOUNT.MANAGER.API.Data.Models.ResponsesEndPoints.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ACCOUNT.MANAGER.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IConfiguration configuration;

        public AccountController
        (
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IConfiguration configuration
        )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }

        [HttpPost("singup")]
        public async Task<ActionResult<Authentication>> SingUp(UserCredentials userCredentials)
        {
            var user = new IdentityUser { UserName = userCredentials.Email, Email = userCredentials.Email };
            var resultado = await userManager.CreateAsync(user, userCredentials.Password);

            if (resultado.Succeeded)
            {
                return ConstruirToken(userCredentials);
            }
            else
            {
                return BadRequest(resultado.Errors);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<Authentication>> LogIn(UserCredentials credencialesUsuario)
        {
            var resultado = await signInManager.PasswordSignInAsync(credencialesUsuario.Email,
                                 credencialesUsuario.Password, isPersistent: false, lockoutOnFailure: false);

            if (resultado.Succeeded)
            {
                return ConstruirToken(credencialesUsuario);
            }
            else
            {
                return BadRequest("Bad Login");
            }
        }


        private Authentication ConstruirToken(UserCredentials credencialesUsuario)
        {
            var claims = new List<Claim>
            {
                new Claim("email", credencialesUsuario.Email),
            };

            var llave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["llavejwt"]));
            var creds = new SigningCredentials(llave, SecurityAlgorithms.HmacSha256);

            var expiracion = DateTime.UtcNow.AddMonths(1);

            var securityToken = new JwtSecurityToken(issuer: null, audience: null, claims: claims,
                                expires: expiracion, signingCredentials: creds);

            return new Authentication
            {
                Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
                Expiracion = expiracion,
            };
        }
    }
}
