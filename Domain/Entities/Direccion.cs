using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Entities;

public partial class Direccion : BaseEntity
{


    public string? TipoVia { get; set; }

    public short? NumeroPrincipal { get; set; }

    public string? LetraPrincipal { get; set; }

    public string? Bis { get; set; }

    public string? LetraSecundaria { get; set; }

    public string? CardinalPrimario { get; set; }

    public short? NumeroSecundario { get; set; }

    public string? CardinalSecundario { get; set; }

    public string? Complemento { get; set; }

    public int? IdCiudadFk { get; set; }

    public virtual Ciudad? IdCiudadFkNavigation { get; set; }

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
