using System.Diagnostics;
using EfSait.Entity.EducationDirection;
using EfSait.Entity.EmploeeDivision;
using EfSait.Service.CustomException;
using EfSait.Service.ModelsRequest.EmploeeDivision;
using EfSait.Service.Services.Interface.Providers;
using EfSait.Service.Services.Interface.Services;

namespace EfSait.Service.Services;

public class DivisionService : IDivisionService
{
    private readonly IDivisionProvider _divisionProvider;
    private readonly IEmployeeProvider _employeeProvider;


    public DivisionService(IDivisionProvider divisionProvider, IEmployeeProvider employeeProvider)
    {
        _divisionProvider = divisionProvider;
        _employeeProvider = employeeProvider;
    }

    public async Task<Guid> CreateAsync(DivisionRequest entityRequest, CancellationToken cancellationToken)
    {
        if (await _divisionProvider.FindAsync(entityRequest.Code, cancellationToken) != null)
            throw new ExistIsEntityException("Такое подразделение существует");
        var divisionDb = new Division(entityRequest.Code, entityRequest.Name, entityRequest.Phone, null, entityRequest.Abbreviation);

        if (entityRequest.BossId != null)
        {
            var boss = await _employeeProvider.FindAsync((Guid) entityRequest.BossId, cancellationToken);
            divisionDb.Boss = boss;
        }

        await _divisionProvider.AddAsync(divisionDb, cancellationToken);
        return entityRequest.Id;
    }

    public async Task<Division?> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var division = await _divisionProvider.FindAsync(id, cancellationToken);
        if (division == null)
            throw new NotExistException("Такого подразделения не существует");
        return division;
    }

    public async Task<Division> GetAsync(int code, CancellationToken cancellationToken)
    {
        var division = await _divisionProvider.FindAsync(code, cancellationToken);
        if (division == null)
            throw new NotExistException("Такого подразделения не существует");
        return division;
    }
    public async Task<List<Division>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _divisionProvider.GetAllAsync(new CancellationToken());
    }
    

    public async Task<Division> UpdateAsync(DivisionRequest entityRequest, CancellationToken cancellationToken)
    {
        var divisionDb = await GetAsync(entityRequest.Code, cancellationToken);
        divisionDb.Abbreviation = entityRequest.Abbreviation;
        divisionDb.Name = entityRequest.Name;
        divisionDb.Phone = entityRequest.Phone;
        divisionDb.UpdateChange = DateTime.Now;
        if (entityRequest.BossId != null)
        {
            var boss = await _employeeProvider.FindAsync(entityRequest.BossId.Value, cancellationToken);
            divisionDb.Boss = boss;
        }
        await _divisionProvider.UpdateAsync(divisionDb, cancellationToken);
        return divisionDb;
    }


    
}