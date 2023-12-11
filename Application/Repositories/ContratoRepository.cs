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
    public class ContratoRepository : GenericRepository<Contrato>, IContrato
    {
        private readonly SeguridadContext _context;

        public ContratoRepository(SeguridadContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<object>> GetContratoActivo()
        {
            var query = await (from contrato in _context.Contratos
                join cliente in _context.Clientes on contrato.IdClienteFk equals cliente.Id
                join empleado in _context.Empleados on contrato.IdEmpleadoFk equals empleado.Id
                               select new
                               {
                    IdContrato = contrato.Id,
                    NombreCliente = cliente.Nombre,
                    NombreEmpleado = empleado.Nombre
                }
                ).ToListAsync<object>();
            return query;
        }
    }
}