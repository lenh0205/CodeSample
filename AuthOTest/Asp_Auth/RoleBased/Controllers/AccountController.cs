using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace RoleBased.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpGet("/login")]
        public IActionResult Login() =>
            SignIn(new ClaimsPrincipal(
                new ClaimsIdentity(
                        new Claim[]
                        {
                            new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
                            new Claim("my_role_claim_extravaganza", "admin")
                        },
                        "cookie"
                    // nameType
                    // roleType
                    )),
                    authenticationScheme: "cookie"
                );
    }
}
