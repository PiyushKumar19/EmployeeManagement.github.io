namespace EmployeeManagement.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactEmail { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public RoleModel EmpRole { get; set; }
        public double Salary { get; set; }
    }
}
