using System.ComponentModel.DataAnnotations;

namespace Kolokwium2.Models;

public class titles
{
    [Key]
    public int Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }
    public ICollection<charactertitles> charactertitles = new List<charactertitles>();
}