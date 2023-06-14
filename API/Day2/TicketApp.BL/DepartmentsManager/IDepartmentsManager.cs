using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketApp.BL.Dtos.Departments;

namespace TicketApp.BL.DepartmentsManager
{
    public interface IDepartmentsManager
    {
        Task<IQueryable<DepartmentDto>> GetAllDepartments();
        Task<DepartmentDto> GetDepartmentById(int id);
        Task<DepartmentDetailsReadDto?> GetDepartmentDetailsById(int id);
        Task<DepartmentDto> CreateDepartment(CreateDepartmentDto createDepartmentDto);
        Task<DepartmentDto> UpdateDepartment(int id, UpdateDepartmentDto updateDepartmentDto);
        Task<DepartmentDto> DeleteDepartment(int id);

    }
}
