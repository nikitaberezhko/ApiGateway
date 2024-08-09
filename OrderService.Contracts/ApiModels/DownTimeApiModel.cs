namespace OrderService.Contracts.ApiModels;

public class DownTimeApiModel
{
    public Guid Id { get; set; }
    
    public DateTime DateStart { get; set; }
    
    public DateTime DateEnd { get; set; }
    
    public Guid HubId { get; set; }
}