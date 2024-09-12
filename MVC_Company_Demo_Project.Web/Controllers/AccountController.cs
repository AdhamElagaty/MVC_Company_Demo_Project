using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_Company_Demo_Project.Data.Models;
using MVC_Company_Demo_Project.Web.Models;

namespace MVC_Company_Demo_Project.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AccountController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult SignUp()
        {
            return View();
        }

        public async Task<IActionResult> SignIn(SignUpViewModel input)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = input.Email.Split("@")[0],
                    Email = input.Email,
                    FirstName = input.FirstName,
                    LastName = input.LastName,
                    IsActive = true
                };
                var result = await _userManager.CreateAsync(user, input.Password);
                if (result.Succeeded)
                    return RedirectToAction("SignIn");

                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);
            }
            return View(input);
        }
    }
}
