namespace EfSait.Entity.EducationDirection;

public class Direction:BaseModel
{

    public Direction(string name, GeneralDirection generalDirection, string? pathImage)
    {
        Name = name;
        Profiles = new List<Profile>();
        GeneralDirection = generalDirection;
        PathImage = pathImage;
    }

    protected Direction()
    {
    }
    
    public string Name { get; set; }
    public string? PathImage { get; set; }
    public GeneralDirection GeneralDirection { get; set; }
    
    public List<Profile> Profiles { get; set; }
}
