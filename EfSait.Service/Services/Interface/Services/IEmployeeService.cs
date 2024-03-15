using EfSait.Entity.EmploeeDivision;
using EfSait.Service.ModelsRequest.EmploeeDivision;

namespace EfSait.Service.Services.Interface.Services;

public interface IEmployeeService: IBaseService<Employee, EmployeeRequest>
{
    Task<Employee> GetAsync(string name,string surname, string patronymic, CancellationToken cancellationToken);

}