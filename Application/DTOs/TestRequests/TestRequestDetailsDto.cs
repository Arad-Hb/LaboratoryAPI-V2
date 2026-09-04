namespace Laboratory.Application.DTOs.TestRequests;

public class TestRequestDetailsDto
{
    public int TestRequestId { get; set; }
    public string RequestNumber { get; set; } = string.Empty;
    public int PatientId { get; set; }
    public string PatientFullName { get; set; } = string.Empty;
    public int StatusId { get; set; }
    public string StatusTitle { get; set; } = string.Empty;
    public int RegisteredByEmployeeId { get; set; }
    public string? RegisteredByEmployeeName { get; set; }
    public DateTime RegisteredAtUtc { get; set; }
    public DateTime? CompletedAtUtc { get; set; }
    public IReadOnlyList<TestRequestItemDto> Items { get; set; } = Array.Empty<TestRequestItemDto>();
    public IReadOnlyList<TestRequestSampleSummaryDto> Samples { get; set; } = Array.Empty<TestRequestSampleSummaryDto>();
}

public class TestRequestItemDto
{
    public int TestRequestItemId { get; set; }
    public int LaboratoryTestId { get; set; }
    public string TestNameSnapshot { get; set; } = string.Empty;
    public string? UnitSnapshot { get; set; }
    public int? SampleId { get; set; }
}

public class TestRequestSampleSummaryDto
{
    public int SampleId { get; set; }
    public string Barcode { get; set; } = string.Empty;
    public int StatusId { get; set; }
    public int? CollectedByEmployeeId { get; set; }
}
