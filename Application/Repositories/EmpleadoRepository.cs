using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repositories
{
    public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleado
    {
        private readonly SeguridadContext _context;

        public EmpleadoRepository(SeguridadContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Empleado>> GetVigilantes()
        {
            var query = await (from empleado in _context.Empleados
                    join puesto in _context.Turnos on empleado.IdPuestoFk equals puesto.Id
                    where puesto.Nombre == "Vigilante"
                    select empleado
                    ).ToListAsync();
            return query;
        }
        public async Task<List<object>> GetVigilanteNumero()
        {
            var query = await (from empleado in _context.Empleados
                    join puesto in _context.Turnos on empleado.IdPuestoFk equals puesto.Id
                    where puesto.Nombre == "Vigilante"
                    select new {
                        Id = empleado.Id,
                        Tel = empleado.Telefono
                    }
                    ).ToListAsync<object>();
            return query;
        }
        public async Task<List<Empleado>> GetEmpleadoGironYPiedecueseta()
        {
            var query = await (from empleado in _context.Empleados
                join persona in _context.Personas on empleado.Id equals persona.IdPersona
                join ciudad in _context.Ciudads on persona.IdCiudadFk equals ciudad.Id
                where ciudad.Nombre == "Giron" || ciudad.Nombre == "Piedecuesta"
                select empleado
                ).ToListAsync();
            return query;
        }
    }
}