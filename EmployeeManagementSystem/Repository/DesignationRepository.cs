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
    public class DesignationRepository : GenericRepository<Designation>, IDesignationRepository
    {
        public DesignationRepository(EmployeeManagementSystemContext context) : base(context)
        {
        }

    }
}