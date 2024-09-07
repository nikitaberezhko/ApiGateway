using Asp.Versioning;
using CommonModel.Contracts;
using Infrastructure.RefitClients;
using Microsoft.AspNetCore.Mvc;
using OrderService.Contracts.Request;
using OrderService.Contracts.Response;
using WebApi.Authorization;

namespace WebApi.Controllers;

[ApiController]
[Route("api/v{v:apiVersion}/orders")]
[ApiVersion(1)]
public class OrderController(IOrderApi orderApi) : ControllerBase
{
    [Authorization(2)]
    [HttpGet]
    public async Task<ActionResult<CommonResponse<GetAllOrdersResponse>>> GetAll(
        [FromQuery] GetAllOrdersRequest request)
    {
        var response = await orderApi.GetAllOrders(request);
        
        return response;
    }
    
    [Authorization(1,2)]
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CommonResponse<GetOrderByIdResponse>>> GetById(
        [FromRoute] GetOrderByIdRequest request)
    {
        var response = await orderApi.GetOrderById(request);
        
        return response;
    }
    
    [Authorization(1,2)]
    [HttpGet("clients/{clientId:guid}")]
    public async Task<ActionResult<CommonResponse<GetOrdersByClientIdResponse>>> GetByClientId(
        [FromRoute] GetOrdersByClientIdRequest request)
    {
        var response = await orderApi.GetOrdersByClientId(request);
        
        return response;
    }

    [Authorization(1)]
    [HttpPost]
    public async Task<ActionResult<CommonResponse<CreateOrderResponse>>> Create(
        CreateOrderRequest request)
    {
        var response = new CreatedResult(nameof(Create), 
            await orderApi.CreateOrder(request));
        
        return response;
    }

    [Authorization(1)]
    [HttpPut]
    public async Task<ActionResult<CommonResponse<UpdateOrderResponse>>> Update(
        UpdateOrderRequest request)
    {
        var response = await orderApi.UpdateOrder(request);
        
        return response;
    }

    [Authorization(1,2)]
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<CommonResponse<DeleteOrderResponse>>> Delete(
        [FromRoute] DeleteOrderRequest request)
    {
        var response = await orderApi.DeleteOrder(request);
        
        return response;
    }
}