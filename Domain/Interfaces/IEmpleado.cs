using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IEmpleado : IGenericRepository<Empleado>
    {
        Task<List<Empleado>> GetEmpleadoGironYPiedecueseta();
        Task<List<Empleado>> GetVigilantes();
        Task<List<object>> GetVigilanteNumero();
    }
}