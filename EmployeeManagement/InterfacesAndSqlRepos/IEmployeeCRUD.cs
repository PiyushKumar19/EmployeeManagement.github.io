using EmployeeManagement.Models;
using EmployeeManagement.ViewModel;

namespace EmployeeManagement.InterfacesAndSqlRepos
{
    public interface IEmployeeCRUD
    {
        public EmployeeModel GetEmployee(int id);
        public IEnumerable<EmployeeModel> GetAll();
        public EmployeeModel Add(EmployeeModel employee);
        public EmployeeModel Update(EmployeeModel upEmployee);
        public EmployeeModel Delete(int id);
        Task<int> AddNewEmployee(EmployeeViewModel model);
    }
}
