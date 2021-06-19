using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Foundations;
using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Repository
{
    public class SalaryRepository: GenericRepository<Salary>, ISalaryRepository
    {
        public SalaryRepository(EmployeeManagementSystemContext context): base(context)
        {

        }
    }
}
