using System.ComponentModel.DataAnnotations;

namespace Kolokwium2.Models;

public class characters
{
    [Key]
    public int Id { get; set; }
    [MaxLength(50)]
    public string FirstName { get; set; }
    [MaxLength(120)]
    public string LastName { get; set; }
    public int CurrentWeight { get; set; }
    public int MaxWeight { get; set; }
    public ICollection<backpacks> backpacks = new List<backpacks>();
    public ICollection<charactertitles> charactertitles = new List<charactertitles>();
}