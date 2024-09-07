using Asp.Versioning;
using CommonModel.Contracts;
using Infrastructure.RefitClients;
using LogisticService.Contracts.Request;
using LogisticService.Contracts.Response;
using Microsoft.AspNetCore.Mvc;
using WebApi.Authorization;

namespace WebApi.Controllers;

[ApiController]
[Route("api/v{v:apiVersion}/locations")]
[ApiVersion(1)]
public class LocationController(ILogisticApi logisticApi)
{
    [Authorization(2)]
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CommonResponse<GetLocationResponse>>> GetLocation(
        [FromRoute] GetLocationRequest request)
    {
        var response = await logisticApi.GetLocation(request);
        
        return response;
    }

    [Authorization(2)]
    [HttpGet]
    public async Task<ActionResult<CommonResponse<GetContainersLocationResponse>>>
        GetContainersLocation(GetContainersLocationRequest request)
    {
        var response = await logisticApi.GetLocationsList(request);
        
        return response;
    }

    [Authorization(1,2)]
    [HttpGet("orders/{orderId:guid}")]
    public async Task<ActionResult<CommonResponse<GetContainersLocationByOrderIdResponse>>>
        GetContainersLocationByOrderId([FromRoute] GetContainersLocationByOrderIdRequest request)
    {
        var response = await logisticApi.GetOrderLocations(request);
        
        return response;
    }
    
    [Authorization(2)]
    [HttpPut]
    public async Task<ActionResult<CommonResponse<UpdateContainersLocationResponse>>>
        UpdateContainersLocation(UpdateContainersLocationRequest request)
    {
        var response = await logisticApi.UpdateLocationsList(request);
        
        return response;
    }
}