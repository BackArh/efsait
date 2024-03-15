using EfSait.Entity.EmploeeDivision;

namespace EfSait.Entity.EducationDirection;

public class GeneralDirection: BaseModel
{
    public GeneralDirection(string name, Division division, string? pathImage)
    {
        Name = name;
        Directions = new List<Direction>();
        Division = division;
        PathImage = pathImage;
    }

    protected GeneralDirection(string? pathImage)
    {
        PathImage = pathImage;
    }
    
    public string Name { get; set; }
    
    public string? PathImage { get; set; }
    public Division Division { get; set; }
    
    public List<Direction> Directions { get; set; }
}