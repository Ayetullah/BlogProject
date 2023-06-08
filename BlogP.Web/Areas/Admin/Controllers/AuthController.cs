using BlogP.Entity.Entities;
using BlogP.Entity.ModelDtos.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogP.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
	public class AuthController : Controller
	{
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
		{
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpGet]
		public IActionResult Login()
		{
			return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto userDto)
        {
			if(ModelState.IsValid)
			{
                var user = await _userManager.FindByEmailAsync(userDto.Email);
                if(user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, userDto.Password, userDto.Rememberme, false);
                    if(result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home", new { Area = "Admin" });
                    }
                }

                ModelState.AddModelError("", "E-posta adresiniz veya şifreniz hatalıdır.");
                return View();
            }

            return View();
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new {Area = ""});
        }
    }
}
