using FinanceService.Contracts.ApiModels;

namespace FinanceService.Contracts.Response;

public class GetAllReportsResponse
{
    public List<ShortenedReportApiModel> Reports { get; set; }
}