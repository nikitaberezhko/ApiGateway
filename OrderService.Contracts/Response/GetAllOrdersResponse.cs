using OrderService.Contracts.ApiModels;

namespace OrderService.Contracts.Response;

public class GetAllOrdersResponse
{
    public List<OrderApiModel> Orders { get; set; }
}