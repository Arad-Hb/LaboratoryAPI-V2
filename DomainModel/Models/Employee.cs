using DomainModel.Common;

namespace DomainModel.Models;

public class Employee
{
    private string _identityUserId = null!;

    public int EmployeeId { get; set; }

    public UserId UserId
    {
        get => UserId.From(_identityUserId);
        set => _identityUserId = value.Value;
    }

    public int LaboratoryDepartmentId { get; set; }
    public LaboratoryDepartment LaboratoryDepartment { get; set; } = null!;

    public DateTime AssignedAt { get; set; }

    public int? AssignedByEmployeeId { get; set; }
    public Employee? AssignedByEmployee { get; set; }

    public bool IsActive { get; set; }

    public ICollection<TestRequest> TestRequests { get; set; } = new List<TestRequest>();
    public ICollection<Employee> AssignedEmployees { get; set; } = new List<Employee>();
    public ICollection<TestResult> TestResults { get; set; } = new List<TestResult>();
    public ICollection<Sample> Samples { get; set; } = new List<Sample>();
    public ICollection<ResultReview> ResultReviews { get; set; } = new List<ResultReview>();
    public ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
