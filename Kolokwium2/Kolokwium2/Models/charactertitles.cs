using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Models;
[Table("character_titles")]
[PrimaryKey(nameof(CharacterId), nameof(TitleId))]
public class charactertitles
{
    public int CharacterId { get; set; }
    public int TitleId { get; set; }
    public DateTime AcquiredAt { get; set; }
    [ForeignKey(nameof(TitleId))]
    public titles Title { get; set; }
    [ForeignKey(nameof(CharacterId))]
    public characters Characters { get; set; }
}