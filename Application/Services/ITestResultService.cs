using Laboratory.Application.DTOs.TestResults;
using Laboratory.Framework.Common;

namespace Laboratory.Application.Services;

public interface ITestResultService
{
    Task<OperationResult<TestResultDetailsDto>> GetResultByItemIdAsync(int testRequestItemId, CancellationToken cancellationToken);
    Task<OperationResult<TestResultDetailsDto>> SaveResultAsync(TestResultSaveDto model, int employeeId, CancellationToken cancellationToken);
    Task<OperationResult<TestResultDetailsDto>> ReviewResultAsync(ResultReviewActionDto model, int employeeId, CancellationToken cancellationToken);
}
