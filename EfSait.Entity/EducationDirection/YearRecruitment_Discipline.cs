using EfSait.Entity.EmploeeDivision;

namespace EfSait.Entity.EducationDirection;

public class YearRecruitment_Discipline : BaseModel
{
    public YearRecruitment_Discipline(Discipline discipline, YearRecruitment yearRecruitment)
    {
        Discipline = discipline;
        YearRecruitment = yearRecruitment;
        Staves = new List<Staff>();
    }

    protected YearRecruitment_Discipline()
    {
    }

    public Discipline Discipline { get; set; }
    public YearRecruitment YearRecruitment { get; set; }
    public List<Staff> Staves { get; set; }
}