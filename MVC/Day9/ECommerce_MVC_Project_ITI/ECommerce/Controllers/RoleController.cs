using ECommerce.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            RoleManager = roleManager;
        }

        public RoleManager<IdentityRole> RoleManager { get; }

        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel newRole)
        {
            if(ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole() { Name = newRole.RoleName};

                IdentityResult result = await RoleManager.CreateAsync(role);
                if(result.Succeeded)
                {
                    return View();
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(newRole);
        }
    }
}
