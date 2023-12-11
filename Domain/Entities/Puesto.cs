using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Entities;

public partial class Puesto : BaseEntity
{

    public string? Nombre { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
