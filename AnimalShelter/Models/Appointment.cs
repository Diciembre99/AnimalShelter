using System;
using System.Collections.Generic;

namespace AnimalShelterWPF.Models;

public partial class Appointment
{
    public int IdAppoitment { get; set; }

    public string? Name { get; set; }

    public string? Date { get; set; }

    public string? Description { get; set; }

    public int IdPet { get; set; }

    public string? Veterinary { get; set; }

    public string? Time { get; set; }

    public virtual Pet IdPetNavigation { get; set; } = null!;
}
