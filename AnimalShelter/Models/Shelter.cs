using System;
using System.Collections.Generic;

namespace AnimalShelterWPF.Models;

public partial class Shelter
{
    public int IdShelter { get; set; }

    public string Name { get; set; } = null!;

    public string? Direccion { get; set; }

    public string Cif { get; set; } = null!;

    public virtual ICollection<Donation> Donations { get; set; } = new List<Donation>();

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
