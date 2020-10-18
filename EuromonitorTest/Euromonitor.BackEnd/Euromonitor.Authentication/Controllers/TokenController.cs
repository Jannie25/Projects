using Euromonitor.JWTHelper.Models;
using Euromonitor.JWTHelper.Services;
using Euromonitor.Models.General;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Euromonitor.Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private JWTConfig _jwtconfig;

        public TokenController(JWTConfig jwtconfig)
        {
            _jwtconfig = jwtconfig;
        }

        [AllowAnonymous]
        [HttpGet]
        public string GetRandomToken(User user)
        {
            var jwt = new JwtService((Microsoft.Extensions.Options.IOptions<JWTConfig>)_jwtconfig);
            var token = jwt.GenerateSecurityToken(user);
            return token;
        }
    }
}
