using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OpenBook.App.Interactors;
using OpenBook.Shared.Dtos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace OpenBook.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private UserInteractor userInteractor;
        private EmailVerifInteractor verifInteractor;
        public AuthController(UserInteractor interactor, EmailVerifInteractor emailVerifInteractor)
        {
            this.userInteractor = interactor;
            this.verifInteractor = emailVerifInteractor;
        }
        [HttpPost("Token")]
        public async Task<IActionResult> Token(UserDto userPerson)
        {
            var identity = await GetIdentity(userPerson.Email, userPerson.Password);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };
            return Ok(response);
        }
        private async Task<ClaimsIdentity> GetIdentity(string username, string password)
        {
            var person = await userInteractor.GetByEmailPassword(username, password);
            if (person.IsSuccess)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Value.Email),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Value.Role.Name),
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }
            return null;
        }
    }
}
