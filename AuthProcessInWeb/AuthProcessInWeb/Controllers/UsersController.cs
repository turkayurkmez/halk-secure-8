using AuthProcessInWeb.Models;
using AuthProcessInWeb.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AuthProcessInWeb.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Login(string? gidilecekSayfa)
        {
            //123456: Şifreyi, kullanıcıdan başka kimse bilemez! Sistem de dahil!
            //Encoding - Encrypting
            // Mesajın formatını değiştir: Encoding
            // MD5 -> Şifre şifrelenir mi? HAYIR

            //var encrypted = BCrypt.Net.BCrypt.HashPassword("123456");
            //var isVerified = BCrypt.Net.BCrypt.Verify("123456", encrypted);

            ViewBag.ReturnUrl = gidilecekSayfa;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserViewModel model, string? gidilecekSayfa)
        {
            if (ModelState.IsValid)
            {
                var user = new UserService().ValidateUser(model.UserName, model.Password);
                if (user != null)
                {
                    var claims = new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Role, user.Role)
                    };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);

                    if (!string.IsNullOrEmpty(gidilecekSayfa) && Url.IsLocalUrl(gidilecekSayfa))
                    {
                        return Redirect(gidilecekSayfa);
                    }
                    return Redirect("/");

                }
                ModelState.AddModelError("login", "giriş başarısız");
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        public IActionResult AccessDenied() => View();
    }
}
