using System.Transactions;
using Kolokwium2.DTOs;
using Kolokwium2.Models;
using Kolokwium2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium2.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CharactersController : ControllerBase
{
    private readonly IDbService _dbService;
    public CharactersController(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    [HttpGet("{characterId}")]
    public async Task<IActionResult> GetCharacterData(int characterId)
    {
        var characters = await _dbService.GetCharactersData(characterId);
        
        return Ok(characters.Select(e => new GetCharacterDTO()
        {
            firstName = e.FirstName,
            lastName = e.LastName,
            currentWeight = e.CurrentWeight,
            maxWeight = e.MaxWeight,
            backpackItems = e.backpacks.Select(p => new BackpackItemsDTO
                {
                    itemName = p.item.Name,
                    itemWeight = p.item.Weight,
                    amount = p.Amount
                }
                ).ToList(),
            titles = e.charactertitles.Select(y => new TitlesDTO
            {
                title = y.Title.Name,
                aquiredAt = y.AcquiredAt
            }).ToList()
        }));
    }
    
    [HttpPost("{clientID}/backpacks")]
    public async Task<IActionResult> AddNewOrder(int characterID, List<int> itemsIds)
    {
        foreach (var x in itemsIds)
        {
            if(!await _dbService.DoesItemExist(x))
                return NotFound($"Item with given ID - {itemsIds} doesn't exist");
        }
        

        var backpacks = new List<backpacks>();

        foreach (var VARIABLE in itemsIds)
        {
            backpacks.Add(new backpacks
            {
                Amount = 1,
                CharacterId = characterID,
                ItemId = VARIABLE
            });
        }
        
        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            await _dbService.addItemtoBackpack(backpacks);

            scope.Complete();
        }
        
    
        return Created("api/backpacks", new
        {
            
        });
    }
}