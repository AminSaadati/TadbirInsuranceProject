using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Tadbir.Ins.WebAPI.DtoModels.In;
using Vita.Infrastructure.EmailProvider;

namespace Tadbir.Ins.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IConfiguration _config; 
        public LoginController(IConfiguration config)
        {
            _config = config; 
        }
        [HttpPost] 
        public IActionResult Post([FromBody] LoginRequestDto loginRequest)
        {
            if (loginRequest == null)
            {
                throw new Exception();
                //your logic for login process
                //If login usrename and password are correct then proceed to generate token
            }
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            List<Claim> claims = [new Claim("UserName", "Admin"), new Claim("UserId", "123")];
            var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(Sectoken); 
            return Ok(token);
        }



     
    }
}
