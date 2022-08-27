using AmediaTestCrud.Domain.Entities;

namespace AmediaTestCrud.Application.Intefaces.Services;

public interface IUserService
{
    Task<User> ValidateUser(string userName, string password);
    Task<IEnumerable<User>> GetAll();
    Task Create(User newUser);
    Task Update(User user);
    Task Delete(int id);
    Task<User> GetById(int id);
    Task UpdatePassword(int userId, string oldPassword, string newPassword);
}