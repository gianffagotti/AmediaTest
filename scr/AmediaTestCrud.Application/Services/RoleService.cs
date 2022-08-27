using AmediaTestCrud.Application.Intefaces.Infraestructure.Data;
using AmediaTestCrud.Application.Intefaces.Services;
using AmediaTestCrud.Domain.Entities;

namespace AmediaTestCrud.Application.Services;

public class RoleService : IRoleService
{
    private readonly IRoleData _roleData;

    public RoleService(IRoleData roleData)
        => _roleData = roleData;

    public async Task<IEnumerable<Role>> GetForSelect()
        => await _roleData.GetRoles(r => r.Active == 1);
}
