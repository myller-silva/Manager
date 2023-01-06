using Manager.Core.Exceptions;
using Manager.Domain.Entities;
using Manager.Infra.Context; 
using Manager.Infra.Interfaces;
using Microsoft.EntityFrameworkCore; //pesquisar so mais sobre EntityFrameworkCore

// using System.Linq;
// using System.Threading.Tasks;


namespace Manager.Infra.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T:Base
{
    private readonly ManagerContext _context;

    public BaseRepository(ManagerContext context)
    {
        _context = context;
    }
    
    public virtual async Task<T> Create(T obj)
    {
        _context.Add(obj);
        await _context.SaveChangesAsync();
        return obj;
    }

    public virtual async Task<T> Update(T obj)
    {
        // _context.Update(obj);
        _context.Entry(obj).State = EntityState.Modified; // pesquisar mais sobre
        await _context.SaveChangesAsync();
        return obj;
    }

    public virtual async Task Remove(long id)
    {
        var obj = await Get(id);
        if (obj != null)
        {
            _context.Remove(obj);
            await _context.SaveChangesAsync();
        }
        // else
        // {
        //     throw new DomainException("Usuario não existe");
        // }
    }


    public virtual async Task<T> Get(long id)
    {
        var obj = await _context.Set<T>() // pesquisar mais sobre
            .AsNoTracking() // serve para nao traquear os objetos (obs: o que é traquear?)
            .Where(x => x.Id == id)
            .ToListAsync();
        
        return obj.FirstOrDefault(); 
        
    }
    
    public virtual async Task<List<T>> Get()
    {
        return await _context.Set<T>()
            .AsNoTracking()
            .ToListAsync();
    }
}