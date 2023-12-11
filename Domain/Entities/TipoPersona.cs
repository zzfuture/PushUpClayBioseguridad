using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Entities;

public partial class TipoPersona : BaseEntity
{


    public string? Nombre { get; set; }

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
