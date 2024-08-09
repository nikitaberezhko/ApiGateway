using Microsoft.AspNetCore.Mvc;

namespace WebApi.Authorization;

public class AuthorizationAttribute : TypeFilterAttribute
{
    public AuthorizationAttribute(params int[] roles) : base(typeof(AuthorizationFilter))
    {
        Arguments = [ roles ];
    }
}