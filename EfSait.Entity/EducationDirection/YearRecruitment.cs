namespace EfSait.Entity.EducationDirection;

public class YearRecruitment : BaseModel
{
    public YearRecruitment(List<NumberSeats> numberSeatsList, DateOnly year, List<Profile> profiles)
    {
        NumberSeatsList = new List<NumberSeats>();
        if (numberSeatsList.Count != 0) NumberSeatsList.AddRange(numberSeatsList);
        Profiles = new List<Profile>();
        if (profiles.Count != 0) Profiles.AddRange(profiles);
        YearRecruitment_Disciplines = new List<YearRecruitment_Discipline>();
        Year = year;
    }

    protected YearRecruitment()
    {
    }

    public List<NumberSeats> NumberSeatsList { get; set; }
    public DateOnly Year { get; set; }
    public List<Profile> Profiles { get; set; }
    public List<YearRecruitment_Discipline> YearRecruitment_Disciplines { get; set; }
}