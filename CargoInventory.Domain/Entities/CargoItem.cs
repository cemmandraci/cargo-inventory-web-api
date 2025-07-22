namespace CargoInventory.Domain.Entities;

public class CargoItem
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public string Description { get; private set; }
    
    public string HubCode { get; private set; }
    
    public DateTime RegisteredAt { get; private set; } = DateTime.UtcNow;

    public CargoItem(string description, string hubCode)
    {
        Description = description;
        HubCode = hubCode;
    }
}