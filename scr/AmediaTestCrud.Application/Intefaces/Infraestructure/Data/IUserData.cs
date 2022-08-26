using AmediaTestCrud.Domain.Entities;

namespace AmediaTestCrud.Application.Intefaces.Infraestructure.Data;

public interface IUserData
{
    Task<User> GetByUsername(string userName);
}