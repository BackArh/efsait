using EfSait.Entity.Enum;

namespace EfSait.Entity.EducationDirection;

public class Specifications:BaseModel
{
    public Specifications(FormEducationEnum formEducation, LevelEducationEnum levelEducation, double price, int periodEducation, LanguageEducationEnum languageEducation, Profile profile)
    {
        FormEducation = formEducation;
        LevelEducation = levelEducation;
        Price = price;
        PeriodEducation = periodEducation;
        LanguageEducation = languageEducation;
        Profile = profile;
    }

    protected Specifications()
    {
    }

    public FormEducationEnum FormEducation { get; set; }
    public LevelEducationEnum LevelEducation { get; set; }
    public double Price { get; set; }
    public int PeriodEducation { get; set; }
    public LanguageEducationEnum LanguageEducation { get; set; }
    public Profile Profile { get; set; }
}