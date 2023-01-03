using Manager.Infra.Context;
using Manager.Domain.Entities;
using Manager.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Manager.Infra.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository // o balta nao tinha dito que nao pode herdar mais de uma classe/interface no c#? 
{
    private readonly ManagerContext _context;
    public UserRepository(ManagerContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User> GetByEmail(string email)
    {
        var user = await _context.Set<User>()
            .Where(x => x.Email.ToLower() == email.ToLower())
            .AsNoTracking()
            .ToListAsync();
        return user.FirstOrDefault();
        
    }

    public async Task<List<User>> SearchByEmail(string email)
    {
        var users = await _context.Set<User>()
            .Where(x => x.Email.ToLower().Contains(email.ToLower()))
            .AsNoTracking()
            .ToListAsync();
        return users;
    }

    public Task<List<User>> SearchByName(string name)
    {
        var users = _context.Set<User>()
            .Where(
                x => x.Name.ToLower().Contains(name)
            )
            .AsNoTracking()
            .ToListAsync();
        return users;
    }
    
}