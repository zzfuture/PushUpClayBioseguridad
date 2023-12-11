using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public ICiudad Ciudades { get; }
        public ICliente Clientes { get; }
        public IContrato Contratos { get; }
        public IDepartamento Departamentos { get; }
        public IDireccion Direcciones { get; }
        public IEmpleado Empleados { get; }
        public IEstado Estados { get; }
        public IPais Paises { get; }
        public IPersona Personas { get; }
        public IProgramacion Programaciones { get; }
        public IPuesto Puestos { get; }
        public IRol Roles { get; }
        public ITipoPersona TipoPersonas { get; }
        public ITurno Turnos { get; }
        public IUser Users { get; }
        Task<int> SaveAsync();
    }
}
