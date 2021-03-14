using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SchoolLocker.Core.Entities;
using SchoolLocker.Web.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLocker.Web.ApiControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;

        public AuthController(
            IConfiguration configuration)
        {
            _config = configuration;
        }

        [Route("login")]
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Task<IActionResult> Login([FromBody] CredentialDto credentials)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Neuen Benutzer registrieren. 
        /// </summary>
        /// <returns></returns>
        [Route("register")]
        [HttpPost]
        [AllowAnonymous]
        public Task<ActionResult> Register(UserDto newUser)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// JWT erzeugen. Minimale Claim-Infos: Email und Rolle
        /// </summary>
        /// <returns>Token mit Claims</returns>
        private string GenerateJwtToken(string email, IEnumerable<string> roles)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, email)
            };

            foreach (string role in roles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = new JwtSecurityToken(
              issuer: _config["Jwt:Issuer"],
              audience: _config["Jwt:Audience"],
              claims: authClaims,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}
