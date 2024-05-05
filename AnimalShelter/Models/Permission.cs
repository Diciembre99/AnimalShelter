using System;
using System.Collections.Generic;

namespace AnimalShelterWPF.Models;

public partial class Permission
{
    public int IdPermission { get; set; }

    public int? IdUser { get; set; }

    public int? IdRol { get; set; }

    public virtual Rol? IdRolNavigation { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}
