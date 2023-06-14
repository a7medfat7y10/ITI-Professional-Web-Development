using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketApp.BL.Dtos.Departments;
using TicketApp.BL.MangersOfWork;
using TicketApp.DAL.Data.Models;
using TicketApp.DAL.Repositories.UnitOfWork;

namespace TicketApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IMangersOfWork _mangersOfWork;

        public DepartmentsController(IMangersOfWork mangersOfWork) => _mangersOfWork = mangersOfWork;

        [HttpGet]
        public async Task<IActionResult> GetAllDepartments() =>
            Ok(await _mangersOfWork.Departments.GetAllDepartments());

        [HttpGet("{id}", Name = "GetDepartmentById")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            DepartmentDto? departmentDto = await _mangersOfWork.Departments.GetDepartmentById(id);

            return departmentDto is null ? NotFound() : Ok(departmentDto);
        }

        [HttpGet("Details/{id}", Name = "GetDepartmentDetailsById")]
        public async Task<IActionResult> GetDepartmentDetailsById(int id)
        {
            DepartmentDetailsReadDto? departmentDetailsReadDto = await _mangersOfWork.Departments.GetDepartmentDetailsById(id);

            return departmentDetailsReadDto is null ? NotFound() : Ok(departmentDetailsReadDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment(CreateDepartmentDto createDepartmentDto)
        {
            DepartmentDto? departmentDto = await _mangersOfWork.Departments.CreateDepartment(createDepartmentDto);

            return CreatedAtAction(nameof(GetDepartmentDetailsById), new { id = departmentDto.Id }, departmentDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, UpdateDepartmentDto updateDepartmentDto)
        {
            DepartmentDto? departmentDto =  await _mangersOfWork.Departments.UpdateDepartment(id, updateDepartmentDto);

            return departmentDto is null ? NotFound() : Ok(departmentDto);
 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            DepartmentDto? departmentDto = await _mangersOfWork.Departments.DeleteDepartment(id);

            return departmentDto is null ? NotFound() : Ok(departmentDto);
        }
  

    }
}
