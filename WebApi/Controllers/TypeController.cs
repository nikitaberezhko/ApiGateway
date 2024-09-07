using Asp.Versioning;
using CommonModel.Contracts;
using ContainerService.Contracts.Request.Type;
using ContainerService.Contracts.Response.Type;
using Infrastructure.RefitClients;
using Microsoft.AspNetCore.Mvc;
using WebApi.Authorization;

namespace WebApi.Controllers;

[ApiController]
[Route("api/v{v:apiVersion}/container-types")]
[ApiVersion(1)]
public class TypeController(IContainerApi containerApi) : ControllerBase
{
    [Authorization(2)]
    [HttpPost]
    public async Task<ActionResult<CommonResponse<CreateTypeResponse>>> Create(
        CreateTypeRequest request)
    {
        var response = new CreatedResult(nameof(Create), 
            await containerApi.CreateType(request));
        
        return response;
    }
    
    [Authorization(2)]
    [HttpPut]
    public async Task<ActionResult<CommonResponse<UpdateTypeResponse>>> Update(
        UpdateTypeRequest request)
    {
        var response = await containerApi.UpdateType(request);
        
        return response;
    }
    
    [Authorization(2)]
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<CommonResponse<DeleteTypeResponse>>> Delete(
        [FromRoute] DeleteTypeRequest request)
    {
        var response = await containerApi.DeleteType(request);
        
        return response;
    }
    
    [Authorization(1,2)]
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CommonResponse<GetTypeByIdResponse>>> GetById(
        [FromRoute]GetTypeByIdRequest request)
    {
        var response = await containerApi.GetTypeById(request);
        
        return response;
    }

    [Authorization(1,2)]
    [HttpGet]
    public async Task<ActionResult<CommonResponse<GetAllTypesResponse>>> GetAll(
        [FromQuery] GetAllTypesRequest request)
    {
        var response = await containerApi.GetAllTypes(request);
        
        return response;
    }
}