namespace DomainModel.Models;

public class SampleType 
{
    public int SampleTypeId { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;

    public ICollection<LaboratoryTest> LaboratoryTests { get; set; } = new List<LaboratoryTest>();
    public ICollection<Sample> Samples { get; set; } = new List<Sample>();
}
