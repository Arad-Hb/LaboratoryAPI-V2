using DomainModel.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureEfPersistance.Context;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Status> Statuses { get; set; } = null!;
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<LaboratoryDepartment> LaboratoryDepartments { get; set; } = null!;
    public DbSet<SampleType> SampleTypes { get; set; } = null!;
    public DbSet<Patient> Patients { get; set; } = null!;
    public DbSet<LaboratoryTest> LaboratoryTests { get; set; } = null!;
    public DbSet<TestRequest> TestRequests { get; set; } = null!;
    public DbSet<Sample> Samples { get; set; } = null!;
    public DbSet<TestRequestItem> TestRequestItems { get; set; } = null!;
    public DbSet<TestResult> TestResults { get; set; } = null!;
    public DbSet<ResultReview> ResultReviews { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
