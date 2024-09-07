using MVC_Company_Demo_Project.Data.Models;
using MVC_Company_Demo_Project.Repository.Interfaces;
using MVC_Company_Demo_Project.Service.Interfaces;
using MVC_Company_Demo_Project.Service.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Company_Demo_Project.Service.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public DepartmentDto GetById(int? id)
        {
            if (id is null)
                return null;

            var department = _unitOfWork.DepartmentRepository.GetById(id.Value);
            if (department is null)
                return null;

            var mappedDepartment = new DepartmentDto
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                IsDeleted = department.IsDeleted,
                CreateAt = department.CreateAt,
            };
            return mappedDepartment;
        }

        public IEnumerable<DepartmentDto> GetAll()
        {
            var departments = _unitOfWork.DepartmentRepository.GetAll();
            var mappedDepartments = departments.Select(x => new DepartmentDto
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
                IsDeleted = x.IsDeleted,
                CreateAt = x.CreateAt,
            });
            return mappedDepartments;
        }

        public void Add(DepartmentDto departmentDto)
        {
            var mappedDepartment = new Department()
            {
                Code = departmentDto.Code,
                Name = departmentDto.Name,
                CreateAt = DateTime.Now,
            };

            _unitOfWork.DepartmentRepository.Add(mappedDepartment);

            _unitOfWork.Complete();
        }

        public void Update(DepartmentDto department)
        {
            // _unitOfWork.DepartmentRepository.Update(department);
            // _unitOfWork.Complete();

            // var mappedDepartment = _mapper.Map<Department>(department);
            // _unitOfWork.DepartmentRepository.Update(mappedDepartment);
            // _unitOfWork.Complete();
        }

        public void Delete(DepartmentDto departmentDto)
        {
            var mappedDepartment = new Department
            {
                Id= departmentDto.Id,
                Name = departmentDto.Name,
                Code = departmentDto.Code,
                CreateAt = departmentDto.CreateAt,
            };
            _unitOfWork.DepartmentRepository.Delete(mappedDepartment);

            _unitOfWork.Complete();
        }
    }
}
