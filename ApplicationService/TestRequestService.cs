using Laboratory.Application.DTOs.TestRequests;
using Laboratory.Application.Services;
using Laboratory.Framework.Common;

namespace Laboratory.ApplicationService;

public class TestRequestService : ITestRequestService
{
    public Task<OperationResult<PagedResult<TestRequestListDto>>> GetPagedTestRequestsAsync(PageRequest request, int? statusId, CancellationToken cancellationToken)
        => NotImplemented<PagedResult<TestRequestListDto>>();

    public Task<OperationResult<TestRequestDetailsDto>> GetTestRequestByIdAsync(int id, CancellationToken cancellationToken)
        => NotImplemented<TestRequestDetailsDto>();

    public Task<OperationResult<TestRequestDetailsDto>> GetTestRequestByNumberAsync(string requestNumber, CancellationToken cancellationToken)
        => NotImplemented<TestRequestDetailsDto>();

    public Task<OperationResult<TestRequestDetailsDto>> CreateTestRequestAsync(TestRequestCreateDto model, int employeeId, CancellationToken cancellationToken)
        => NotImplemented<TestRequestDetailsDto>();

    public Task<OperationResult> CancelTestRequestAsync(int id, CancellationToken cancellationToken)
        => Task.FromResult(OperationResult.Failure("سرویس هنوز پیاده‌سازی نشده است.", 501));

    private static Task<OperationResult<T>> NotImplemented<T>()
        => Task.FromResult(OperationResult<T>.Failure("سرویس هنوز پیاده‌سازی نشده است.", 501));
}
