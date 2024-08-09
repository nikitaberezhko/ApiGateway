namespace OrderService.Contracts.Request;

public class GetOrdersByClientIdRequest
{
    public Guid ClientId { get; set; }
}