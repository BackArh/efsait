using EfSait.Entity.Enum;

namespace EfSait.Entity.UserActivity;

public class User : BaseModel
{
    public User(string surname, string name, string patronymic, RoleEnum role)
    {
        Surname = surname;
        Name = name;
        Patronymic = patronymic;
        Comments = new List<Comment>();
        Role = role;
    }

    protected User()
    {
    }

    public string Surname { get; set; }
    public string Name { get; set; }
    public string Patronymic { get; set; }
    public List<Comment> Comments { get; set; }
    public RoleEnum Role { get; set; }
}