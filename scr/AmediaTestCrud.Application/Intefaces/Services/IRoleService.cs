using AmediaTestCrud.Domain.Entities;

namespace AmediaTestCrud.Application.Intefaces.Services;

public interface IRoleService
{
    Task<IEnumerable<Role>> GetForSelect();
}