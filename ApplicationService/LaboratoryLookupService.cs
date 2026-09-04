using Laboratory.Application.DTOs.Lookups;
using Laboratory.Application.Services;
using Laboratory.Framework.Common;

namespace Laboratory.ApplicationService;

public class LaboratoryLookupService : ILaboratoryLookupService
{
    public Task<OperationResult<IReadOnlyList<DepartmentLookupDto>>> GetDepartmentsAsync(CancellationToken cancellationToken)
        => NotImplemented<IReadOnlyList<DepartmentLookupDto>>();

    public Task<OperationResult<IReadOnlyList<SampleTypeLookupDto>>> GetSampleTypesAsync(CancellationToken cancellationToken)
        => NotImplemented<IReadOnlyList<SampleTypeLookupDto>>();

    public Task<OperationResult<IReadOnlyList<LaboratoryTestLookupDto>>> GetLaboratoryTestsAsync(int? departmentId, CancellationToken cancellationToken)
        => NotImplemented<IReadOnlyList<LaboratoryTestLookupDto>>();

    public Task<OperationResult<IReadOnlyList<StatusLookupDto>>> GetStatusesByEntityAsync(string entityName, CancellationToken cancellationToken)
        => NotImplemented<IReadOnlyList<StatusLookupDto>>();

    private static Task<OperationResult<T>> NotImplemented<T>()
        => Task.FromResult(OperationResult<T>.Failure("سرویس هنوز پیاده‌سازی نشده است.", 501));
}
