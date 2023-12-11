﻿using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Entities;

public partial class Estado : BaseEntity
{


    public string? Descripcion { get; set; }

    public virtual ICollection<Contrato> Contratos { get; set; } = new List<Contrato>();
}
