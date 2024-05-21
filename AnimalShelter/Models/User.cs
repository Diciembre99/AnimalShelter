using System.ComponentModel.DataAnnotations;

namespace AnimalShelterWPF.Models;

public partial class User
{
    [Key]
    public int IdUser { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public string Dni { get; set; } = null!;

    public string? Telephone { get; set; }

    public int IdShelter { get; set; }

    public int IdCataloge { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public virtual Adoption? Adoption { get; set; }

    public virtual UserCataloge IdCatalogeNavigation { get; set; } = null!;

    public virtual Shelter IdShelterNavigation { get; set; } = null!;

    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}
