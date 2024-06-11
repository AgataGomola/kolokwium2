using System.ComponentModel.DataAnnotations;
using Kolokwium.Models;

namespace Kolokwium.DTOs;

public class CharacterDTO
{
    public string FirstName { get; set; } = string.Empty;
    [MaxLength(120)]
    public string LastName { get; set; } = string.Empty;
    public int CurrentWeight { get; set; }
    public int MaxWeight { get; set; }
    
    public ICollection<ItemDTO> BackpackItems { get; set; } = new HashSet<ItemDTO>();
    public ICollection<TitleDTO> Titles { get; set; } = new HashSet<TitleDTO>();
}