using Kolokwium2.Models;

namespace Kolokwium2.Services;

public interface IDbService
{
    Task<ICollection<characters>> GetCharactersData(int characterId);
    
    Task<bool> DoesItemExist(int itemId);
    Task addItemtoBackpack(IEnumerable<backpacks> itemsEnumerable);
}