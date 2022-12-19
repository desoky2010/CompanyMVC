using CompanyMVC.Data;
using CompanyMVC.Models;
using CompanyMVC.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace CompanyMVC.Services.EmpServ
{
    public class EmpServ : IEmpServ
    {
        private readonly ApplicationContext _applicationContext;

        public EmpServ(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public async Task AddEmployee(AddEmpViewModel request)
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
        }

        public void GetAllEmployees()
        {
            var emp =  _applicationContext.Employees.ToList();
            
        }

        Task IEmpServ.GetAllEmployees()
        {
            throw new NotImplementedException();
        }
    }
}
