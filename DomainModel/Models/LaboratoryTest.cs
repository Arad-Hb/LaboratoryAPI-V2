namespace DomainModel.Models;

public class LaboratoryTest 
{
    public int LaboratoryTestId { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Unit { get; set; }
    public int LaboratoryDepartmentId { get; set; }
    public LaboratoryDepartment? LaboratoryDepartment { get; set; }
    public int SampleTypeId { get; set; }
    public SampleType? SampleType { get; set; }
    public bool IsActive { get; set; } = true;

    public ICollection<TestRequestItem> TestRequestItems { get; set; } = new List<TestRequestItem>();
}
