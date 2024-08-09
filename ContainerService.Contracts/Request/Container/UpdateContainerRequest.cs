namespace ContainerService.Contracts.Request.Container;

public class UpdateContainerRequest
{
    public Guid Id { get; set; }
    
    public string IsoNumber { get; set; }
    
    public int TypeId { get; set; }
    
    public bool IsEngaged { get; set; }
    
    public DateTime? EngagedUntil { get; set; }
}