using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infratructure.Data;

namespace Infratructure.Repositories;
public class InsumoRepositoryv : GenericRepository<Insumo>, IInsumo
{
    private readonly RopaContext _context;

    public InsumoRepositoryv(RopaContext context) : base(context)
    {
        _context = context;
    }
}