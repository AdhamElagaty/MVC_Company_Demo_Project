using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_Company_Demo_Project.Data.Models;
using MVC_Company_Demo_Project.Repository.Interfaces;
using MVC_Company_Demo_Project.Service.Interfaces;
using MVC_Company_Demo_Project.Service.Services.Dto;

namespace MVC_Company_Demo_Project.Web.Controllers
{
    [Authorize]
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
        public IActionResult Create(DepartmentDto department)
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

        [HttpGet]
        public IActionResult Details(int? id, string viewName = "Details") 
        {
            var department = _departmentService.GetById(id);

            if (department == null)
                return RedirectToAction("NotFoundPage","Home", null);

            return View(viewName,department);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            return Details(id, "Update");
        }

        [HttpPost]
        public IActionResult Update(int? id, DepartmentDto department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (department.Id != id.Value)
                        return RedirectToAction("NotFoundPage", "Home", null);

                    _departmentService.Update(department);
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

        public IActionResult Delete(int? id) 
        {
            var department = _departmentService.GetById(id.Value);

            if (department is  null)
                return RedirectToAction("NotFoundPage", "Home", null);

            _departmentService.Delete(department);

            return RedirectToAction(nameof(Index));
        }
    }
}
