using EmployeeManagement.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.ViewModel
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactEmail { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public RoleModel EmpRole { get; set; }
        public double Salary { get; set; }
        [NotMapped]
        public IFormFile Photos { get; set; }
        public string? PhotoURL { get; set; }
    }
}
