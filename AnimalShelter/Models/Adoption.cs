namespace AnimalShelterWPF.Models;

public partial class Adoption
{
    public int IdAdoption { get; set; }

    public int PetId { get; set; }

    public TimeOnly DateAdoption { get; set; }

    public int IdUser { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;

    public virtual Pet Pet { get; set; } = null!;
}
