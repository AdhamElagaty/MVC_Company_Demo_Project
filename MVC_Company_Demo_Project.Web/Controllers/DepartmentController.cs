using Microsoft.AspNetCore.Mvc;
using MVC_Company_Demo_Project.Data.Models;
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
        [HttpGet]
        public IActionResult Index()
        {
            var department = _departmentService.GetAll();
            return View(department);
        }

        [HttpGet]
        public IActionResult Create() 
        { 
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _departmentService.Add(department);
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("DepartmentError", "Validation Error");

                return View(department);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("DepartmentError", ex.Message);
                return View(department);
            }
        }
    }
}
