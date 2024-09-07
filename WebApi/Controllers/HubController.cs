using Asp.Versioning;
using CommonModel.Contracts;
using HubService.Contracts.Request;
using HubService.Contracts.Response;
using Infrastructure.RefitClients;
using Microsoft.AspNetCore.Mvc;
using WebApi.Authorization;

namespace WebApi.Controllers;

[ApiController]
[Route("api/v{v:apiVersion}/hubs")]
[ApiVersion(1)]
public class HubController(
    IHubApi hubApi) : ControllerBase
{
    [Authorization(2)]
    [HttpPost]
    public async Task<ActionResult<CommonResponse<CreateHubResponse>>> Create(
        CreateHubRequest request)
    {
        var response = new CreatedResult(nameof(Create),
            await hubApi.CreateHub(request));
        
        return response;
    } 
    
    [Authorization(2)]
    [HttpPut]
    public async Task<ActionResult<CommonResponse<UpdateHubResponse>>> Update(
        UpdateHubRequest request)
    {
        var response = await hubApi.UpdateHub(request);
        
        return response;
    }
    
    [Authorization(2)]
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<CommonResponse<DeleteHubResponse>>> Delete(
        [FromRoute] DeleteHubRequest request)
    {
        var response = await hubApi.DeleteHub(request);
        
        return response;
    }
    
    [Authorization(1,2)]
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CommonResponse<GetHubByIdResponse>>> GetById(
        [FromRoute] GetHubByIdRequest request)
    {
        var response = await hubApi.GetHubById(request);
        
        return response;
    }
    
    [Authorization(1,2)]
    [HttpGet("cities/{city}")]
    public async Task<ActionResult<CommonResponse<GetHubsByCityResponse>>> GetByCity(
        [FromRoute] GetHubsByCityRequest request)
    {
        var response = await hubApi.GetHubsByCity(request);
        
        return response;
    }
    
    [Authorization(1,2)]
    [HttpGet]
    public async Task<ActionResult<CommonResponse<GetAllHubsResponse>>> GetAll(
        [FromQuery] GetAllHubsRequest request)
    {
        var response = await hubApi.GetAllHubs(request);
        
        return response;
    }
}