using CommonModel.Contracts;
using IdentityService.Contracts.Request;
using Infrastructure.RefitClients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Authorization;

public class AuthorizationFilter(
    IIdentityApi identityApi,
    params int[] roles) : IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var token = context.HttpContext.Request.Headers["Authorization"].ToString();
        if (!token.Any())
        {
            CreateAuthorizationFailedResponse(
                context,
                "Access token not found",
                "Access token is required to access this endpoint",
                StatusCodes.Status401Unauthorized);
            return;
        }
        
        token = token.Split()[1];
        var response = identityApi.AuthorizeUser(
            new AuthorizeUserRequest
            {
                Token = token
            }).Result;

        if (response.IsSuccessStatusCode == false)
            throw response.Error;
        
        if (!roles.Contains(response.Content.Data!.RoleId))
            CreateAuthorizationFailedResponse(context, 
                "Access denied",
                "You don't have access to this endpoint",
                StatusCodes.Status403Forbidden);
    }

    private void CreateAuthorizationFailedResponse(
        AuthorizationFilterContext context,
        string title,
        string message,
        int statusCode)
    {
        var response = new CommonResponse<Empty>
        {
            Data = null,
            Error = new Error
            {
                Title = title,
                Message = message,
                StatusCode = statusCode
            }
        };

        context.HttpContext.Response.StatusCode = statusCode;
        context.Result = new JsonResult(response);
    }
}

record Empty;