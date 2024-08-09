namespace IdentityService.Contracts.Request;

public class AuthenticateUserRequest
{
    public string Email { get; set; }
    
    public string Password { get; set; }
}