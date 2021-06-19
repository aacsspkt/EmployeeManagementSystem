using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Foundations;
using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Repository
{
    public class UserRepository: GenericRepository<User>, IUserRepository
    {
        public UserRepository(EmployeeManagementSystemContext context): base(context)
        {

        }
    }
}
