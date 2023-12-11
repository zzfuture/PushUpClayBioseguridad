using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICliente : IGenericRepository<Cliente>
    {
        Task<IEnumerable<Cliente>> GetClienteBucaramanga();
        Task<IEnumerable<Cliente>> GetAntiguedad5annos();
        
    }
}