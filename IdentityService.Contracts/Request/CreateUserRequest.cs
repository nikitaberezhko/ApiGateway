namespace IdentityService.Contracts.Request;

public class CreateUserRequest
{
    public int RoleId { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public string Name { get; set; }
    
    public string Phone { get; set; }
}