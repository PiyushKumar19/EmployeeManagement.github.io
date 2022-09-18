using EmployeeManagement.Models;

namespace EmployeeManagement.InterfacesAndSqlRepos
{
    public interface IEmployeeCRUD
    {
        public EmployeeModel GetEmployee(int id);
        public IEnumerable<EmployeeModel> GetAll();
        public EmployeeModel Add(EmployeeModel employee);
        public EmployeeModel Update(EmployeeModel upEmployee);
        public EmployeeModel Delete(int id);
    }
}
