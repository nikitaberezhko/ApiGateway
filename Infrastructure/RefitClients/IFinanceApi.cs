using CommonModel.Contracts;
using FinanceService.Contracts.Request;
using FinanceService.Contracts.Response;
using Refit;

namespace Infrastructure.RefitClients;

public interface IFinanceApi
{
    [Post("/api/v1/reports")]
    Task<CommonResponse<GenerateReportResponse>> GenerateReport(
        [Body] GenerateReportRequest request);
    
    [Get("/api/v1/reports")]
    Task<CommonResponse<GetAllReportsResponse>> GetAllReports(
        [Query] GetAllReportsRequest request);
    
    [Get("/api/v1/reports/{request.Id}")]
    Task<CommonResponse<GetReportByIdResponse>> GetReportById(GetReportByIdRequest request);
    
    [Delete("/api/v1/reports/{request.Id}")]
    Task<CommonResponse<DeleteReportResponse>> DeleteReport(DeleteReportRequest request);
}