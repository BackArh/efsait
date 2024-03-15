using EfSait.Entity.EducationDirection;

namespace EfSait.Entity.EmploeeDivision;

public class Division : BaseModel
{
    public Division(int code, string name, string phone, Employee? boss, string abbreviation)
    {
        Code = code;
        Name = name;
        Phone = phone;
        Boss = boss;
        Abbreviation = abbreviation;
        Staves = new List<Staff>();
        Profiles = new List<Profile>();
    }

    protected Division(string abbreviation)
    {
        Abbreviation = abbreviation;
    }

    public int Code { get; set; }
    public string Abbreviation { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public Employee? Boss { get; set; }
    public List<Staff> Staves { get; set; } 
    public List<Profile> Profiles { get; set; } 
}