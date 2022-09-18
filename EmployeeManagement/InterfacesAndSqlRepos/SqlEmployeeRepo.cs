
using EmployeeManagement.ApplicationDbContext;
using EmployeeManagement.Models;

namespace EmployeeManagement.InterfacesAndSqlRepos
{
    public class SqlEmployeeRepo : IEmployeeCRUD
    {
        private readonly DatabaseContext context;

        public SqlEmployeeRepo(DatabaseContext _context)
        {
            this.context = _context;
        }

        public EmployeeModel Add(EmployeeModel employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
            return employee;
        }

        public EmployeeModel Delete(int id)
        {
            var employee = context.Employees.Find(id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            return employee;
        }

        public IEnumerable<EmployeeModel> GetAll()
        {
            return context.Employees;
        }

        public EmployeeModel GetEmployee(int id)
        {
            var employee = context.Employees.Find(id);
            return employee;
        }

        public EmployeeModel Update(EmployeeModel upEmployee)
        {
            var newEmployee = context.Employees.Attach(upEmployee);
            newEmployee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return upEmployee;
        }
    }
}
