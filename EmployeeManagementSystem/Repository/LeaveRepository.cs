using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Foundations;
using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Repository
{
    public class LeaveRepository: GenericRepository<Leave>, ILeaveRepository
    {
        public LeaveRepository(EmployeeManagementSystemContext context): base(context)
        {

        }
    }
}
