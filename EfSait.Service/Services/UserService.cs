using EfSait.Entity.Enum;
using EfSait.Entity.UserActivity;
using EfSait.Service.CustomException;
using EfSait.Service.ModelsRequest.UserActivity;
using EfSait.Service.Services.Interface.Providers;
using EfSait.Service.Services.Interface.Services;

namespace EfSait.Service.Services;

public class UserService : IUserService
{
    private readonly IUserProvider _userProvider;
    private readonly ITokenProvider _tokenProvider;

    public UserService(IUserProvider userProvider, ITokenProvider tokenProvider)
    {
        _userProvider = userProvider;
        _tokenProvider = tokenProvider;
    }

    public async Task<Guid> CreateAsync(UserRequest entityRequest, CancellationToken cancellationToken)
    {
        if (await _userProvider.FindAsync(entityRequest.Id, new CancellationToken()) != null)
            throw new ExistIsEntityException("Такой пользователь существует");
        var userDb = new User(entityRequest.Surname,
            entityRequest.Name,
            entityRequest.Patronymic,
            (RoleEnum) Enum.Parse(typeof(RoleEnum),
                entityRequest.Role, true));
        await _userProvider.AddAsync(userDb, cancellationToken);
        return userDb.Id;
    }


    public async Task<User> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await _userProvider.FindAsync(id, cancellationToken);
        if (user == null)
            throw new NotExistException("Такого пользователя не существует");
        return user;
    }

    public async Task<User> UpdateAsync(UserRequest entityRequest, CancellationToken cancellationToken)
    {
        var userDb = await GetAsync(entityRequest.Id, cancellationToken);
        userDb.Name = entityRequest.Name;
        userDb.Patronymic = entityRequest.Patronymic;
        userDb.Surname = entityRequest.Surname;
        userDb.Role = (RoleEnum) Enum.Parse(typeof(RoleEnum), entityRequest.Role, true);
        userDb.UpdateChange = DateTime.Now;
        await _userProvider.UpdateAsync(userDb, cancellationToken);
        return userDb;
    }

    public Task<List<User>> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Token> LoginAsync(string surname, string name, string patronymic, CancellationToken cancellationToken)
    {
        var user = await _userProvider.FindAsync(surname, name, patronymic, cancellationToken);
        if (user == null)
            throw new NotExistException("Такого пользавателя не существует.");
        return _tokenProvider.CreateToken(user);
    }
}