using Laboratory.Application.DTOs.Samples;
using Laboratory.Application.Services;
using Laboratory.Framework.Common;

namespace Laboratory.ApplicationService;

public class SampleService : ISampleService
{
    public Task<OperationResult<PagedResult<SampleListDto>>> GetPagedSamplesAsync(PageRequest request, int? departmentId, int? statusId, CancellationToken cancellationToken)
        => NotImplemented<PagedResult<SampleListDto>>();

    public Task<OperationResult<SampleDetailsDto>> GetSampleByBarcodeAsync(string barcode, CancellationToken cancellationToken)
        => NotImplemented<SampleDetailsDto>();

    public Task<OperationResult<SampleDetailsDto>> CollectSampleAsync(SampleCollectDto model, int employeeId, CancellationToken cancellationToken)
        => NotImplemented<SampleDetailsDto>();

    public Task<OperationResult> DeliverSampleToDepartmentAsync(int sampleId, CancellationToken cancellationToken)
        => Task.FromResult(OperationResult.Failure("سرویس هنوز پیاده‌سازی نشده است.", 501));

    public Task<OperationResult> RejectSampleAsync(SampleRejectDto model, CancellationToken cancellationToken)
        => Task.FromResult(OperationResult.Failure("سرویس هنوز پیاده‌سازی نشده است.", 501));

    private static Task<OperationResult<T>> NotImplemented<T>()
        => Task.FromResult(OperationResult<T>.Failure("سرویس هنوز پیاده‌سازی نشده است.", 501));
}
