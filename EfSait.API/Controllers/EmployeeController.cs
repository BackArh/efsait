using EfSait.Entity.EmploeeDivision;
using EfSait.Entity.UserActivity;
using EfSait.Service.ModelsRequest.EmploeeDivision;
using EfSait.Service.ModelsRequest.UserActivity;
using EfSait.Service.Services.Interface.Services;
using Microsoft.AspNetCore.Mvc;

namespace EfSait.API.Controllers;


public class EmployeeController : BaseController<Employee,EmployeeRequest, IEmployeeService>
{
    public EmployeeController(IEmployeeService service) : base(service)
    {
    }
    
    [HttpGet("GetByFullName")]
    public async Task<Employee> GetByFullName(string name, string surname, string patronymic) 
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(surname);
        ArgumentNullException.ThrowIfNull(patronymic);
        var employee = await _service.GetAsync(name, surname, patronymic, new CancellationToken());
        return employee;
    }
}