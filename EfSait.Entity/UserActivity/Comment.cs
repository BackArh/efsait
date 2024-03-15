using System.Text;

namespace EfSait.Entity.UserActivity;

public class Comment : BaseModel
{
    public Comment(Comment? parent, string text, DateTime dateTime, User user, Page page)
    {
        Parent = parent;
        Text = text;
        DateTime = dateTime;
        User = user;
        Page = page;
    }

    protected Comment()
    {
    }

    public Comment? Parent { get; set; }
    public string Text { get; set; }
    public DateTime DateTime { get; set; }
    public User User { get; set; }
    public Page Page { get; set; }
}