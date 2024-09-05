using Microsoft.AspNetCore.Mvc;
using MVC_Company_Demo_Project.Repository.Interfaces;
using MVC_Company_Demo_Project.Service.Interfaces;

namespace MVC_Company_Demo_Project.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var department = _departmentService.GetAll();
            return View(department);
        }
    }
}
