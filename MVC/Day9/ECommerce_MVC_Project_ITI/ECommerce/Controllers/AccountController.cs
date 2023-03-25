using ECommerce.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public UserManager<IdentityUser> UserManager { get; }
        public SignInManager<IdentityUser> SignInManager { get; }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterAccountViewModel newAccount)
        {
            if(ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = newAccount.UserName;
                user.Email = newAccount.Email;

                IdentityResult result = await UserManager.CreateAsync(user, newAccount.Password);

                if(result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Profile");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(newAccount);
        }

        public IActionResult Login(string ReturnUrl = "~/Profile/Index")
        {
            ViewData["returnUrl"] = ReturnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginUser, string ReturnUrl ="~/Profile/Index")
        {
            IdentityUser user = await UserManager.FindByEmailAsync(loginUser.Email);

            if(user != null)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = 
                    await SignInManager.PasswordSignInAsync(user, loginUser.Password, loginUser.isPersisite, false);

                if (result.Succeeded)
                {
                    return LocalRedirect(ReturnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "incorrect email or password");
                }
            }
            else
            {
                ModelState.AddModelError("", "incorrect email or password");
            }
            return View(loginUser);
        }

        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }


        public IActionResult RegisterAdmin()
        {
            return View("Register");
        }
        [HttpPost]
        public async Task<IActionResult> RegisterAdmin(RegisterAccountViewModel newAccount)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = newAccount.UserName;
                user.Email = newAccount.Email;

                IdentityResult result = await UserManager.CreateAsync(user, newAccount.Password);

                if (result.Succeeded)
                {
                    //add user to admin role
                    await UserManager.AddToRoleAsync(user, "Admin");
                    

                    await SignInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Profile");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View("Register", newAccount);
        }

    }
}
