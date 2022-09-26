using EmployeeManagement.ApplicationDbContext;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModel;

namespace EmployeeManagement.InterfacesAndSqlRepos
{
    public class SqlEmployeeRegisterRepo:IEmployeeRegisterCRUD
    {
        private readonly DatabaseContext context;

        public SqlEmployeeRegisterRepo(DatabaseContext _context)
        {
            this.context = _context;
        }

        // To Add employee.
        public EmployeeRegisterModel Add(EmployeeRegisterModel employee)
        {
            context.EmployeesRegister.Add(employee);
            context.SaveChanges();
            return employee;
        }

        // To add employee with photo and asynchronously.
        public async Task<int> AddNewEmployee(EmployeeRegisterModel model)
        {
            var newEmployee = new EmployeeRegisterModel();
            await context.EmployeesRegister.AddAsync(newEmployee);
            await context.SaveChangesAsync();

            return newEmployee.EmployeeId;
        }

        public EmployeeRegisterModel Delete(int id)
        {
            var employee = context.EmployeesRegister.Find(id);
            if (employee != null)
            {
                context.EmployeesRegister.Remove(employee);
                context.SaveChanges();
            }
            return employee;
        }

        public IEnumerable<EmployeeRegisterModel> GetAll()
        {
            return context.EmployeesRegister;
        }

        public EmployeeRegisterModel GetEmployee(int id)
        {
            var employee = context.EmployeesRegister.Find(id);
            return employee;
        }

        public EmployeeRegisterModel Update(EmployeeRegisterModel upEmployee)
        {
            var newEmployee = context.EmployeesRegister.Attach(upEmployee);
            newEmployee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return upEmployee;
        }
    }
}
