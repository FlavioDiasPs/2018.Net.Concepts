using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace UsingJWTAuthorization.Controllers
{
    public class TokenController : Controller
    {
        [Route("/token")]
        public IActionResult Create(string username, string password)
        {
            if (IsValidUserAndPasswordCombination(username, password))
                return new ObjectResult(GenerateToken(username));
            return BadRequest();
        }

        private bool IsValidUserAndPasswordCombination(string username, string password)
        {
            return !string.IsNullOrEmpty(username) && username == password;
        }

        private string GenerateToken(string username)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString()),
            };



//            var token = new JwtSecurityToken(
            //    issuer: "your app",
            //    audience: "the client of your app",
            //    claims: claims,
            //    notBefore: DateTime.Now,
            //    expires: DateTime.Now.AddDays(28),
            //    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            //);

            var token = new JwtSecurityToken(
                new JwtHeader(
                    new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes("the secret that needs to be at least 16 characeters long for HmacSha256")),
                                             SecurityAlgorithms.HmacSha256)),
                new JwtPayload(claims));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}