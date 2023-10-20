using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infratructure.Data;
using Infratructure.Repositories;

namespace Infratructure.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly RopaContext _context;
    private IPais _Pais;

    public UnitOfWork(RopaContext context)
    {
        _context = context;
    }

    public IPais Paises
    {
        get 
        {
            _Pais ??= new PaisRepository(_context);
            return _Pais;
        }
    }
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
