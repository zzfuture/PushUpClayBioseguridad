using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Entities;

public partial class Persona : BaseEntity
{


    public int? IdPersona { get; set; }

    public int? IdTipoPersonaFk { get; set; }

    public DateOnly? DateReg { get; set; }

    public int? IdCiudadFk { get; set; }

    public int? IdDireccionFk { get; set; }

    public virtual Ciudad? IdCiudadFkNavigation { get; set; }

    public virtual Direccion? IdDireccionFkNavigation { get; set; }

    public virtual TipoPersona? IdTipoPersonaFkNavigation { get; set; }
}
