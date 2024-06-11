using System.ComponentModel.DataAnnotations;

namespace Kolokwium.Models;

public class Item
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Weight  { get; set; }

    public ICollection<Backpack> Backpacks { get; set; } = new HashSet<Backpack>();
}