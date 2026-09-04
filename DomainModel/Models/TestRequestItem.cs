namespace DomainModel.Models;

public class TestRequestItem 
{
    public int TestRequestItemId { get; set; }
    public int TestRequestId { get; set; }
    public TestRequest? TestRequest { get; set; }
    public int LaboratoryTestId { get; set; }
    public LaboratoryTest? LaboratoryTest { get; set; }
    public int? SampleId { get; set; }
    public Sample? Sample { get; set; }
    public string TestNameSnapshot { get; set; } = string.Empty;
    public string? UnitSnapshot { get; set; }

    public TestResult? TestResult { get; set; }
}
