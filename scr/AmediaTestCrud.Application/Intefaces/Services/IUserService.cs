using AmediaTestCrud.Domain.Entities;

namespace AmediaTestCrud.Application.Intefaces.Services;

public interface IUserService
{
    Task<User> ValidateUser(string userName, string password);
}