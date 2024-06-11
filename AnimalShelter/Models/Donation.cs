using System;
using System.Collections.Generic;

namespace AnimalShelterWPF.Models;

public partial class Donation
{
    public int IdDonation { get; set; }

    public string? TypeDonation { get; set; }

    public decimal? Quantity { get; set; }

    public string? Donor { get; set; }

    public string? DateDonation { get; set; }

    public int IdShelter { get; set; }

    public virtual Shelter IdShelterNavigation { get; set; } = null!;
}
