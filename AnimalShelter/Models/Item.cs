namespace AnimalShelterWPF.Models;

public partial class Item
{
    public int IdItem { get; set; }

    public string? Name { get; set; }

    public int? Stock { get; set; }

    public string? TypeItem { get; set; }

    public string? AnimalType { get; set; }

    public int? IdShelter { get; set; }

    public char? Status { get; set; }

    public float? Price { get; set; }

    public string? Description { get; set; }

    public string? imgItem { get; set; }

    public virtual Shelter? IdShelterNavigation { get; set; }
}
