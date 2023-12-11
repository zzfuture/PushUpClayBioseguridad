using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ProgramacionDto : BaseDto
    {
            public int? IdContratoFk { get; set; }

    public int? IdTurnoFk { get; set; }

    public int? IdEmpleadoFk { get; set; }
    }
}