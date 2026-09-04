namespace Laboratory.Application.DTOs.Lookups;

public class DepartmentLookupDto
{
    public int LaboratoryDepartmentId { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}

public class SampleTypeLookupDto
{
    public int SampleTypeId { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}

public class LaboratoryTestLookupDto
{
    public int LaboratoryTestId { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Unit { get; set; }
    public int LaboratoryDepartmentId { get; set; }
    public int SampleTypeId { get; set; }
    public bool IsActive { get; set; }
}

public class StatusLookupDto
{
    public int StatusId { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string EntityName { get; set; } = string.Empty;
    public short DisplayOrder { get; set; }
    public bool IsFinal { get; set; }
    public bool IsActive { get; set; }
}
