using Laboratory.Application.DTOs.Reports;
using Laboratory.Framework.Common;

namespace Laboratory.Application.Services;

public interface IReportService
{
    Task<OperationResult<PagedResult<DepartmentWorkListItemDto>>> GetDepartmentWorkListAsync(int departmentId, int pageNumber, int pageSize, CancellationToken cancellationToken);
    Task<OperationResult<FinalReportDto>> GetFinalReportAsync(int testRequestId, CancellationToken cancellationToken);
    Task<OperationResult<DailyStatisticsDto>> GetDailyStatisticsAsync(DateTime fromUtc, DateTime toUtc, CancellationToken cancellationToken);
}
