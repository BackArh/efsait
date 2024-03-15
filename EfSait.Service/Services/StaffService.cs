using EfSait.Entity.EmploeeDivision;
using EfSait.Entity.UserActivity;
using EfSait.Service.CustomException;
using EfSait.Service.ModelsRequest.EmploeeDivision;
using EfSait.Service.Services.Interface.Providers;
using EfSait.Service.Services.Interface.Services;

namespace EfSait.Service.Services;

public class StaffService: IStaffService
{
    private readonly IStaffProvider _staffProvider;
    private readonly IDivisionProvider _divisionProvider;
    private readonly IEmployeeProvider _employeeProvider;
    private readonly IYearRecruitmentsDisciplineProvider _yearRecruitmentsDisciplineProvider;

    public StaffService(IStaffProvider staffProvider, IDivisionProvider divisionProvider, IEmployeeProvider employeeProvider, IYearRecruitmentsDisciplineProvider yearRecruitmentsDisciplineProvider)
    {
        _staffProvider = staffProvider;
        _divisionProvider = divisionProvider;
        _employeeProvider = employeeProvider;
        _yearRecruitmentsDisciplineProvider = yearRecruitmentsDisciplineProvider;
    }

    public async Task<Guid> CreateAsync(StaffRequest entityRequest, CancellationToken cancellationToken)
    {
        if (await _staffProvider.FindAsync(entityRequest.Id, cancellationToken) != null)
            throw new ExistIsEntityException("Такая связь существует.");
        
        var division = await _divisionProvider.FindAsync(entityRequest.DivisionId, cancellationToken);
        if (division == null)
            throw new NotExistException("Такого подразделения не существует");
        var employee = await _employeeProvider.FindAsync(entityRequest.EmployeeId, cancellationToken);
        if (employee == null)
            throw new NotExistException("Такого сотрудника не существует");
        var staffDb = new Staff(division, employee);
        await _staffProvider.AddAsync(staffDb, cancellationToken);
        return entityRequest.Id;
    }

    public async Task<Staff> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var staff = await _staffProvider.FindAsync(id, cancellationToken);
        if (staff == null)
            throw new NotExistException("Такой связи не существует");
        return staff;
    }

    public async Task<List<Staff>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _staffProvider.GetAllAsync(new CancellationToken());
    }

    public async Task<Staff> UpdateAsync(StaffRequest direction, CancellationToken cancellationToken)
    {
        var staffDb =await GetAsync(direction.Id, cancellationToken);
        var division = await _divisionProvider.FindAsync(direction.DivisionId, cancellationToken);
        if (division == null)
            throw new NotExistException("Такого подразделения не существует");
        var employee = await _employeeProvider.FindAsync(direction.EmployeeId, cancellationToken);
        if (employee == null)
            throw new NotExistException("Такого сотрудника не существует");
        staffDb.Division = division;
        staffDb.Employee = employee;
        staffDb.UpdateChange = DateTime.Now;
        await _staffProvider.UpdateAsync(staffDb, cancellationToken);
        return staffDb;
    }

    public async Task AttachAsync(Guid idStaff, Guid idYearRecruitmentDiscipline, CancellationToken cancellationToken)
    {
        var staff = await _staffProvider.FindAsync(idStaff, cancellationToken);
        if (staff == null)
            throw new NotExistException("Такого связи(staff) не существует");
        var yearRecruitmentDiscipline = await _yearRecruitmentsDisciplineProvider.FindAsync(idYearRecruitmentDiscipline, cancellationToken);
        if (yearRecruitmentDiscipline == null)
            throw new NotExistException("Такого связи(yearRecruitmentDiscipline) не существует");
        await _staffProvider.AttachAsync(idStaff, idYearRecruitmentDiscipline, cancellationToken);
    }
}