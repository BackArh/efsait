using EfSait.Entity.EmploeeDivision;

namespace EfSait.Entity.EducationDirection;

public class Profile : BaseModel
{
    public Profile(string name, string code, string description,  List<Specifications> specificationsList,List<YearRecruitment> listYear, Direction direction)
    {
        Name = name;
        Code = code;
        Description = description;
        Direction = direction;
        SpecificationsList = new List<Specifications>();
        if(specificationsList.Count !=0) SpecificationsList.AddRange(specificationsList);
        YearRecruitments = new List<YearRecruitment>();
        if (listYear.Count != 0) YearRecruitments.AddRange(listYear);
    }

    protected Profile()
    {
    }
    public Direction Direction { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    
    public string Description { get; set; }
    public List<Specifications> SpecificationsList { get; set; }
    public List<YearRecruitment> YearRecruitments { get; set; }
}