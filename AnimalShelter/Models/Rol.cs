namespace AnimalShelterWPF.Models;

public partial class Rol
{
    public int IdRol { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public char Type { get; set; }

    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}
