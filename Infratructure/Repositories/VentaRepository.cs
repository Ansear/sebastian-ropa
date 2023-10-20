using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infratructure.Data;

namespace Infratructure.Repositories;
public class VentaRepository : GenericRepository<Venta>, IVenta
{
    private readonly RopaContext _context;

    public VentaRepository(RopaContext context) : base(context)
    {
        _context = context;
    }
}