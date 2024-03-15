using EfSait.Entity.EducationDirection;
using EfSait.Entity.EmploeeDivision;
using EfSait.Service.CustomException;
using EfSait.Service.ModelsRequest.EducationDirection;
using EfSait.Service.Services.Interface.Providers;
using EfSait.Service.Services.Interface.Services;

namespace EfSait.Service.Services;

public class YearRecruitmentsDisciplineService: IYearRecruitmentsDisciplineService
{
    private readonly IYearRecruitmentsDisciplineProvider _yearRecruitmentsDisciplineProvider;
    private readonly IDisciplineProvider _disciplineProvider;
    private readonly IYearRecruitmentsProvider _yearRecruitmentsProvider;
    private readonly IStaffProvider _staffProvider;

    public YearRecruitmentsDisciplineService(IYearRecruitmentsDisciplineProvider yearRecruitmentsDisciplineProvider, IDisciplineProvider disciplineProvider, IYearRecruitmentsProvider yearRecruitmentsProvider, IStaffProvider staffProvider)
    {
        _yearRecruitmentsDisciplineProvider = yearRecruitmentsDisciplineProvider;
        _disciplineProvider = disciplineProvider;
        _yearRecruitmentsProvider = yearRecruitmentsProvider;
        _staffProvider = staffProvider;
    }

    public async Task<Guid> CreateAsync(YearRecruitment_DisciplineRequest direction, CancellationToken cancellationToken)
    {
        if (await _yearRecruitmentsDisciplineProvider.FindAsync(direction.Id, cancellationToken) != null)
            throw new ExistIsEntityException("Такая связь существует.");
        var discipline = await _disciplineProvider.FindAsync(direction.DisciplineId, cancellationToken);
        if (discipline == null)
            throw new NotExistException("Такой дисциплины не существует");
        var yearRecruitment = await _yearRecruitmentsProvider.FindAsync(direction.YearRecruitmentId, cancellationToken);
        if (yearRecruitment == null)
            throw new NotExistException("Такого года набора не существует");
        var yearRecruitmentDisciplineDb = new YearRecruitment_Discipline(discipline, yearRecruitment); 
        await _yearRecruitmentsDisciplineProvider.AddAsync(yearRecruitmentDisciplineDb, cancellationToken);
        return direction.Id;
    }

    public async Task<YearRecruitment_Discipline> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var yearRecruitmentDiscipline = await _yearRecruitmentsDisciplineProvider.FindAsync(id, cancellationToken);
        if (yearRecruitmentDiscipline == null)
            throw new NotExistException("Такой связи не существует");
        return yearRecruitmentDiscipline;
    }

    public async Task<List<YearRecruitment_Discipline>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _yearRecruitmentsDisciplineProvider.GetAllAsync(new CancellationToken());
    }

    public async Task<YearRecruitment_Discipline> UpdateAsync(YearRecruitment_DisciplineRequest entityRequest, CancellationToken cancellationToken)
    {
        var yearRecruitmentDisciplineDb = await GetAsync(entityRequest.Id, cancellationToken);
        var discipline = await _disciplineProvider.FindAsync(entityRequest.DisciplineId, cancellationToken);
        if (discipline == null)
            throw new NotExistException("Такой дисциплины не существует");
        var yearRecruitment = await _yearRecruitmentsProvider.FindAsync(entityRequest.YearRecruitmentId, cancellationToken);
        if (yearRecruitment == null)
            throw new NotExistException("Такого года набора не существует");
        yearRecruitmentDisciplineDb.Discipline = discipline;
        yearRecruitmentDisciplineDb.YearRecruitment = yearRecruitment;
        yearRecruitmentDisciplineDb.UpdateChange = DateTime.Now;
        await _yearRecruitmentsDisciplineProvider.UpdateAsync(yearRecruitmentDisciplineDb, cancellationToken);
        return yearRecruitmentDisciplineDb;
    }

    public async Task AttachAsync(Guid idStaff, Guid idYearRecruitmentsDiscipline, CancellationToken cancellationToken)
    {
        var staff = await _staffProvider.FindAsync(idStaff, cancellationToken);
        if (staff == null)
            throw new NotExistException("Такого связи(staff) не существует");
        var yearRecruitmentDiscipline = await _yearRecruitmentsDisciplineProvider.FindAsync(idYearRecruitmentsDiscipline, cancellationToken);
        if (yearRecruitmentDiscipline == null)
            throw new NotExistException("Такого связи(yearRecruitmentDiscipline) не существует");
        await _staffProvider.AttachAsync(idStaff, idYearRecruitmentsDiscipline, cancellationToken);
        await _yearRecruitmentsDisciplineProvider.AttachAsync(idYearRecruitmentsDiscipline, idStaff, cancellationToken);
    }
}