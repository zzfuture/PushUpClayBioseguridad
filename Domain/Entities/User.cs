using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Entities;

public partial class User : BaseEntity
{

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Rol> IdRolFks { get; set; } = new List<Rol>();
}
