using EfSait.Entity.EducationDirection;

namespace EfSait.Entity.EmploeeDivision;

public class Staff : BaseModel
{
    public Staff(Division division, Employee employee)
    {
        Division = division;
        Employee = employee;
        YearRecruitmentDisciplines = new List<YearRecruitment_Discipline>();
    }

    protected Staff()
    {
    }

    public Division Division { get; set; }
    public Employee Employee { get; set; }

    public List<YearRecruitment_Discipline> YearRecruitmentDisciplines { get; set; }
}