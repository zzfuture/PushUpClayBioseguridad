using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repositories;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly SeguridadContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public UnitOfWork(SeguridadContext context)
        {
            _context = context;
        }
        private ICiudad _Ciudades;
        private ICliente _Clientes;
        private IContrato _Contratos;
        private IDepartamento _Departamentos;
        private IDireccion _Direcciones;
        private IEmpleado _Empleados;
        private IEstado _Estados;
        private IPais _Paises;
        private IPersona _Personas;
        private IProgramacion _Programaciones;
        private IPuesto _Puestos;
        private IRol _Roles;
        private ITipoPersona _TipoPersonas;
        private ITurno _Turnos;
        private IUser _Users;

        public ICiudad Ciudades // 2611
        {
            get
            {
                if (_Ciudades == null)
                {
                    _Ciudades = new CiudadRepository(_context); // Remember putting the base in the repository of this entity
                }
                return _Ciudades;
            }
        }
        public ICliente Clientes // 2611
        {
            get
            {
                if (_Clientes == null)
                {
                    _Clientes = new ClienteRepository(_context); // Remember putting the base in the repository of this entity
                }
                return _Clientes;
            }
        }
        public IContrato Contratos // 2611
        {
            get
            {
                if (_Contratos == null)
                {
                    _Contratos = new ContratoRepository(_context); // Remember putting the base in the repository of this entity
                }
                return _Contratos;
            }
        }
        public IDepartamento Departamentos // 2611
        {
            get
            {
                if (_Departamentos == null)
                {
                    _Departamentos = new DepartamentoRepository(_context); // Remember putting the base in the repository of this entity
                }
                return _Departamentos;
            }
        }
        public IDireccion Direcciones // 2611
        {
            get
            {
                if (_Direcciones == null)
                {
                    _Direcciones = new DireccionRepository(_context); // Remember putting the base in the repository of this entity
                }
                return _Direcciones;
            }
        }
        public IEmpleado Empleados // 2611
        {
            get
            {
                if (_Empleados == null)
                {
                    _Empleados = new EmpleadoRepository(_context); // Remember putting the base in the repository of this entity
                }
                return _Empleados;
            }
        }
        public IEstado Estados // 2611
        {
            get
            {
                if (_Estados == null)
                {
                    _Estados = new EstadoRepository(_context); // Remember putting the base in the repository of this entity
                }
                return _Estados;
            }
        }
        public IPais Paises // 2611
        {
            get
            {
                if (_Paises == null)
                {
                    _Paises = new PaisRepository(_context); // Remember putting the base in the repository of this entity
                }
                return _Paises;
            }
        }
        public IPersona Personas // 2611
        {
            get
            {
                if (_Personas == null)
                {
                    _Personas = new PersonaRepository(_context); // Remember putting the base in the repository of this entity
                }
                return _Personas;
            }
        }
        public IProgramacion Programaciones // 2611
        {
            get
            {
                if (_Programaciones == null)
                {
                    _Programaciones = new ProgramacionRepository(_context); // Remember putting the base in the repository of this entity
                }
                return _Programaciones;
            }
        }
        public IPuesto Puestos // 2611
        {
            get
            {
                if (_Puestos == null)
                {
                    _Puestos = new PuestoRepository(_context); // Remember putting the base in the repository of this entity
                }
                return _Puestos;
            }
        }
        public IRol Roles // 2611
        {
            get
            {
                if (_Roles == null)
                {
                    _Roles = new RolRepository(_context); // Remember putting the base in the repository of this entity
                }
                return _Roles;
            }
        }
        public ITipoPersona TipoPersonas // 2611
        {
            get
            {
                if (_TipoPersonas == null)
                {
                    _TipoPersonas = new TipoPersonaRepository(_context); // Remember putting the base in the repository of this entity
                }
                return _TipoPersonas;
            }
        }
        public ITurno Turnos // 2611
        {
            get
            {
                if (_Turnos == null)
                {
                    _Turnos = new TurnoRepository(_context); // Remember putting the base in the repository of this entity
                }
                return _Turnos;
            }
        }
        public IUser Users // 2611
        {
            get
            {
                if (_Users == null)
                {
                    _Users = new UserRepository(_context); // Remember putting the base in the repository of this entity
                }
                return _Users;
            }
        }

        public void Dispose(){
            _context.Dispose();
        }
        public Task<int> SaveAsync() // 2611
        {
            return _context.SaveChangesAsync();
        }
    }
}