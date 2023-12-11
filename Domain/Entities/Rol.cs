using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Entities;

public partial class Rol : BaseEntity
{


    public string Nombre { get; set; } = null!;

    public virtual ICollection<User> IdUsuarioFks { get; set; } = new List<User>();
}
