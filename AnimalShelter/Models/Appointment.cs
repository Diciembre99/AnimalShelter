namespace AnimalShelterWPF.Models;

public partial class Appointment
{
    public int IdAppoitment { get; set; }

    public string Name { get; set; } = null!;

    public TimeOnly? Date { get; set; }

    public string? Description { get; set; }

    public int IdPet { get; set; }

    public string? Veterinary { get; set; }

    public virtual Pet IdPetNavigation { get; set; } = null!;
}
