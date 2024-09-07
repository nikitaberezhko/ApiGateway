using Asp.Versioning;
using CommonModel.Contracts;
using IdentityService.Contracts.Request;
using IdentityService.Contracts.Response;
using Infrastructure.RefitClients;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/v{v:apiVersion}/users")]
[ApiVersion(1)]
public class UserController(IIdentityApi identityApi) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CommonResponse<CreateUserResponse>>> Create(
        CreateUserRequest request)
    {
        var response = new CreatedResult(nameof(Create), 
            await identityApi.CreateUser(request));

        return response;
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<CommonResponse<DeleteUserResponse>>> Delete(
        [FromRoute] DeleteUserRequest request)
    {
        var response = await identityApi.DeleteUser(request);

        return response;
    }
    
    [HttpPost("authenticate")]
    public async Task<ActionResult<CommonResponse<AuthenticateUserResponse>>> Authenticate(
        AuthenticateUserRequest request)
    {
        var response = await identityApi.AuthenticateUser(request);
        
        return response;
    }
}