using AmediaTestCrud.Application.Intefaces.Infraestructure.Data;
using AmediaTestCrud.Application.Intefaces.Services;
using AmediaTestCrud.Domain.Entities;

namespace AmediaTestCrud.Application.Services;

public class UserService : IUserService
{
    private readonly IUserData _userData;

    public UserService(IUserData userData)
        => _userData = userData;

    public async Task<IEnumerable<User>> GetAll()
        => await _userData.GetAll();

    public async Task<User> ValidateUser(string userName, string password)
    {
        var user = await _userData.GetByUsername(userName);

        if (user is null &&
            !user.IsValidPassword(password)) //La contraseña deberia estar encriptada
            throw new Exception("Usuario y/o contraseña incorrecta");
        else if (!user.IsActive())
            throw new Exception("Usuario inactivado!");
        else
            return user;
    }
}
