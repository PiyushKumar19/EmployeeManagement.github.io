
using EmployeeManagement.ApplicationDbContext;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModel;

namespace EmployeeManagement.InterfacesAndSqlRepos
{
    public class SqlEmployeeRepo : IEmployeeCRUD
    {
        private readonly DatabaseContext context;

        public SqlEmployeeRepo(DatabaseContext _context)
        {
            this.context = _context;
        }

        // To Add employee.
        public EmployeeModel Add(EmployeeModel employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
            return employee;
        }

        // To add employee with photo and asynchronously.
        public async Task<int> AddNewEmployee(EmployeeViewModel model)
        {
            var newEmployee = new EmployeeModel()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                ContactEmail = model.ContactEmail,
                City = model.City,
                Age = model.Age,
                EmpRole = model.EmpRole,
                Salary = model.Salary,
                PhotoURL = model.PhotoURL
            };
            await context.Employees.AddAsync(newEmployee);
            await context.SaveChangesAsync();

            return newEmployee.Id;
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
