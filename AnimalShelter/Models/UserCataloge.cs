namespace AnimalShelterWPF.Models;

public partial class UserCataloge
{
    public int IdCataloge { get; set; }

    public string Name { get; set; } = null!;

    public char Type { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
