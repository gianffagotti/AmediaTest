using AmediaTestCrud.Application.Intefaces.Infraestructure.Data;
using AmediaTestCrud.Domain.Entities;
using AmediaTestCrud.Infraestructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AmediaTestCrud.Infraestructure.Data.Datas;

public class RoleData : IRoleData
{
    private readonly TestCrudContext _context;

    public RoleData(TestCrudContext context)
        => _context = context;

    public async Task<IEnumerable<Role>> GetRoles(Expression<Func<Role, bool>> predicate)
        => await _context.Roles.Where(predicate).ToListAsync();
}
