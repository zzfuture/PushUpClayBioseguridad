using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class TurnoDto : BaseDto
    {
            public string? Nombre { get; set; }

    public TimeOnly? HoraInicio { get; set; }

    public TimeOnly? HoraFinaliza { get; set; }
    }
}