using EmployeeManagement.Models;

namespace EmployeeManagement.InterfacesAndSqlRepos
{
    public interface IEmployeeRegisterCRUD
    {
        public EmployeeRegisterModel GetEmployee(int id);
        public IEnumerable<EmployeeRegisterModel> GetAll();
        public EmployeeRegisterModel Add(EmployeeRegisterModel employee);
        public EmployeeRegisterModel Update(EmployeeRegisterModel upEmployee);
        public EmployeeRegisterModel Delete(int id);
    }
}
