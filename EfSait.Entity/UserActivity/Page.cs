namespace EfSait.Entity.UserActivity;

public class Page : BaseModel
{
    public Page(string text, string header, string pathImage)
    {
        Text = text;
        Header = header;
        PathImage = pathImage;
        Comments = new List<Comment>();
        Materials = new List<Material>();
    }

    protected Page()
    {
    }

    public string Text { get; set; }
    public string Header { get; set; }
    public string PathImage { get; set; }
    public List<Comment> Comments { get; set; }
    public List<Material> Materials { get; set; }
}