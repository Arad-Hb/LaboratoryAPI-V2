using Laboratory.Application.DTOs.Samples;
using Laboratory.Framework.Common;

namespace Laboratory.Application.Services;

public interface ISampleService
{
    Task<OperationResult<PagedResult<SampleListDto>>> GetPagedSamplesAsync(PageRequest request, int? departmentId, int? statusId, CancellationToken cancellationToken);
    Task<OperationResult<SampleDetailsDto>> GetSampleByBarcodeAsync(string barcode, CancellationToken cancellationToken);
    Task<OperationResult<SampleDetailsDto>> CollectSampleAsync(SampleCollectDto model, int employeeId, CancellationToken cancellationToken);
    Task<OperationResult> DeliverSampleToDepartmentAsync(int sampleId, CancellationToken cancellationToken);
    Task<OperationResult> RejectSampleAsync(SampleRejectDto model, CancellationToken cancellationToken);
}
