using System.ComponentModel.DataAnnotations;

namespace Kolokwium.Models;

public class Title
{
    [Key]
    public int Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    public ICollection<CharacterTitles> CharacterTitlesCollection { get; set; } = new HashSet<CharacterTitles>();
}