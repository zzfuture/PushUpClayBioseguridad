using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Entities;

public partial class Empleado : BaseEntity
{


    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Telefono { get; set; }

    public int? IdPuestoFk { get; set; }

    public virtual ICollection<Contrato> Contratos { get; set; } = new List<Contrato>();

    public virtual Puesto? IdPuestoFkNavigation { get; set; }

    public virtual ICollection<Programacion> Programacions { get; set; } = new List<Programacion>();
}
