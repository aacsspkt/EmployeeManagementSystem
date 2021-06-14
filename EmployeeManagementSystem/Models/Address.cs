using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        public string StreetName { get; private set; }
        
        [Required]
        [MaxLength(200)]
        public string City { get; private set; }
        
        [Required]
        public int WardNo { get; private set; }
        
        [Required]
        [MaxLength(200)]
        public string District { get; private set; }
        
        [Required]
        [MaxLength(200)]
        public string State { get; private set; }
        
        [Required]
        [MaxLength(200)]
        public string Country { get; set; }

    }
}
