using EfSait.Entity.Enum;

namespace EfSait.Entity.EmploeeDivision;

public class Employee : BaseModel
{
    protected Employee()
    {
    }

    public Employee(string name, string surname, string patronymic, PostEnum post, string? phone, string? email,
        RankEnum rank, List<Achievement>? achievements, List<Article>? articles)
    {
        Name = name;
        Surname = surname;
        Patronymic = patronymic;
        Post = post;
        Phone = phone;
        Email = email;
        Rank = rank;
        Articles = new List<Article>();
        if(articles != null) Articles.AddRange(articles);
        Achievements = new List<Achievement>();
        if(achievements != null) Achievements.AddRange(achievements);
        Staves = new List<Staff>();
    }

    public string Name { get; set; }
    public string Surname { get; set; }
    public string Patronymic { get; set; }
    public PostEnum Post { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public RankEnum Rank { get; set; }
    public List<Article> Articles { get; set; } 
    public List<Achievement> Achievements { get; set; } 
    public List<Staff> Staves { get; set; } 
}