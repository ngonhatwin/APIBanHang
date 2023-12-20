//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace APIBanHang.Google
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AuthController : ControllerBase
//    {
//        [HttpGet("Login")]
//        public IActionResult Login(string returnUrl = "/")
//        {
//            return Challenge(new AuthenticationProperties { RedirectUri = returnUrl });
//        }

//        [HttpGet("Logout")]
//        public IActionResult Logout()
//        {
//            return SignOut(new AuthenticationProperties { RedirectUri = "/" },
//                CookieAuthenticationDefaults.AuthenticationScheme);
//        }
//    }
//}
