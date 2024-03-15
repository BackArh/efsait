namespace EfSait.Service.ModelsRequest.EmploeeDivision;

public class EmployeeRequest: BaseModelRequest
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Patronymic { get; set; }
    public string Post { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string Rank { get; set; }
    public List<ArticleRequest> Articles { get; set; } 
    public List<AchievementRequest> Achievements { get; set; } 
}