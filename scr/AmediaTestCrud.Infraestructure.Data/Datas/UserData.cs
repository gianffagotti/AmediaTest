using AmediaTestCrud.Application.Intefaces.Infraestructure.Data;
using AmediaTestCrud.Domain.Entities;
using AmediaTestCrud.Infraestructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AmediaTestCrud.Infraestructure.Data.Datas;

public class UserData : IUserData
{
    private readonly TestCrudContext _context;

    public UserData(TestCrudContext context)
        => _context = context;

    public async Task<User> GetByUsername(string userName)
        => await _context.Users.FirstOrDefaultAsync(user => user.UserName == userName);
}
