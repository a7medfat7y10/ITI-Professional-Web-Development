using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TicketApp.BL.Dtos.Departments;
using TicketApp.BL.Dtos.Tickets;
using TicketApp.DAL.Data.Models;
using TicketApp.DAL.Repositories.UnitOfWork;

namespace TicketApp.BL.DepartmentsManager
{
    public class DepartmentManger : IDepartmentsManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentManger(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;


        public async Task<IQueryable<DepartmentDto>> GetAllDepartments()
        {
            IQueryable<Department>? departments = await _unitOfWork.Departments.GetAllAsync();

            IQueryable<DepartmentDto>? departmentDtos = departments.Select(d => new DepartmentDto
            {
                Id = d.Id,
                Name = d.Name
            });

            return departmentDtos;
        }
        public async Task<DepartmentDto> GetDepartmentById(int id)
        {
            Department? department = await _unitOfWork.Departments.GetByIdAsync(id);

            if (department is null) return null;

            return new DepartmentDto
            {
                Id = department.Id,
                Name = department.Name
            };

        }
        public async Task<DepartmentDto> CreateDepartment(CreateDepartmentDto createDepartmentDto)
        {
            Department? department = new Department
            {
                Name = createDepartmentDto.Name
            };

            await _unitOfWork.Departments.AddAsync(department);
            await _unitOfWork.SaveAsync();

            return new DepartmentDto
            {
                Id = department.Id,
                Name = department.Name
            };
        }
        public async Task<DepartmentDto> UpdateDepartment(int id, UpdateDepartmentDto updateDepartmentDto)
        {
            Department? department = await _unitOfWork.Departments.GetByIdAsync(id);

            if (department is null) return null;

            department.Name = updateDepartmentDto.Name;

            _unitOfWork.Departments.Update(department);
            await _unitOfWork.SaveAsync();

            return new DepartmentDto
            {
                Id = department.Id,
                Name = department.Name
            };

        }
        public async Task<DepartmentDto> DeleteDepartment(int id)
        {
            Department? department = await _unitOfWork.Departments.GetByIdAsync(id);

            if (department is null) return null;

            _unitOfWork.Departments.Remove(department);
            await _unitOfWork.SaveAsync();

            return new DepartmentDto
            {
                Id = department.Id,
                Name = department.Name
            };
        }

        public async Task<DepartmentDetailsReadDto?> GetDepartmentDetailsById(int id)
        {
            Department? departmentFromDb  = await _unitOfWork.Departments.GetWithTicketsWithDevelopersById(id);

            if (departmentFromDb is null) return null;

            return new DepartmentDetailsReadDto
            {
                Id = departmentFromDb.Id,
                Name = departmentFromDb.Name,

                Tickets = departmentFromDb.Tickets
                    .Select(T => new TicketsChildReadDto
                    {
                        Id = T.Id,
                        Description = T.Description,
                        DevelopersCount = T.Developers.Count
                    })
            };
        }

    }
}
