using Laboratory.Application.DTOs.Reports;
using Laboratory.Application.Services;
using Laboratory.Framework.Common;

namespace Laboratory.ApplicationService;

public class ReportService : IReportService
{
    public Task<OperationResult<PagedResult<DepartmentWorkListItemDto>>> GetDepartmentWorkListAsync(int departmentId, int pageNumber, int pageSize, CancellationToken cancellationToken)
        => Task.FromResult(OperationResult<PagedResult<DepartmentWorkListItemDto>>.Failure("سرویس هنوز پیاده‌سازی نشده است.", 501));

    public Task<OperationResult<FinalReportDto>> GetFinalReportAsync(int testRequestId, CancellationToken cancellationToken)
        => Task.FromResult(OperationResult<FinalReportDto>.Failure("سرویس هنوز پیاده‌سازی نشده است.", 501));

    public Task<OperationResult<DailyStatisticsDto>> GetDailyStatisticsAsync(DateTime fromUtc, DateTime toUtc, CancellationToken cancellationToken)
        => Task.FromResult(OperationResult<DailyStatisticsDto>.Failure("سرویس هنوز پیاده‌سازی نشده است.", 501));
}
