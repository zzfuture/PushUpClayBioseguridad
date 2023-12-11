using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Entities;

public partial class Cliente : BaseEntity
{

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Contrato> Contratos { get; set; } = new List<Contrato>();
}
