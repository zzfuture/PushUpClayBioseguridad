using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Entities;

public partial class Turno : BaseEntity
{


    public string? Nombre { get; set; }

    public TimeOnly? HoraInicio { get; set; }

    public TimeOnly? HoraFinaliza { get; set; }

    public virtual ICollection<Programacion> Programacions { get; set; } = new List<Programacion>();
}
