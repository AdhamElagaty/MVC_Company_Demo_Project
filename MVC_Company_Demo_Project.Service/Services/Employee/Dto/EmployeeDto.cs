using Microsoft.AspNetCore.Http;
using MVC_Company_Demo_Project.Data.Models;
using MVC_Company_Demo_Project.Service.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Company_Demo_Project.Service.Services.Dto
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public int Salary { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HiringDate { get; set; }
        public string? ImageUrl { get; set; }
        public IFormFile Image { get; set; }
        public DateTime CreateAt { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DepartmentId { get; set; }
        public DepartmentDto? Department { get; set; }
    }
}
