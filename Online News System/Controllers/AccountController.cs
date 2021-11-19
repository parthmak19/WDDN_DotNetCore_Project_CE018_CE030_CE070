using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Online_News_System.Models;
using Online_News_System.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_News_System.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        public AccountController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager, IUserRepository userRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _userRepository = userRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (_userRepository.checkUser(model.Username) != null)
            {
                ModelState.AddModelError("username", "this username is already exist.");
            }
            if (ModelState.IsValid)
            {
                var newuser = new IdentityUser
                {
                    UserName = model.Username,
                    Email = model.Email,
                };

                var result = await userManager.CreateAsync(newuser, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(newuser, isPersistent: false);
                    return RedirectToAction("index", "home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        //[AllowAnonymous]
        //public async Task<IActionResult> Login(LoginViewModel model, string Username, string Password)
        //{           
        //    if (ModelState.IsValid)
        //    {
        //        //User existuser = _userRepository.hasUser(Username, Password);
        //        //if (existuser == null)
        //        //{
        //        //    return RedirectToAction("login");
        //        //}
        //        //else
        //        //{
        //        //    return RedirectToAction("home");
        //        //}

        //        var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("Index","Home");
        //        }
        //        ModelState.AddModelError(string.Empty, "Invalid Attempt to Login");
        //    }
        //    return View(model);
        //}

        public async Task<IActionResult> Login(LoginViewModel model, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    var user = await userManager.FindByEmailAsync(model.Email);

                    if (!string.IsNullOrEmpty(ReturnUrl))
                    {

                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("index", "home");
                    }

                }

                ModelState.AddModelError(string.Empty, "Invalid Attempt to Login");
            }

            return View(model);
        }


        public async Task<IActionResult> Logout()
        {

            await signInManager.SignOutAsync();
            //flashMessage.Confirmation("Logged out Successfully");
            return RedirectToAction("index", "home");
        }

        public IActionResult Profile(int Id)
        {
            User model = _userRepository.GetUser(Id);
            return View(model);
        }
    }
}
