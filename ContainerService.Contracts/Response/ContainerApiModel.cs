namespace ContainerService.Contracts.Response;

public class ContainerApiModel
{
    public Guid Id { get; set; }
    
    public Guid OrderId { get; set; }
    
    public string IsoNumber { get; set; }

    public int TypeId { get; set; }

    public bool IsEngaged { get; set; }
	
    public DateTime? EngagedUntil { get; set; }
}