using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketApp.BL.DepartmentsManager;
using TicketApp.DAL.Repositories.UnitOfWork;

namespace TicketApp.BL.MangersOfWork
{
    public class MangersOfWork : IMangersOfWork
    {
        private readonly IUnitOfWork _unitOfWork;
        private IDepartmentsManager _departmentsManager;


        public MangersOfWork(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public IDepartmentsManager Departments => _departmentsManager ?? new DepartmentManger(_unitOfWork);

    }
}
