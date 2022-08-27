using AmediaTestCrud.Application.Intefaces.Infraestructure.Data;
using AmediaTestCrud.Domain.Entities;
using AmediaTestCrud.Infraestructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace AmediaTestCrud.Infraestructure.Data.Datas;

public class UserData : IUserData
{
    private readonly TestCrudContext _context;

    public UserData(TestCrudContext context)
        => _context = context;

    public async Task Add(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task Update(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var user = await GetById(id);
        user.Eliminar();

        await Update(user);
    }

    public async Task<IEnumerable<User>> GetAll()
        => await _context.Users.Include(u => u.Role)
                               .ToListAsync();

    public async Task<User> GetByUsername(string userName)
        => await _context.Users.Include(u => u.Role)
                               .FirstOrDefaultAsync(user => user.UserName == userName);

    public async Task<IEnumerable<User>> GetUsers(Expression<Func<User, bool>> predicate)
        => await _context.Users.Where(predicate)
                               .Include(u => u.Role)
                               .ToListAsync();

    public async Task<User> GetById(int id)
        => await _context.Users.Where(u => u.Id == id)
                               .Include(u => u.Role)
                               .FirstOrDefaultAsync();
}
