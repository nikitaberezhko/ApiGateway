namespace ContainerService.Contracts.Response.Type;

public class DeleteTypeResponse
{
    public int Id { get; set; }
	
    public string? Name { get; set; }

    public double PricePerDay { get; set; }
}