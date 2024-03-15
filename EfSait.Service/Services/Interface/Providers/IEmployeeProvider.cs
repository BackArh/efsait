using EfSait.Entity.EmploeeDivision;

namespace EfSait.Service.Services.Interface.Providers;

public interface IEmployeeProvider
{
    Task<Guid> AddAsync(Employee entity, CancellationToken cancellationToken);
    Task<Employee?> FindAsync(string name, string surname,string patronymic, CancellationToken cancellationToken);
    Task<Employee?> FindAsync(Guid id, CancellationToken cancellationToken);
    Task DeleteAsync(string name, string surname,string patronymic, CancellationToken cancellationToken);
    Task<Employee> UpdateAsync(Employee entity, CancellationToken cancellationToken);
    Task<List<Employee>> GetAllAsync(CancellationToken cancellationToken);
}