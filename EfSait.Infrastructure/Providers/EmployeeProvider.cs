using EfSait.Entity.EmploeeDivision;
using EfSait.Service.Services.Interface;
using EfSait.Service.Services.Interface.Providers;
using Microsoft.EntityFrameworkCore;

namespace EfSait.Infrastructure.Providers;

public class EmployeeProvider : IEmployeeProvider
{
    private readonly ApplicationContext _applicationContext;

    public EmployeeProvider(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public async Task<Employee?> FindAsync(string name, string surname, string patronymic,
        CancellationToken cancellationToken)
    {
        return await _applicationContext.Employees
            .FirstOrDefaultAsync(e => e.Name == name && e.Surname == surname && e.Patronymic == patronymic,
                cancellationToken).ConfigureAwait(false);
    }

    public async Task<Employee?> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _applicationContext.Employees
            .FirstOrDefaultAsync(e => e.Id == id,
                cancellationToken).ConfigureAwait(false);
    }

    public async Task<List<Employee>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _applicationContext.Employees.ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<Guid> AddAsync(Employee employee, CancellationToken cancellationToken)
    {
        await _applicationContext.AddAsync(employee, cancellationToken);
        await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return employee.Id;
    }

    public async Task DeleteAsync(string name, string surname, string patronymic, CancellationToken cancellationToken)
    {
        var employee = await FindAsync(name, surname, patronymic, cancellationToken);
        ArgumentNullException.ThrowIfNull(employee);
        _applicationContext.Remove(employee);
        await _applicationContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Employee> UpdateAsync(Employee employee, CancellationToken cancellationToken)
    {
        _applicationContext.Update(employee);
        await _applicationContext.SaveChangesAsync(cancellationToken);
        return employee;
    }
}