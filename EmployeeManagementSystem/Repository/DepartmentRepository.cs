using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Foundations;
using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Repository
{
    public class DepartmentRepository: GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(EmployeeManagementSystemContext context): base(context)
        {

        }

        public bool Any(Expression<Func<Department, bool>> predicate)
        {
            return context.Departments.Any(predicate);
        }
    }
}
