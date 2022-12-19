using CompanyMVC.ViewModel;

namespace CompanyMVC.Services.EmpServ
{
    public interface IEmpServ
    {
        Task AddEmployee(AddEmpViewModel request);
        Task GetAllEmployees();
    }
}
