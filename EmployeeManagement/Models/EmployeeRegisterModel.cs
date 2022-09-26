using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class EmployeeRegisterModel
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public DepartementEnum Departement { get; set; }
        public BloodGrp BloodGroup { get; set; }
        public string MotherName { get; set; }
        public string FatherName { get; set; }
        public string ContactNo { get; set; }
    }
}
