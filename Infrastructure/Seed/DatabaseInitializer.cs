using DomainModel.Common;
using DomainModel.Models;
using InfrastructureEfPersistance.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureEfPersistance.Seed;

public static class DatabaseInitializer
{
    public static async Task SeedAsync(
        ApplicationDbContext context,
        UserManager<ApplicationUser> userManager,
        RoleManager<ApplicationRole> roleManager)
    {
        if (!await context.Statuses.AnyAsync())
        {
            var statuses = new List<Status>
            {
                new() { Code = "Registered", Title = "ثبت‌شده", EntityName = "Request", DisplayOrder = 1, IsFinal = false, IsActive = true },
                new() { Code = "WaitingForSample", Title = "در انتظار نمونه‌گیری", EntityName = "Request", DisplayOrder = 2, IsFinal = false, IsActive = true },
                new() { Code = "InProgress", Title = "در حال انجام", EntityName = "Request", DisplayOrder = 3, IsFinal = false, IsActive = true },
                new() { Code = "Completed", Title = "تکمیل‌شده", EntityName = "Request", DisplayOrder = 4, IsFinal = true, IsActive = true },
                new() { Code = "Cancelled", Title = "لغوشده", EntityName = "Request", DisplayOrder = 5, IsFinal = true, IsActive = true },
                new() { Code = "SampleRegistered", Title = "نمونه ثبت‌شده", EntityName = "Sample", DisplayOrder = 1, IsFinal = false, IsActive = true },
                new() { Code = "Collected", Title = "نمونه‌گیری‌شده", EntityName = "Sample", DisplayOrder = 2, IsFinal = false, IsActive = true },
                new() { Code = "Delivered", Title = "تحویل بخش شده", EntityName = "Sample", DisplayOrder = 3, IsFinal = false, IsActive = true },
                new() { Code = "Rejected", Title = "نمونه ردشده", EntityName = "Sample", DisplayOrder = 4, IsFinal = true, IsActive = true },
                new() { Code = "Draft", Title = "پیش‌نویس", EntityName = "Result", DisplayOrder = 1, IsFinal = false, IsActive = true },
                new() { Code = "PendingReview", Title = "در انتظار بررسی", EntityName = "Result", DisplayOrder = 2, IsFinal = false, IsActive = true },
                new() { Code = "Returned", Title = "بازگشت برای اصلاح", EntityName = "Result", DisplayOrder = 3, IsFinal = false, IsActive = true },
                new() { Code = "Approved", Title = "تأییدشده", EntityName = "Result", DisplayOrder = 4, IsFinal = true, IsActive = true }
            };

            await context.Statuses.AddRangeAsync(statuses);
            await context.SaveChangesAsync();
        }

        if (!await context.LaboratoryDepartments.AnyAsync())
        {
            await context.LaboratoryDepartments.AddRangeAsync(
                new LaboratoryDepartment { Code = "HEM", Name = "بخش هماتولوژی (خون‌شناسی)", IsActive = true },
                new LaboratoryDepartment { Code = "BIO", Name = "بخش بیوشیمی بالینی", IsActive = true },
                new LaboratoryDepartment { Code = "MIC", Name = "بخش میکروب‌شناسی و کشت", IsActive = true },
                new LaboratoryDepartment { Code = "IMM", Name = "بخش ایمونولوژی و هورمون", IsActive = true },
                new LaboratoryDepartment { Code = "PAT", Name = "بخش پاتولوژی و سیتولوژی", IsActive = true },
                new LaboratoryDepartment { Code = "SER", Name = "بخش سرولوژی", IsActive = true });
            await context.SaveChangesAsync();
        }

        if (!await context.SampleTypes.AnyAsync())
        {
            await context.SampleTypes.AddRangeAsync(
                new SampleType { Code = "BLD_EDTA", Name = "خون کامل (EDTA)", IsActive = true },
                new SampleType { Code = "SERUM", Name = "سرم لخته‌شده", IsActive = true },
                new SampleType { Code = "PLSM_CIT", Name = "پلاسما سیتراته", IsActive = true },
                new SampleType { Code = "URN_RND", Name = "ادرار رندوم صبحگاهی", IsActive = true },
                new SampleType { Code = "URN_24H", Name = "ادرار ۲۴ ساعته", IsActive = true },
                new SampleType { Code = "STL", Name = "مدفوع", IsActive = true },
                new SampleType { Code = "CSF", Name = "مایع مغزی‌نخاعی (CSF)", IsActive = true });
            await context.SaveChangesAsync();
        }

        var roles = new[] { "Receptionist", "Sampler", "LabTechnician", "TechnicalManager", "SystemAdmin" };
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new ApplicationRole { Name = role });
            }
        }

        var bioDept = await context.LaboratoryDepartments.FirstAsync(d => d.Code == "BIO");
        var hemDept = await context.LaboratoryDepartments.FirstAsync(d => d.Code == "HEM");

        var defaultUsers = new (string Username, string FullName, string Role, int DepartmentId)[]
        {
            ("admin", "مهندس افشین رفوآ (مدیر ارشد سامانه)", "SystemAdmin", bioDept.LaboratoryDepartmentId),
            ("reception", "سارا احمدی (مسئول پذیرش)", "Receptionist", bioDept.LaboratoryDepartmentId),
            ("sampler", "محمد کریمی (کارشناس نمونه‌گیری)", "Sampler", hemDept.LaboratoryDepartmentId),
            ("tech_bio", "دکتر مریم شریفی (تکنسین بیوشیمی)", "LabTechnician", bioDept.LaboratoryDepartmentId),
            ("tech_hem", "علی اکبری (تکنسین هماتولوژی)", "LabTechnician", hemDept.LaboratoryDepartmentId),
            ("manager", "دکتر فرهمند (مسئول فنی آزمایشگاه)", "TechnicalManager", bioDept.LaboratoryDepartmentId)
        };

        foreach (var (username, fullName, role, departmentId) in defaultUsers)
        {
            var user = await userManager.FindByNameAsync(username);
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = username,
                    Email = $"{username}@lab.local",
                    FullName = fullName,
                    EmailConfirmed = true
                };

                var createResult = await userManager.CreateAsync(user, "Pass@1234");
                if (createResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }

            user = await userManager.FindByNameAsync(username);
            if (user == null)
            {
                continue;
            }

            var alreadyLinked = await context.Employees.AnyAsync(e =>
                EF.Property<string>(e, "_identityUserId") == user.Id);
            if (!alreadyLinked)
            {
                context.Employees.Add(new Employee
                {
                    UserId = UserId.From(user.Id),
                    LaboratoryDepartmentId = departmentId,
                    AssignedAt = DateTime.UtcNow,
                    IsActive = true
                });
                await context.SaveChangesAsync();
            }
        }

        if (!await context.LaboratoryTests.AnyAsync())
        {
            var bloodSample = await context.SampleTypes.FirstAsync(s => s.Code == "BLD_EDTA");
            var serumSample = await context.SampleTypes.FirstAsync(s => s.Code == "SERUM");
            var urineSample = await context.SampleTypes.FirstAsync(s => s.Code == "URN_RND");

            await context.LaboratoryTests.AddRangeAsync(
                new LaboratoryTest { Code = "CBC", Name = "شمارش کامل گلبول‌های خون (CBC)", Unit = "-", LaboratoryDepartmentId = hemDept.LaboratoryDepartmentId, SampleTypeId = bloodSample.SampleTypeId, IsActive = true },
                new LaboratoryTest { Code = "ESR", Name = "سرعت رسوب گلبول قرمز (ESR)", Unit = "mm/hr", LaboratoryDepartmentId = hemDept.LaboratoryDepartmentId, SampleTypeId = bloodSample.SampleTypeId, IsActive = true },
                new LaboratoryTest { Code = "FBS", Name = "قند خون ناشتا (FBS)", Unit = "mg/dL", LaboratoryDepartmentId = bioDept.LaboratoryDepartmentId, SampleTypeId = serumSample.SampleTypeId, IsActive = true },
                new LaboratoryTest { Code = "HbA1c", Name = "هموگلوبین ای وان سی (HbA1c)", Unit = "%", LaboratoryDepartmentId = bioDept.LaboratoryDepartmentId, SampleTypeId = bloodSample.SampleTypeId, IsActive = true },
                new LaboratoryTest { Code = "CHOL", Name = "کلسترول تام (Cholesterol)", Unit = "mg/dL", LaboratoryDepartmentId = bioDept.LaboratoryDepartmentId, SampleTypeId = serumSample.SampleTypeId, IsActive = true },
                new LaboratoryTest { Code = "TG", Name = "تری‌گلیسرید (Triglycerides)", Unit = "mg/dL", LaboratoryDepartmentId = bioDept.LaboratoryDepartmentId, SampleTypeId = serumSample.SampleTypeId, IsActive = true },
                new LaboratoryTest { Code = "UREA", Name = "اوره خون (Blood Urea)", Unit = "mg/dL", LaboratoryDepartmentId = bioDept.LaboratoryDepartmentId, SampleTypeId = serumSample.SampleTypeId, IsActive = true },
                new LaboratoryTest { Code = "CR", Name = "کراتینین سرم (Creatinine)", Unit = "mg/dL", LaboratoryDepartmentId = bioDept.LaboratoryDepartmentId, SampleTypeId = serumSample.SampleTypeId, IsActive = true },
                new LaboratoryTest { Code = "UA", Name = "آنالیز کامل ادرار (Urine Analysis)", Unit = "-", LaboratoryDepartmentId = bioDept.LaboratoryDepartmentId, SampleTypeId = urineSample.SampleTypeId, IsActive = true });
            await context.SaveChangesAsync();
        }
    }
}
