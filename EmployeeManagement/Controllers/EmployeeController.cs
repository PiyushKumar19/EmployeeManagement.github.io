using EmployeeManagement.InterfacesAndSqlRepos;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeCRUD cRUD;
        private readonly IWebHostEnvironment webHostEnvironment;

        public EmployeeController(IEmployeeCRUD _cRUD, IWebHostEnvironment _webHostEnvironment)
        {
            this.cRUD = _cRUD;
            this.webHostEnvironment = _webHostEnvironment;
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
        public async Task<ViewResult> AddEmployee(bool isSuccess = false, int prodId = 0)
        {
            var model = new EmployeeViewModel();
            ViewBag.IsSuccess = isSuccess;
            ViewBag.ProductId = prodId;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        // Bind attribute is used because it was not taking IFormFile Photos from view.
        public async Task<IActionResult> AddEmployee([Bind("FirstName, LastName, ContactEmail, City, Age, EmpRole, Salary, Photos")] EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Photos != null)
                {
                    string folder = "EmployeesImages/cover/";
                    model.PhotoURL = await UploadImage(folder, model.Photos);
                }
                int Id = await cRUD.AddNewEmployee(model);
                if (Id > 0)
                {
                    return RedirectToAction(nameof(AddEmployee), new { isSuccess = true, prodId = Id });
                }
            }
            return View();
        }

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {
            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;
            string serverFolder = Path.Combine(webHostEnvironment.WebRootPath, folderPath);
            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            return "/" + folderPath;
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
            return RedirectToAction("AllEmployees");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
