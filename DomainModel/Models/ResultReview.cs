namespace DomainModel.Models;

public class ResultReview 
{
    public int ResultReviewId { get; set; }
    public int TestResultId { get; set; }
    public TestResult? TestResult { get; set; }
    public int StatusId { get; set; }
    public Status? Status { get; set; }
    public string? ReviewDescription { get; set; }
    public int ReviewedByEmployeeId { get; set; }
    public Employee? ReviewedByEmployee { get; set; }
    public DateTime ReviewedAtUtc { get; set; } = DateTime.UtcNow;
}
