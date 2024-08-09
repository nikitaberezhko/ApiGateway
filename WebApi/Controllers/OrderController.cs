using Asp.Versioning;
using CommonModel.Contracts;
using Infrastructure.RefitClients;
using Microsoft.AspNetCore.Mvc;
using OrderService.Contracts.Request;
using OrderService.Contracts.Response;

namespace WebApi.Controllers;

[ApiController]
[Route("api/v{v:apiVersion}/orders")]
[ApiVersion(1)]
public class OrderController(IOrderApi orderApi) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<CommonResponse<GetAllOrdersResponse>>> GetAll(
        GetAllOrdersRequest request)
    {
        var response = await orderApi.GetAllOrders(request);
        
        return response;
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CommonResponse<GetOrderByIdResponse>>> GetById(
        [FromRoute] GetOrderByIdRequest request)
    {
        var response = await orderApi.GetOrderById(request);
        
        return response;
    }
    
    [HttpGet("clients/{clientId:guid}")]
    public async Task<ActionResult<CommonResponse<GetOrdersByClientIdResponse>>> GetByClientId(
        [FromRoute] GetOrdersByClientIdRequest request)
    {
        var response = await orderApi.GetOrdersByClientId(request);
        
        return response;
    }

    [HttpPost]
    public async Task<ActionResult<CommonResponse<CreateOrderResponse>>> Create(
        CreateOrderRequest request)
    {
        var response = await orderApi.CreateOrder(request);
        
        return response;
    }

    [HttpPut]
    public async Task<ActionResult<CommonResponse<UpdateOrderResponse>>> Update(
        UpdateOrderRequest request)
    {
        var response = await orderApi.UpdateOrder(request);
        
        return response;
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<CommonResponse<DeleteOrderResponse>>> Delete(
        [FromRoute] DeleteOrderRequest request)
    {
        var response = await orderApi.DeleteOrder(request);
        
        return response;
    }
}