using ToDo.Domain.Entities;
// using System.Collections.Generic;
// using System.Threading.Tasks;


namespace ToDo.Infra.Interfaces;

public interface IBaseRepository<T> where T : Base
{
    Task<T> Create(T obj);
    Task<T> Update(T obj);
    Task<T> Get(long id);
    Task Remove(long id);
    Task<List<T>> Get();
}