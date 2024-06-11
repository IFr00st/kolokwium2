namespace Kolokwium2.DTOs;

public class GetCharacterDTO
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public int currentWeight { get; set; }
    public int maxWeight { get; set; }
    public ICollection<BackpackItemsDTO> backpackItems = new List<BackpackItemsDTO>();
    public ICollection<TitlesDTO> titles = new List<TitlesDTO>();
}

public class BackpackItemsDTO
{
    public string itemName { get; set; }
    public int itemWeight { get; set; }
    public int amount { get; set; }
}

public class TitlesDTO
{
    public string title { get; set; }
    public DateTime aquiredAt { get; set; }
    
}