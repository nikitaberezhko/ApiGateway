namespace IdentityService.Contracts.Response;

public class DeleteUserResponse
{
    public Guid Id { get; set; }
    
    public int RoleId { get; set; }
    
    public string Name { get; set; }
    
    public string Phone { get; set; }
}