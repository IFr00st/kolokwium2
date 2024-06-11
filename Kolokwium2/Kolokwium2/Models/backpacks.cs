using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Models;

[PrimaryKey(nameof(CharacterId), nameof(ItemId))]
public class backpacks
{
    public int CharacterId { get; set; }
    public int ItemId { get; set; }
    public int Amount { get; set; }
    [ForeignKey(nameof(ItemId))]
    public items item { get; set; }
    [ForeignKey(nameof(CharacterId))]
    public characters Character { get; set; }
    
}