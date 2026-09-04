using Laboratory.Application.DTOs.TestRequests;
using Laboratory.Framework.Common;

namespace Laboratory.Application.Services;

public interface ITestRequestService
{
    Task<OperationResult<PagedResult<TestRequestListDto>>> GetPagedTestRequestsAsync(PageRequest request, int? statusId, CancellationToken cancellationToken);
    Task<OperationResult<TestRequestDetailsDto>> GetTestRequestByIdAsync(int id, CancellationToken cancellationToken);
    Task<OperationResult<TestRequestDetailsDto>> GetTestRequestByNumberAsync(string requestNumber, CancellationToken cancellationToken);
    Task<OperationResult<TestRequestDetailsDto>> CreateTestRequestAsync(TestRequestCreateDto model, int employeeId, CancellationToken cancellationToken);
    Task<OperationResult> CancelTestRequestAsync(int id, CancellationToken cancellationToken);
}
