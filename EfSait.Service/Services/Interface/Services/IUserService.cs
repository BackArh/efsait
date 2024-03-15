using EfSait.Entity.UserActivity;
using EfSait.Service.ModelsRequest.UserActivity;

namespace EfSait.Service.Services.Interface.Services;

public interface IUserService: IBaseService<User, UserRequest>
{
    Task<Token> LoginAsync(string surname, string name, string patronymic, CancellationToken cancellationToken);
}