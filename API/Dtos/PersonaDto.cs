using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PersonaDto : BaseDto
    {
            public string? IdPersona { get; set; }

    public int? IdTipoPersonaFk { get; set; }

    public DateOnly? DateReg { get; set; }

    public int? IdCiudadFk { get; set; }

    public int? IdDireccionFk { get; set; }
    }
}