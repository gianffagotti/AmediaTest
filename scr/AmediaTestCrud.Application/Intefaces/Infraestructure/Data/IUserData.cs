using AmediaTestCrud.Domain.Entities;
using System.Linq.Expressions;

namespace AmediaTestCrud.Application.Intefaces.Infraestructure.Data;

public interface IUserData
{
    Task<User> GetByUsername(string userName);
    Task<IEnumerable<User>> GetUsers(Expression<Func<User, bool>> predicate);
    Task<IEnumerable<User>> GetAll();
    Task<User> GetById(int id);
    Task Add(User user);
    Task Update(User user);
    Task Delete(int id);
}