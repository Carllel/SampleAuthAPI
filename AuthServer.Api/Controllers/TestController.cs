using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace AuthServer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        [HttpGet("Test")]
        public IActionResult Test()
        {
            return Ok(new { message= "User Authenticated", code = 200});
        }

        [HttpGet("AuthorizedTest")]
        [Authorize]
        public IActionResult AuthorizedTest()
        {
            var authorizationHeader = this.HttpContext.Request.Headers["Authorization"].FirstOrDefault();

            string jwtTokenString = authorizationHeader.Replace("Bearer ", "");

            var jwt = new JwtSecurityToken(jwtTokenString);

            //response += $"{Environment.NewLine}Exp Time: {jwt.ValidTo.ToLongTimeString()}, Time: {DateTime.UtcNow.ToLongTimeString()}";

            return Ok(new {message= "User Authenticated", code=200, ExpirationTime=$"{jwt.ValidTo.ToLongTimeString()}" });
        }
    }
}
