using System;
using System.Collections.Generic;

namespace AnimalShelterWPF.Models;

public partial class Pet
{
    public int IdPet { get; set; }

    public string? Name { get; set; }

    public string? Race { get; set; }

    public string? Age { get; set; }

    public char? Genre { get; set; }

    public string? DateEntry { get; set; }

    public string? MedicalHistory { get; set; }

    public char? Status { get; set; }

    public int? IdShelter { get; set; }

    public string? Description { get; set; }

    public string? Color { get; set; }

    public char? Esterilization { get; set; }

    public string? Hair { get; set; }

    public string? ImgItem { get; set; }

    public string? Numchip { get; set; }

    public string? Size { get; set; }

    public string? Species { get; set; }

    public virtual ICollection<Adoption> Adoptions { get; set; } = new List<Adoption>();

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Shelter? IdShelterNavigation { get; set; }
}
