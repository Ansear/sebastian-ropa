using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;
    public class Insumo : BaseEntity
    {
        public string Nombre { get; set; }
        public double ValorUnit { get; set; }
        public int StockMin { get; set; }
        public int StockMax { get; set; }
        public ICollection<InsumoPrenda> InsumoPrendas{ get; set; }
        public ICollection<InsumoProveedor> InsumoProveedores { get; set; }
    }