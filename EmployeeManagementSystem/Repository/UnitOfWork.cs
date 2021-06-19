using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Foundations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmployeeManagementSystemContext _Context;

        public UnitOfWork(EmployeeManagementSystemContext context)
        {
            this._Context = context;

            this.Departments = new DepartmentRepository(_Context);
            this.Designations = new DesignationRepository(_Context);
            this.Employees = new EmployeeRepository(_Context);
            this.Leaves = new LeaveRepository(_Context);
            this.Salaries = new SalaryRepository(_Context);
            this.Users = new UserRepository(_Context);
            this.Vacancies = new VacancyRepository(_Context);

        }

        public IDepartmentRepository Departments { get; private set; }

        public IDesignationRepository Designations { get; private set; }

        public IEmployeeRepository Employees { get; private set; }

        public ILeaveRepository Leaves { get; private set; }

        public ISalaryRepository Salaries { get; private set; }

        public IUserRepository Users { get; private set; }

        public IVacancyRepository Vacancies { get; private set; }

        public async Task<bool> CompleteAsync()
        {
            return await _Context.SaveChangesAsync() > 0;
        }

        public async void Dispose()
        {
            await _Context.DisposeAsync();
        }
    }
}
