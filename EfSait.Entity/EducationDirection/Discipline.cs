namespace EfSait.Entity.EducationDirection;

public class Discipline : BaseModel
{
    public Discipline(string name)
    {
        Name = name;
        YearRecruitment_Disciplines = new List<YearRecruitment_Discipline>();
    }

    protected Discipline()
    {
    }

    public string Name { get; set; }
    public List<YearRecruitment_Discipline> YearRecruitment_Disciplines { get; set; }
}