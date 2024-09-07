using Asp.Versioning;
using AutoMapper;
using CommonModel.Contracts;
using ContainerService.Contracts.Request.Container;
using ContainerService.Contracts.Response.Container;
using Infrastructure.RefitClients;
using Microsoft.AspNetCore.Mvc;
using Services.Models.Request;
using Services.Services.Interfaces;
using WebApi.Authorization;
using WebApi.Models.Request;
using WebApi.Models.Response;

namespace WebApi.Controllers;

[ApiController]
[Route("api/v{v:apiVersion}/containers")]
[ApiVersion(1)]
public class ContainerController(
    IContainerApi containerApi,
    ICompositeContainerFacade compositeContainerFacade,
    IMapper mapper) : ControllerBase
{
    [Authorization(2)]
    [HttpPost]
    public async Task<ActionResult<CommonResponse<CreateContainerResponse>>> Create(
        CreateContainerRequest request)
    {
        var response = new CreatedResult(nameof(Create), 
            await containerApi.CreateContainer(request));
        
        return response;
    }

    [Authorization(2)]
    [HttpPut]
    public async Task<ActionResult<CommonResponse<UpdateContainerResponse>>> Update(
        UpdateContainerRequest request)
    {
        var response = await containerApi.UpdateContainer(request);
        
        return response;
    }

    [Authorization(2)]
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<CommonResponse<DeleteContainerResponse>>> Delete(
        [FromRoute] DeleteContainerRequest request)
    {
        var response = await containerApi.DeleteContainer(request);
        
        return response;
    }

    [Authorization(1,2)]
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CommonResponse<GetContainerByIdResponse>>> GetById(
        [FromRoute] GetContainerByIdRequest request)
    {
        var response = await containerApi.GetContainerById(request);
        
        return response;
    }

    [Authorization(1, 2)]
    [HttpGet("{id:guid}/types")]
    public async Task<ActionResult<CommonResponse<GetCompositeContainerResponse>>> 
        GetCompositeById([FromRoute] GetCompositeContainerRequest request)
    {
        var result =
            await compositeContainerFacade
                .CompositeContainerWithType(mapper.Map<GetCompositeContainerModel>(request));
        var response = new CommonResponse<GetCompositeContainerResponse>
            { Data = mapper.Map<GetCompositeContainerResponse>(result) };
        
        return response;
    }
    
    [Authorization(1,2)]
    [HttpGet("iso-numbers/{isoNumber}")]
    public async Task<ActionResult<CommonResponse<GetContainerByIsoResponse>>> GetByIso(
        [FromRoute] GetContainerByIsoRequest request)
    {
        var response = await containerApi.GetContainerByIso(request);
        
        return response;
    }
    
    [Authorization(1,2)]
    [HttpGet]
    public async Task<ActionResult<CommonResponse<GetContainersByTypeIdResponse>>> GetByTypeId(
        GetContainersByTypeIdRequest request)
    {
        var response = await containerApi.GetContainersByTypeId(request);
        
        return response;
    }
}