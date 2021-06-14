using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class User
    {
        public int ID { get; private set; }
        public string Username { get; private set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
