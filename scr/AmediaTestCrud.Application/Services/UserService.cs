using AmediaTestCrud.Application.Intefaces.Infraestructure.Data;
using AmediaTestCrud.Application.Intefaces.Services;
using AmediaTestCrud.Domain.Entities;

namespace AmediaTestCrud.Application.Services;

public class UserService : IUserService
{
    private readonly IUserData _userData;

    public UserService(IUserData userData)
        => _userData = userData;

    public async Task<User> ValidateUser(string userName, string password)
    {
        var user = await _userData.GetByUsername(userName);

        if (user is not null &&
            user.IsValidPassword(password) &&
            user.IsActive())
            return user;
        else
            throw new Exception("Usuario y/o contraseña incorrecta");
    }
}
