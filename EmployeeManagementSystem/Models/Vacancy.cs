using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class Vacancy
    {
        [Key]
        public int ID { get; private set; }
        
        [Required]
        public Designation Designation { get; private set; }
        
        [Required]
        public int NumberOfVacancy { get; private set; }

    }
}
