using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public partial class Designation
    {
        [Required]
        public int Id { get; private set; }
        
        [Required]
        [MaxLength(200)]
        public string DesignationName { get; private set; }
        
        [Required]
        public Department Department { get; private set; }
        
        [Required]
        [Column(TypeName = "decimal(9,2)")]
        public decimal InitialSalary { get; private set; }

    }
}
