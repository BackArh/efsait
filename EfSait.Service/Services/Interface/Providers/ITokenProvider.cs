using EfSait.Entity.UserActivity;
using EfSait.Service.ModelsRequest.UserActivity;

namespace EfSait.Service.Services.Interface.Providers;

public interface ITokenProvider
{
    Token CreateToken(User user);
}