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
    public class ClienteRepository : GenericRepository<Cliente>, ICliente
    {
        private readonly SeguridadContext _context;

        public ClienteRepository(SeguridadContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Cliente>> GetClienteBucaramanga()
        {
            var query = await (from cliente in _context.Clientes
                join persona in _context.Personas on cliente.Id equals persona.IdPersona
                join ciudad in _context.Ciudads on persona.IdCiudadFk equals ciudad.Id
                where ciudad.Nombre == "Bucaramanga"
                select cliente
                ).ToListAsync();
            return query;
        }
        public async Task<IEnumerable<Cliente>> GetAntiguedad5annos()
        {
            var fiveYearsAgo = DateOnly.FromDateTime(DateTime.Today.AddYears(-5));
            var query = await (from cliente in _context.Clientes
                join persona in _context.Personas on cliente.Id equals persona.IdPersona
                where persona.DateReg < fiveYearsAgo
                select cliente
                ).ToListAsync();
            return query;
        }
    }
}