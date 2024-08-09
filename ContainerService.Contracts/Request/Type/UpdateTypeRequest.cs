namespace ContainerService.Contracts.Request.Type;

public class UpdateTypeRequest
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public double PricePerDay { get; set; }
}