namespace DomainModel.Models;

public class LaboratoryDepartment 
{
    public int LaboratoryDepartmentId { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    public ICollection<LaboratoryTest> LaboratoryTests { get; set; } = new List<LaboratoryTest>();
    public ICollection<Sample> Samples { get; set; } = new List<Sample>();
}
