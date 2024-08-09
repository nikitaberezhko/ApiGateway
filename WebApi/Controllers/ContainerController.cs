using Asp.Versioning;
using CommonModel.Contracts;
using ContainerService.Contracts.Request.Container;
using ContainerService.Contracts.Response.Container;
using Infrastructure.RefitClients;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/v{v:apiVersion}/containers")]
[ApiVersion(1)]
public class ContainerController(IContainerApi containerApi) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CommonResponse<CreateContainerResponse>>> Create(
        CreateContainerRequest request)
    {
        var response = await containerApi.CreateContainer(request);
        
        return response;
    }

    
    [HttpPut]
    public async Task<ActionResult<CommonResponse<UpdateContainerResponse>>> Update(
        UpdateContainerRequest request)
    {
        var response = await containerApi.UpdateContainer(request);
        
        return response;
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult<CommonResponse<DeleteContainerResponse>>> Delete(
        [FromRoute] DeleteContainerRequest request)
    {
        var response = await containerApi.DeleteContainer(request);
        
        return response;
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<CommonResponse<GetContainerByIdResponse>>> GetById([FromRoute] GetContainerByIdRequest request)
    {
        var response = await containerApi.GetContainerById(request);
        
        return response;
    }
    
    
    [HttpGet("iso-numbers/{isoNumber}")]
    public async Task<ActionResult<CommonResponse<GetContainerByIsoResponse>>> GetByIso(
        [FromRoute] GetContainerByIsoRequest request)
    {
        var response = await containerApi.GetContainerByIso(request);
        
        return response;
    }
    
    
    [HttpGet]
    public async Task<ActionResult<CommonResponse<GetContainersByTypeIdResponse>>> GetByTypeId(
        GetContainersByTypeIdRequest request)
    {
        var response = await containerApi.GetContainersByTypeId(request);
        
        return response;
    }
}