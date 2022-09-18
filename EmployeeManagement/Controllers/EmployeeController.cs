using EmployeeManagement.InterfacesAndSqlRepos;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeCRUD cRUD;

        public EmployeeController(IEmployeeCRUD _cRUD)
        {
            this.cRUD = _cRUD;
        }

        public IActionResult GetEmployee(int id)
        {
            var employee = cRUD.GetEmployee(id);
            return View(employee);
        }

        public IActionResult AllEmployees()
        {
            var employees = cRUD.GetAll();
            return View(employees);
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(EmployeeModel model)
        {
            EmployeeModel employee = new EmployeeModel()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                ContactEmail = model.ContactEmail,
                City = model.City,
                Age = model.Age,
                EmpRole = model.EmpRole,
                Salary = model.Salary
            };
            cRUD.Add(employee);
            return RedirectToAction("AllEmployees", new { Id = model.Id });
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            EmployeeModel model = cRUD.GetEmployee(Id);
            EmployeeViewModel upEmployee = new EmployeeViewModel
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                ContactEmail = model.ContactEmail,
                City = model.City,
                Age = model.Age,
                EmpRole = model.EmpRole,
                Salary = model.Salary
            };
            return View(upEmployee);
        }
        [HttpPost]
        public IActionResult Edit(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = cRUD.GetEmployee(model.Id);
                if (employee != null)
                {
                    employee.FirstName = model.FirstName;
                    employee.LastName = model.LastName;
                    employee.ContactEmail = model.ContactEmail;
                    employee.City = model.City;
                    employee.Age = model.Age;
                    employee.EmpRole = model.EmpRole;
                    employee.Salary = model.Salary;
                    EmployeeModel upEmployee = cRUD.Update(employee);
                }
                return RedirectToAction("GetEmployee");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            cRUD.Delete(id);
            return RedirectToAction("EllEmployees");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
