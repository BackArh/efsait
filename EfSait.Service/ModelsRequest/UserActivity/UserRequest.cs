namespace EfSait.Service.ModelsRequest.UserActivity;

public class UserRequest: BaseModelRequest
{
    public string Surname { get; set; }
    public string Name { get; set; }
    public string Patronymic { get; set; }
    public string Role { get; set; }
}