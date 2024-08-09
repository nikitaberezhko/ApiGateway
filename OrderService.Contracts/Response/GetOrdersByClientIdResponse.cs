using OrderService.Contracts.ApiModels;

namespace OrderService.Contracts.Response;

public class GetOrdersByClientIdResponse
{
    public List<OrderApiModel> Orders { get; set; }
}