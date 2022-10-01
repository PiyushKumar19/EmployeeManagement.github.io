using EmployeeManagement.ApplicationDbContext;
using EmployeeManagement.InterfacesAndSqlRepos;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeRegisterController : Controller
    {
        private readonly DatabaseContext context;
        private readonly IEmployeeRegisterCRUD cRUD;

        public EmployeeRegisterController(DatabaseContext _context, IEmployeeRegisterCRUD _cRUD)
        {
            context = _context;
            cRUD = _cRUD;
        }

        // Add Method.
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeRegisterModel model)
        {
            var employee = cRUD.Add(model);
            context.SaveChanges();
            return View(model);
        }

        public IActionResult GetEmployee(int id)
        {
            var employee = cRUD.GetEmployee(id);
            return View(employee);
        }

        public IActionResult Index()
        {
            var employees = context.EmployeesRegister;
            return View(employees);
        }

    }
}
