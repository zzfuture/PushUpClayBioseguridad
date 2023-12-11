using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repositories
{
    public class CiudadRepository : GenericRepository<Ciudad>, ICiudad
    {
        private readonly SeguridadContext _context;

        public CiudadRepository(SeguridadContext context) : base(context)
        {
            _context = context;
        }
    }
}