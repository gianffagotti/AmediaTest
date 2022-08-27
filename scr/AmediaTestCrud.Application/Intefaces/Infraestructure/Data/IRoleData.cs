using AmediaTestCrud.Domain.Entities;
using System.Linq.Expressions;

namespace AmediaTestCrud.Application.Intefaces.Infraestructure.Data;

public interface IRoleData
{
    Task<IEnumerable<Role>> GetRoles(Expression<Func<Role, bool>> predicate);
}