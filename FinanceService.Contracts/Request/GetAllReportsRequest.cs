namespace FinanceService.Contracts.Request;

public class GetAllReportsRequest
{
    public int Page { get; set; }
    
    public int PageSize { get; set; }
}