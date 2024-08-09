namespace ContainerService.Contracts.Request.Container;

public class CreateContainerRequest
{
    public string IsoNumber { get; set; }
    
    public int TypeId { get; set; }
}