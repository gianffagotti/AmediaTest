using AmediaTestCrud.Application.Intefaces.Infraestructure.Data;
using AmediaTestCrud.Application.Intefaces.Services;
using AmediaTestCrud.Domain.Entities;

namespace AmediaTestCrud.Application.Services;

public class UserService : IUserService
{
    #region Atributos
    private readonly IUserData _userData;

    public UserService(IUserData userData)
        => _userData = userData;
    #endregion

    #region Metodos
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

    public async Task Create(User newUser)
    {
        await ValidateUsersDuplicate(newUser);

        await _userData.Add(newUser);
    }

    public async Task Update(User user)
    {
        await ValidateUsersDuplicate(user);

        await _userData.Update(user);
    }

    public async Task Delete(int id)
        => await _userData.Delete(id);

    public async Task<User> GetById(int id)
        => await _userData.GetById(id);

    public async Task UpdatePassword(int userId, string oldPassword, string newPassword)
    {
        var user = await _userData.GetById(userId);
        if (user is null)
            throw new Exception("Usuario no encontrado");

        if(!user.IsValidPassword(oldPassword))
            throw new Exception("La contraseña anterior incorrecta");

        if(user.IsValidPassword(newPassword))
            throw new Exception("La contraseña actual no puede ser la misma que la anterior");

        user.ChangePassword(newPassword);
        await _userData.Update(user);
    }
    #endregion

    #region Privados
    private async Task ValidateUsersDuplicate(User user)
    {
        var users = await _userData.GetUsers(u => (u.UserName == user.UserName || u.Document == user.Document) && u.Id != user.Id);
        if (users.Count() > 0)
        {
            var error = "";
            if (users.Any(u => u.UserName == user.UserName))
                error += "El usuario ya existe. ";

            if (users.Any(u => u.Document == user.Document))
                error += "El documento ya existe. ";

            throw new Exception(error);
        }
    }
    #endregion

}
