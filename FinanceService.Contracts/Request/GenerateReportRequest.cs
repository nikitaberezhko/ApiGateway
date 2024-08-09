namespace FinanceService.Contracts.Request;

public class GenerateReportRequest
{
    public DateOnly EndDate { get; set; }
    
    public int Period { get; set; }
}