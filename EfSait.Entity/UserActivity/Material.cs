using EfSait.Entity.Enum;

namespace EfSait.Entity.UserActivity;

public class Material : BaseModel
{
    public Material(string pathToFile, TypeFileEnum typeFile, Page page)
    {
        PathToFile = pathToFile;
        TypeFile = typeFile;
        Page = page;
    }

    protected Material()
    {
    }

    public string PathToFile { get; set; }
    public TypeFileEnum TypeFile { get; set; }
    public Page Page { get; set; }
}