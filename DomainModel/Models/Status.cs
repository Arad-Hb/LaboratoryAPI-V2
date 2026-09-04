namespace DomainModel.Models;

public class Status 
{
    public int StatusId { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string EntityName { get; set; } = string.Empty;
    public short DisplayOrder { get; set; } = 0;
    public bool IsFinal { get; set; } = false;
    public bool IsActive { get; set; } = true;

    // روابط ناوبری
    public ICollection<TestRequest> TestRequests { get; set; } = new List<TestRequest>();
    public ICollection<Sample> Samples { get; set; } = new List<Sample>();
    public ICollection<TestResult> TestResults { get; set; } = new List<TestResult>();
    public ICollection<ResultReview> ResultReviews { get; set; } = new List<ResultReview>();
}
