using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Company_Demo_Project.Data.Models;

namespace MVC_Company_Demo_Project.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string searchInp)
        {
            List<ApplicationUser> users;
            if (string.IsNullOrEmpty(searchInp))
                users = await _userManager.Users.ToListAsync();
            else
                users = await _userManager.Users
                    .Where(user => user.NormalizedEmail.Trim().Contains(searchInp.Trim().ToUpper())).ToListAsync();
            return View(users);
        }
    }
}
