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
    
    public UnitOfWork(RopaContext context)
    {
        _context = context;
    }
    public ICargo _Cargos;

    public ICliente _Clientes;

    public IColor _Colores;

    public IDepartamento _Departamentos;

    public IDetalleOrden _DetalleOrdenes;

    public IDetalleVenta _DetalleVentas;

    public IEmpleado _Empleados;

    public IEmpresa _Empresas;

    public IEstado _Estados;

    public IFormaPago _FormaPagos;

    public IGenero _Generos;

    public IInsumo _Insumos;

    public IInventario _Inventarios;

    public IMunicipio _Municipios;

    public IOrden _Ordenes;

    private IPais _Pais;

    public IPrenda _Prendas;

    public IProveedor _Proveedores;

    public ITalla _Tallas;

    public ITipoEstado _TipoEstados;

    public ITipoPersona _TipoPersonas;

    public ITipoProteccion _TipoProtecciones;

    public IVenta _Ventas;

    public IPais Paises
    {
        get 
        {
            _Pais ??= new PaisRepository(_context);
            return _Pais;
        }
    }
    public ICargo Cargos
    {
        get 
        {
            _Cargos ??= new CargoRepository(_context);
            return _Cargos;
        }
    }
    public ICliente Clientes
    {
        get 
        {
            _Clientes ??= new ClienteRepository(_context);
            return _Clientes;
        }
    }
    public IColor Colores
    {
        get 
        {
            _Colores ??= new ColorRepository(_context);
            return _Colores;
        }
    }
    public IDepartamento Departamentos
    {
        get 
        {
            _Departamentos ??= new DepartamentoRepository(_context);
            return _Departamentos;
        }
    }
    public IDetalleOrden DetalleOrdenes
    {
        get 
        {
            _DetalleOrdenes ??= new DetalleOrdenRepository(_context);
            return _DetalleOrdenes;
        }
    }
    public IDetalleVenta DetalleVentas
    {
        get 
        {
            _DetalleVentas ??= new DetalleVentaRepository(_context);
            return _DetalleVentas;
        }
    }
    public IEmpleado Empleados
    {
        get 
        {
            _Empleados ??= new EmpleadoRepository(_context);
            return _Empleados;
        }
    }
    public IEmpresa Empresas
    {
        get 
        {
            _Empresas ??= new EmpresaRepository(_context);
            return _Empresas;
        }
    }
    public IEstado Estados
    {
        get 
        {
            _Estados ??= new EstadoRepository(_context);
            return _Estados;
        }
    }
    public IFormaPago FormaPagos
    {
        get 
        {
            _FormaPagos ??= new FormaPagoRepository(_context);
            return _FormaPagos;
        }
    }
    public IGenero Generos
    {
        get 
        {
            _Generos ??= new GeneroRepository(_context);
            return _Generos;
        }
    }
    public IInsumo Insumos
    {
        get 
        {
            _Insumos ??= new InsumoRepository(_context);
            return _Insumos;
        }
    }
    public IInventario Inventarios
    {
        get 
        {
            _Inventarios ??= new InventarioRepository(_context);
            return _Inventarios;
        }
    }
    public IMunicipio Municipios
    {
        get 
        {
            _Municipios ??= new MunicipioRepository(_context);
            return _Municipios;
        }
    }
    public IOrden Ordenes
    {
        get 
        {
            _Ordenes ??= new OrdenRepository(_context);
            return _Ordenes;
        }
    }
    public IPrenda Prendas
    {
        get 
        {
            _Prendas ??= new PrendaRepository(_context);
            return _Prendas;
        }
    }
    public IProveedor Proveedores
    {
        get 
        {
            _Proveedores ??= new ProveedorRepository(_context);
            return _Proveedores;
        }
    }
    public ITalla Tallas
    {
        get 
        {
            _Tallas ??= new TallaRepository(_context);
            return _Tallas;
        }
    }
    public ITipoEstado TipoEstados
    {
        get 
        {
            _TipoEstados ??= new TipoEstadoRepository(_context);
            return _TipoEstados;
        }
    }
    public ITipoPersona TipoPersonas
    {
        get 
        {
            _TipoPersonas ??= new TipoPersonaRepository(_context);
            return _TipoPersonas;
        }
    }
    public ITipoProteccion TipoProtecciones
    {
        get 
        {
            _TipoProtecciones ??= new TipoProteccionRepository(_context);
            return _TipoProtecciones;
        }
    }
    public IVenta Ventas
    {
        get 
        {
            _Ventas ??= new VentaRepository(_context);
            return _Ventas;
        }
    }
    public void Dispose()
    {
        _context.Dispose();
    }

    

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
