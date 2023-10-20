using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infratructure.Data;

namespace Infratructure.Repositories;
public class DetalleVentaRepository : GenericRepository<DetalleVenta>, IDetalleVenta
{
    private readonly RopaContext _context;

    public DetalleVentaRepository(RopaContext context) : base(context)
    {
        _context = context;
    }
}