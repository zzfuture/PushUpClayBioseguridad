using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repositories
{
    public class ProgramacionRepository : GenericRepository<Programacion>, IProgramacion
    {
        public ProgramacionRepository(SeguridadContext context) : base(context)
        {
        }
    }
}