using CommonModel.Contracts;
using OrderService.Contracts.Request;
using OrderService.Contracts.Response;
using Refit;

namespace Infrastructure.RefitClients;

public interface IOrderApi
{
    [Post("/api/v1/orders")]
    Task<CommonResponse<CreateOrderResponse>> CreateOrder([Body] CreateOrderRequest request);
    
    [Put("/api/v1/orders")]
    Task<CommonResponse<UpdateOrderResponse>> UpdateOrder([Body] UpdateOrderRequest request);
    
    [Delete("/api/v1/orders/{request.Id}")]
    Task<CommonResponse<DeleteOrderResponse>> DeleteOrder(DeleteOrderRequest request);
    
    [Get("/api/v1/orders/{request.Id}")]
    Task<CommonResponse<GetOrderByIdResponse>> GetOrderById(GetOrderByIdRequest request);
    
    [Get("/api/v1/orders/clients/{request.ClientId}")]
    Task<CommonResponse<GetOrdersByClientIdResponse>> GetOrdersByClientId(
        GetOrdersByClientIdRequest request);
    
    [Get("/api/v1/orders")]
    Task<CommonResponse<GetAllOrdersResponse>> GetAllOrders(
        [Query] GetAllOrdersRequest request);
}