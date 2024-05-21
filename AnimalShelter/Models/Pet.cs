namespace AnimalShelterWPF.Models;

public partial class Pet
{
    public int IdPet { get; set; }

    public string? Name { get; set; }

    public string? Race { get; set; }

    public string? Age { get; set; }

    public char? Genre { get; set; }

    public string? DateEntry { get; set; }

    public string? Description { get; set; }

    public string? MedicalHistory { get; set; }

    public char? Status { get; set; }

    public int? IdShelter { get; set; }

    public virtual ICollection<Adoption> Adoptions { get; set; } = new List<Adoption>();

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Shelter? IdShelterNavigation { get; set; }
}
