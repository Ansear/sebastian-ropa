using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infratructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infratructure.Repositories;
public class GenericRepository<T> : IGenericRepository<T> where T  : BaseEntity
{
    private readonly RopaContext _context;

    public GenericRepository(RopaContext context)
    {
        _context = context;
    }

    public void Add(T Entity)
    {
        _context.Set<T>().Add(Entity);
    }

    public void AddRange(IEnumerable<T> Entities)
    {
        _context.Set<T>().AddRange(Entities);
    }

    public void RemoveRange(IEnumerable<T> Entities)
    {
        _context.Set<T>().RemoveRange(Entities);
    }

    public virtual IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
        return  _context.Set<T>().Where(expression);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public virtual async Task<T> GetByIdAsync(int Id)
    {
        return await _context.Set<T>().FindAsync(Id);
    }

    public void Remove(T Entity)
    {
        _context.Set<T>().Remove(Entity);
    }

    public void Update(T Entity)
    {
        _context.Set<T>().Update(Entity);
    }
}