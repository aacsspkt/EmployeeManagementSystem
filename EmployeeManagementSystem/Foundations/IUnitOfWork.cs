using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Foundations
{
    public interface IUnitOfWork: IDisposable
    {
        IDepartmentRepository Departments { get; }
        IDesignationRepository Designations { get; }
        IEmployeeRepository Employees { get; }
        ILeaveRepository Leaves { get; }
        ISalaryRepository Salaries { get; }
        IUserRepository Users { get; }
        IVacancyRepository Vacancies { get; }

        Task<bool> CompleteAsync();
    }
}
