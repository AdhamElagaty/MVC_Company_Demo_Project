using Microsoft.AspNetCore.Mvc;
using MVC_Company_Demo_Project.Data.Models;
using MVC_Company_Demo_Project.Service.Interfaces;
using MVC_Company_Demo_Project.Service.Services;

namespace MVC_Company_Demo_Project.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult Index(string searchInp)
        {
            IEnumerable<Employee> employees = new List<Employee>();
            if (string.IsNullOrEmpty(searchInp))
                employees = _employeeService.GetAll();
            else
                employees = _employeeService.GetEmployeeByName(searchInp);
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _employeeService.Add(employee);
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("EmployeeError", "Validation Error");

                return View(employee);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("EmployeeError", ex.Message);
                return View(employee);
            }
        }

        [HttpGet]
        public IActionResult Details(int? id, string viewName = "Details")
        {
            var employee = _employeeService.GetById(id);
            if (employee is null)
                return RedirectToAction("NotFoundPage","Home", null);

            return View(viewName, employee);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            return Details(id, "Update");
        }

        [HttpPost]
        public IActionResult Update(int? id, Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (employee.Id != id.Value)
                        return RedirectToAction("NotFoundPage", "Home", null);

                    _employeeService.Update(employee);
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("EmployeeError", "Validation Error");

                return View(employee);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("EmployeeError", ex.Message);
                return View(employee);
            }
        }

        public IActionResult Delete(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee is null)
                return RedirectToAction("NotFoundPage", "Home", null);

            _employeeService.Delete(employee);
            return RedirectToAction(nameof(Index));
        }
    }
}
