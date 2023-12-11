using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Entities;

public partial class Programacion : BaseEntity
{

    public int? IdContratoFk { get; set; }

    public int? IdTurnoFk { get; set; }

    public int? IdEmpleadoFk { get; set; }

    public virtual Contrato? IdContratoFkNavigation { get; set; }

    public virtual Empleado? IdEmpleadoFkNavigation { get; set; }

    public virtual Turno? IdTurnoFkNavigation { get; set; }
}
