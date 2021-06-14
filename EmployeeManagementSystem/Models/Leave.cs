using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class Leave
    {
        [Key]
        public int Id { get; private set; }
        
        [Required]
        public Employee Employee { get; private set; }
        
        [Required]
        public DateTime LeaveStartDate { get; private set; }
        
        [Required]
        public int NumberOfDays { get; private set; }
        
        [MaxLength(500)]
        public string LeaveReason { get; private set; }
    }
}
