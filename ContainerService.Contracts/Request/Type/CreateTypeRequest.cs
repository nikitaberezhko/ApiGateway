namespace ContainerService.Contracts.Request.Type;

public class CreateTypeRequest
{
    public string Name { get; set; }
    
    public double PricePerDay { get; set; }
}