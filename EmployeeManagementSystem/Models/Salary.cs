using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class Salary
    {
        [Key]
        public int ID { get; private set; }
        
        [Required]
        public Employee Employee { get; private set; }
        
        [Required]
        public int SalaryLevel { get; private set; }
               
        public decimal TotalSalaryAmount { get; private set; }
    }
}
