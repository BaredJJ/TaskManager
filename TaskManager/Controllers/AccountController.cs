using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        }

        [AllowAnonymous]
        public ViewResult LogIn(string returnUri) => View(new LogIn {ReturnUri = returnUri});

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LogIn logIn)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(logIn.Name);
                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                    if ((await _signInManager.PasswordSignInAsync(user, logIn.Password, false, false)).Succeeded)
                        return Redirect("/Home/Index");

                }
            }

            TempData["Message"] = "Неправильное имя или пароль";
            return View(logIn);
        }

        public async Task<RedirectResult> LogOut(string returnUri = "/")
        {
            await _signInManager.SignOutAsync();
            return Redirect("LogIn");
        }
    }
}

