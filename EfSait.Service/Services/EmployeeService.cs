using EfSait.Entity.EmploeeDivision;
using EfSait.Entity.Enum;
using EfSait.Service.Converters;
using EfSait.Service.CustomException;
using EfSait.Service.ModelsRequest.EmploeeDivision;
using EfSait.Service.Services.Interface.Providers;
using EfSait.Service.Services.Interface.Services;

namespace EfSait.Service.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeProvider _employeeProvider;

    public EmployeeService(IEmployeeProvider employeeProvider)
    {
        _employeeProvider = employeeProvider;
    }

    public async Task<Guid> CreateAsync(EmployeeRequest employeeRequest, CancellationToken cancellationToken)
    {
        if (await _employeeProvider.FindAsync(employeeRequest.Name, employeeRequest.Surname, employeeRequest.Patronymic,
                cancellationToken) != null)
            throw new ExistIsEntityException("Такой сотрудник существует");
        var employeeDb = ConverterEmployee.ConverterEmployeeRequest(employeeRequest);
        await _employeeProvider.AddAsync(employeeDb, cancellationToken);
        return employeeDb.Id;
    }

    public async Task<Employee?> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var employee = await _employeeProvider.FindAsync(id, cancellationToken);
        if (employee == null)
            throw new NotExistException("Такого сотрудника не существует");
        return employee;
    }

    public async Task<Employee> GetAsync(string name, string surname, string patronymic, CancellationToken cancellationToken)
    {
        var employee = await _employeeProvider.FindAsync(name, surname, patronymic, cancellationToken);
        if (employee == null)
            throw new NotExistException("Такого сотрудника не существует");
        return employee;
    }

    public async Task<List<Employee>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _employeeProvider.GetAllAsync(new CancellationToken());
    }

    public async Task<Employee> UpdateAsync(EmployeeRequest entityRequest, CancellationToken cancellationToken)
    {
        var employeeDb = await GetAsync(entityRequest.Name, entityRequest.Surname, entityRequest.Patronymic, cancellationToken);
        var newEmployeeDb = ConverterEmployee.ConverterEmployeeRequest(entityRequest);
        employeeDb.Achievements.AddRange(newEmployeeDb.Achievements);
        employeeDb.Articles.AddRange(newEmployeeDb.Articles);
        employeeDb.Email = newEmployeeDb.Email;
        employeeDb.Name = newEmployeeDb.Name;
        employeeDb.Patronymic = newEmployeeDb.Patronymic;
        employeeDb.Surname = newEmployeeDb.Surname;
        employeeDb.Phone = newEmployeeDb.Phone;
        employeeDb.Post = newEmployeeDb.Post;
        employeeDb.Rank = newEmployeeDb.Rank;
        employeeDb.UpdateChange = DateTime.Now;
        await _employeeProvider.UpdateAsync(employeeDb, cancellationToken);
        return employeeDb;
    }
}