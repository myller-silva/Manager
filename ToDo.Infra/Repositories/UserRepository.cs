using ToDo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ToDo.Infra.Context;
using ToDo.Infra.Interfaces;

namespace ToDo.Infra.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository // o balta nao tinha dito que nao pode herdar mais de uma classe/interface no c#? 
{
    private readonly ManagerContext _context;
    public UserRepository(ManagerContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User> GetByEmail(string email)
    {
        // var user = await _context.Set<User>() pq ta errado? é pq sempre cria uma nova tabela?
            var user = await _context.Users 
            .Where(x => x.Email.ToLower() == email.ToLower())
            .AsNoTracking()
            .ToListAsync();
        return user.FirstOrDefault();
        
    }

    public async Task<List<User>> SearchByEmail(string email)
    {
        var users = await _context.Users
            .Where(x => x.Email.ToLower().Contains(email.ToLower()))
            .AsNoTracking()
            .ToListAsync();
        return users;
    }

    public Task<List<User>> SearchByName(string name)
    {
        var users = _context.Users
            .Where(
                x => x.Name.ToLower().Contains(name)
            )
            .AsNoTracking()
            .ToListAsync();
        return users;
    }
    
}