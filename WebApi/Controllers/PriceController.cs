using Asp.Versioning;
using CommonModel.Contracts;
using ContainerService.Contracts.Request.Price;
using ContainerService.Contracts.Response.Price;
using Infrastructure.RefitClients;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/v{v:apiVersion}/price")]
[ApiVersion(1)]
public class PriceController(IContainerApi containerApi)
{
    [HttpGet]
    public async Task<ActionResult<CommonResponse<GetContainersPriceResponse>>> GetPrice(
        GetContainersPriceRequest request)
    {
        var response = await containerApi.GetPrice(request);
        
        return response;
    }
}