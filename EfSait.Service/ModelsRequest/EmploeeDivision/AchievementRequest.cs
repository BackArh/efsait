namespace EfSait.Service.ModelsRequest.EmploeeDivision;

public class AchievementRequest: BaseModelRequest
{
    public string Name { get; set; }
    public DateOnly Year { get; set; }
}