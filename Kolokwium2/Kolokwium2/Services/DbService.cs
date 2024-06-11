using Kolokwium2.Data;
using Kolokwium2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;
    public DbService(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<ICollection<characters>> GetCharactersData(int characterId)
    {
        return await _context.Characters
            .Include(e => e.backpacks)
            .ThenInclude(e => e.item)
            .Include(e=> e.charactertitles)
            .ThenInclude(e => e.Title)
            .Where(e => e.Id == characterId)
            .ToListAsync();
    }

    public async Task addItemtoBackpack(IEnumerable<backpacks> itemsEnumerable)
    {
        await _context.AddAsync(itemsEnumerable);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DoesItemExist(int itemId)
    {
        return await _context.Items.AnyAsync(e => e.Id == itemId);
    }
}