namespace Laboratory.Application.DTOs.Reports;

public class DepartmentWorkListItemDto
{
    public int SampleId { get; set; }
    public string Barcode { get; set; } = string.Empty;
    public int TestRequestId { get; set; }
    public string RequestNumber { get; set; } = string.Empty;
    public string PatientFullName { get; set; } = string.Empty;
    public int StatusId { get; set; }
    public string StatusTitle { get; set; } = string.Empty;
    public int? CollectedByEmployeeId { get; set; }
    public DateTime? CollectedAtUtc { get; set; }
}

public class FinalReportDto
{
    public int TestRequestId { get; set; }
    public string RequestNumber { get; set; } = string.Empty;
    public string PatientFullName { get; set; } = string.Empty;
    public string? NationalCode { get; set; }
    public int RegisteredByEmployeeId { get; set; }
    public string? RegisteredByEmployeeName { get; set; }
    public DateTime RegisteredAtUtc { get; set; }
    public DateTime? CompletedAtUtc { get; set; }
    public IReadOnlyList<FinalReportItemDto> Items { get; set; } = Array.Empty<FinalReportItemDto>();
}

public class FinalReportItemDto
{
    public string TestName { get; set; } = string.Empty;
    public string? Unit { get; set; }
    public string ResultValue { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int? EnteredByEmployeeId { get; set; }
    public int? ReviewedByEmployeeId { get; set; }
}

public class DailyStatisticsDto
{
    public DateTime FromUtc { get; set; }
    public DateTime ToUtc { get; set; }
    public int RegisteredRequestCount { get; set; }
    public int CompletedRequestCount { get; set; }
    public int CollectedSampleCount { get; set; }
    public int ApprovedResultCount { get; set; }
}
