using CompanyMVC.Data;
using CompanyMVC.Models;
using CompanyMVC.Services.EmpServ;
using CompanyMVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmpServ _empServ;
        private readonly ApplicationContext _applicationContext;

        public EmployeeController(IEmpServ empServ,ApplicationContext applicationContext)
        {
            _empServ = empServ;
            _applicationContext = applicationContext;
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEmpViewModel request)
        {
            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                DateOfBirth = request.DateOfBirth,
                Department = request.Department,
                Name = request.Name,
                Salary = request.Salary
            };
            await _applicationContext.Employees.AddAsync(employee);
            await _applicationContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var emp = await _applicationContext.Employees.ToListAsync();
            
            return View(emp);
        }
        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var emp = await _applicationContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if (emp != null)
            {
                var emplo = new Employee
                {
                    Id = emp.Id,
                    DateOfBirth = emp.DateOfBirth,
                    Department = emp.Department,
                    Email = emp.Email,
                    Name = emp.Name,
                    Salary = emp.Salary
                };
                return await Task.Run(()=> View("View",emplo));
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> View(Employee employee)
        {
            var emp = await _applicationContext.Employees.FindAsync(employee.Id);
            if(emp != null)
            {
                emp.Salary = employee.Salary;
                emp.DateOfBirth = employee.DateOfBirth;
                emp.Name = employee.Name;
                emp.DateOfBirth = employee.DateOfBirth;
                emp.Department = employee.Department;
                await _applicationContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Employee employee)
        {
            var emp = await _applicationContext.Employees.FindAsync(employee.Id);
            if(emp != null)
            {
                _applicationContext.Employees.Remove(emp);
                await _applicationContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
