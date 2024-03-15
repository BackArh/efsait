using EfSait.Entity.EducationDirection;
using EfSait.Service.CustomException;
using EfSait.Service.ModelsRequest.EducationDirection;
using EfSait.Service.Services.Interface.Providers;
using EfSait.Service.Services.Interface.Services;

namespace EfSait.Service.Services;

public class DisciplineService:IDisciplineService
{
    private readonly IDisciplineProvider _disciplineProvider;

    public DisciplineService(IDisciplineProvider disciplineProvider)
    {
        _disciplineProvider = disciplineProvider;
    }

    public async Task<Guid> CreateAsync(DisciplineRequest entityRequest, CancellationToken cancellationToken)
    {
        if (await _disciplineProvider.FindAsync(entityRequest.Name, cancellationToken) != null)
            throw new ExistIsEntityException("Такая дисциплина существует");
        var disciplineDb = new Discipline(entityRequest.Name);
        await _disciplineProvider.AddAsync(disciplineDb, cancellationToken);
        return disciplineDb.Id;
    }

    public async Task<Discipline?> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var discipline = await _disciplineProvider.FindAsync(id, cancellationToken);
        if (discipline == null)
            throw new NotExistException("Такой дисциплины не существует");
        return discipline;
    }

    public async Task<Discipline> GetAsync(string name, CancellationToken cancellationToken)
    {
        var discipline = await _disciplineProvider.FindAsync(name, cancellationToken);
        if (discipline == null)
            throw new NotExistException("Такой дисциплины не существует");
        return discipline;
    }

    public async Task<List<Discipline>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _disciplineProvider.GetAllAsync(new CancellationToken());
    }

    public async Task<Discipline> UpdateAsync(DisciplineRequest entityRequest, CancellationToken cancellationToken)
    {
        var disciplineDb = await GetAsync(entityRequest.Name, cancellationToken);
        disciplineDb.Name = entityRequest.Name;
        disciplineDb.UpdateChange = DateTime.Now;
        await _disciplineProvider.UpdateAsync(disciplineDb, cancellationToken);
        return disciplineDb;
    }
}