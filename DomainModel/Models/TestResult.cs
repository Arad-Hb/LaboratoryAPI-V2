namespace DomainModel.Models;

public class TestResult 
{
    public int TestResultId { get; set; }
    public int TestRequestItemId { get; set; }
    public TestRequestItem? TestRequestItem { get; set; }

    public string ResultValue { get; set; } = string.Empty;
    public string? Description { get; set; }

    public int StatusId { get; set; }
    public Status? Status { get; set; }

    public int? EnteredByEmployeeId { get; set; }
    public Employee? EnteredByEmployee { get; set; }

    public DateTime EnteredAtUtc { get; set; } = DateTime.UtcNow;
    public DateTime? ModifiedAtUtc { get; set; }
    public byte[] RowVersion { get; set; } = Array.Empty<byte>();

    public ICollection<ResultReview> ResultReviews { get; set; } = new List<ResultReview>();
}
