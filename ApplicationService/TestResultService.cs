using Laboratory.Application.DTOs.TestResults;
using Laboratory.Application.Services;
using Laboratory.Framework.Common;

namespace Laboratory.ApplicationService;

public class TestResultService : ITestResultService
{
    public Task<OperationResult<TestResultDetailsDto>> GetResultByItemIdAsync(int testRequestItemId, CancellationToken cancellationToken)
        => NotImplemented<TestResultDetailsDto>();

    public Task<OperationResult<TestResultDetailsDto>> SaveResultAsync(TestResultSaveDto model, int employeeId, CancellationToken cancellationToken)
        => NotImplemented<TestResultDetailsDto>();

    public Task<OperationResult<TestResultDetailsDto>> ReviewResultAsync(ResultReviewActionDto model, int employeeId, CancellationToken cancellationToken)
        => NotImplemented<TestResultDetailsDto>();

    private static Task<OperationResult<T>> NotImplemented<T>()
        => Task.FromResult(OperationResult<T>.Failure("سرویس هنوز پیاده‌سازی نشده است.", 501));
}
