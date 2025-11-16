using AutoMapper;
using MVC_Company_Demo_Project.Data.Models;
using MVC_Company_Demo_Project.Service.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Company_Demo_Project.Service.Mapping
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile() {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
        }
    }
}
