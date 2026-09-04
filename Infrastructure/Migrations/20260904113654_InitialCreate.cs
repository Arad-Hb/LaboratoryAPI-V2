using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfrastructureEfPersistance.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, defaultValue: ""),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LaboratoryDepartments",
                schema: "dbo",
                columns: table => new
                {
                    LaboratoryDepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaboratoryDepartments", x => x.LaboratoryDepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "SampleTypes",
                schema: "dbo",
                columns: table => new
                {
                    SampleTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleTypes", x => x.SampleTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                schema: "dbo",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EntityName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    DisplayOrder = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)0),
                    IsFinal = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "dbo",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LaboratoryDepartmentId = table.Column<int>(type: "int", nullable: false),
                    AssignedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "SYSUTCDATETIME()"),
                    AssignedByEmployeeId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_AssignedByEmployeeId",
                        column: x => x.AssignedByEmployeeId,
                        principalSchema: "dbo",
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_LaboratoryDepartments_LaboratoryDepartmentId",
                        column: x => x.LaboratoryDepartmentId,
                        principalSchema: "dbo",
                        principalTable: "LaboratoryDepartments",
                        principalColumn: "LaboratoryDepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LaboratoryTests",
                schema: "dbo",
                columns: table => new
                {
                    LaboratoryTestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LaboratoryDepartmentId = table.Column<int>(type: "int", nullable: false),
                    SampleTypeId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaboratoryTests", x => x.LaboratoryTestId);
                    table.ForeignKey(
                        name: "FK_LaboratoryTests_LaboratoryDepartments_LaboratoryDepartmentId",
                        column: x => x.LaboratoryDepartmentId,
                        principalSchema: "dbo",
                        principalTable: "LaboratoryDepartments",
                        principalColumn: "LaboratoryDepartmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LaboratoryTests_SampleTypes_SampleTypeId",
                        column: x => x.SampleTypeId,
                        principalSchema: "dbo",
                        principalTable: "SampleTypes",
                        principalColumn: "SampleTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                schema: "dbo",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalCode = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mobile = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "SYSUTCDATETIME()"),
                    RegisteredByEmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                    table.ForeignKey(
                        name: "FK_Patients_Employees_RegisteredByEmployeeId",
                        column: x => x.RegisteredByEmployeeId,
                        principalSchema: "dbo",
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestRequests",
                schema: "dbo",
                columns: table => new
                {
                    TestRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestNumber = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    RegisteredByEmployeeId = table.Column<int>(type: "int", nullable: false),
                    RegisteredAtUtc = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "SYSUTCDATETIME()"),
                    CompletedAtUtc = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestRequests", x => x.TestRequestId);
                    table.ForeignKey(
                        name: "FK_TestRequests_Employees_RegisteredByEmployeeId",
                        column: x => x.RegisteredByEmployeeId,
                        principalSchema: "dbo",
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestRequests_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestRequests_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "dbo",
                        principalTable: "Statuses",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Samples",
                schema: "dbo",
                columns: table => new
                {
                    SampleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Barcode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    TestRequestId = table.Column<int>(type: "int", nullable: false),
                    SampleTypeId = table.Column<int>(type: "int", nullable: false),
                    LaboratoryDepartmentId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CollectedByEmployeeId = table.Column<int>(type: "int", nullable: true),
                    CollectedAtUtc = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    RejectionReason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Samples", x => x.SampleId);
                    table.ForeignKey(
                        name: "FK_Samples_Employees_CollectedByEmployeeId",
                        column: x => x.CollectedByEmployeeId,
                        principalSchema: "dbo",
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Samples_LaboratoryDepartments_LaboratoryDepartmentId",
                        column: x => x.LaboratoryDepartmentId,
                        principalSchema: "dbo",
                        principalTable: "LaboratoryDepartments",
                        principalColumn: "LaboratoryDepartmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Samples_SampleTypes_SampleTypeId",
                        column: x => x.SampleTypeId,
                        principalSchema: "dbo",
                        principalTable: "SampleTypes",
                        principalColumn: "SampleTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Samples_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "dbo",
                        principalTable: "Statuses",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Samples_TestRequests_TestRequestId",
                        column: x => x.TestRequestId,
                        principalSchema: "dbo",
                        principalTable: "TestRequests",
                        principalColumn: "TestRequestId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestRequestItems",
                schema: "dbo",
                columns: table => new
                {
                    TestRequestItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestRequestId = table.Column<int>(type: "int", nullable: false),
                    LaboratoryTestId = table.Column<int>(type: "int", nullable: false),
                    SampleId = table.Column<int>(type: "int", nullable: true),
                    TestNameSnapshot = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    UnitSnapshot = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestRequestItems", x => x.TestRequestItemId);
                    table.ForeignKey(
                        name: "FK_TestRequestItems_LaboratoryTests_LaboratoryTestId",
                        column: x => x.LaboratoryTestId,
                        principalSchema: "dbo",
                        principalTable: "LaboratoryTests",
                        principalColumn: "LaboratoryTestId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestRequestItems_Samples_SampleId",
                        column: x => x.SampleId,
                        principalSchema: "dbo",
                        principalTable: "Samples",
                        principalColumn: "SampleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestRequestItems_TestRequests_TestRequestId",
                        column: x => x.TestRequestId,
                        principalSchema: "dbo",
                        principalTable: "TestRequests",
                        principalColumn: "TestRequestId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestResults",
                schema: "dbo",
                columns: table => new
                {
                    TestResultId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestRequestItemId = table.Column<int>(type: "int", nullable: false),
                    ResultValue = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    EnteredByEmployeeId = table.Column<int>(type: "int", nullable: true),
                    EnteredAtUtc = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "SYSUTCDATETIME()"),
                    ModifiedAtUtc = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestResults", x => x.TestResultId);
                    table.ForeignKey(
                        name: "FK_TestResults_Employees_EnteredByEmployeeId",
                        column: x => x.EnteredByEmployeeId,
                        principalSchema: "dbo",
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestResults_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "dbo",
                        principalTable: "Statuses",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestResults_TestRequestItems_TestRequestItemId",
                        column: x => x.TestRequestItemId,
                        principalSchema: "dbo",
                        principalTable: "TestRequestItems",
                        principalColumn: "TestRequestItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResultReviews",
                schema: "dbo",
                columns: table => new
                {
                    ResultReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestResultId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    ReviewDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ReviewedByEmployeeId = table.Column<int>(type: "int", nullable: false),
                    ReviewedAtUtc = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "SYSUTCDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultReviews", x => x.ResultReviewId);
                    table.ForeignKey(
                        name: "FK_ResultReviews_Employees_ReviewedByEmployeeId",
                        column: x => x.ReviewedByEmployeeId,
                        principalSchema: "dbo",
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResultReviews_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "dbo",
                        principalTable: "Statuses",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResultReviews_TestResults_TestResultId",
                        column: x => x.TestResultId,
                        principalSchema: "dbo",
                        principalTable: "TestResults",
                        principalColumn: "TestResultId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AssignedByEmployeeId",
                schema: "dbo",
                table: "Employees",
                column: "AssignedByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_LaboratoryDepartmentId",
                schema: "dbo",
                table: "Employees",
                column: "LaboratoryDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                schema: "dbo",
                table: "Employees",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryDepartments_Code",
                schema: "dbo",
                table: "LaboratoryDepartments",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryTests_Code",
                schema: "dbo",
                table: "LaboratoryTests",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryTests_LaboratoryDepartmentId_IsActive",
                schema: "dbo",
                table: "LaboratoryTests",
                columns: new[] { "LaboratoryDepartmentId", "IsActive" });

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryTests_SampleTypeId",
                schema: "dbo",
                table: "LaboratoryTests",
                column: "SampleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Mobile",
                schema: "dbo",
                table: "Patients",
                column: "Mobile",
                filter: "[Mobile] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_NationalCode",
                schema: "dbo",
                table: "Patients",
                column: "NationalCode",
                unique: true,
                filter: "[NationalCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_RegisteredByEmployeeId",
                schema: "dbo",
                table: "Patients",
                column: "RegisteredByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultReviews_ReviewedByEmployeeId",
                schema: "dbo",
                table: "ResultReviews",
                column: "ReviewedByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultReviews_StatusId",
                schema: "dbo",
                table: "ResultReviews",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultReviews_TestResultId_ReviewedAtUtc",
                schema: "dbo",
                table: "ResultReviews",
                columns: new[] { "TestResultId", "ReviewedAtUtc" });

            migrationBuilder.CreateIndex(
                name: "IX_Samples_Barcode",
                schema: "dbo",
                table: "Samples",
                column: "Barcode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Samples_CollectedByEmployeeId",
                schema: "dbo",
                table: "Samples",
                column: "CollectedByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Samples_LaboratoryDepartmentId_StatusId_CollectedAtUtc",
                schema: "dbo",
                table: "Samples",
                columns: new[] { "LaboratoryDepartmentId", "StatusId", "CollectedAtUtc" });

            migrationBuilder.CreateIndex(
                name: "IX_Samples_SampleTypeId",
                schema: "dbo",
                table: "Samples",
                column: "SampleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Samples_StatusId",
                schema: "dbo",
                table: "Samples",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Samples_TestRequestId",
                schema: "dbo",
                table: "Samples",
                column: "TestRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_SampleTypes_Code",
                schema: "dbo",
                table: "SampleTypes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_EntityName_Code",
                schema: "dbo",
                table: "Statuses",
                columns: new[] { "EntityName", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_EntityName_DisplayOrder",
                schema: "dbo",
                table: "Statuses",
                columns: new[] { "EntityName", "DisplayOrder" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestRequestItems_LaboratoryTestId",
                schema: "dbo",
                table: "TestRequestItems",
                column: "LaboratoryTestId");

            migrationBuilder.CreateIndex(
                name: "IX_TestRequestItems_SampleId",
                schema: "dbo",
                table: "TestRequestItems",
                column: "SampleId");

            migrationBuilder.CreateIndex(
                name: "IX_TestRequestItems_TestRequestId_LaboratoryTestId",
                schema: "dbo",
                table: "TestRequestItems",
                columns: new[] { "TestRequestId", "LaboratoryTestId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestRequests_PatientId_RegisteredAtUtc",
                schema: "dbo",
                table: "TestRequests",
                columns: new[] { "PatientId", "RegisteredAtUtc" });

            migrationBuilder.CreateIndex(
                name: "IX_TestRequests_RegisteredByEmployeeId",
                schema: "dbo",
                table: "TestRequests",
                column: "RegisteredByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TestRequests_RequestNumber",
                schema: "dbo",
                table: "TestRequests",
                column: "RequestNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestRequests_StatusId_RegisteredAtUtc",
                schema: "dbo",
                table: "TestRequests",
                columns: new[] { "StatusId", "RegisteredAtUtc" });

            migrationBuilder.CreateIndex(
                name: "IX_TestResults_EnteredByEmployeeId",
                schema: "dbo",
                table: "TestResults",
                column: "EnteredByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TestResults_StatusId",
                schema: "dbo",
                table: "TestResults",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TestResults_TestRequestItemId",
                schema: "dbo",
                table: "TestResults",
                column: "TestRequestItemId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ResultReviews",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "TestResults",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TestRequestItems",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "LaboratoryTests",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Samples",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SampleTypes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TestRequests",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Patients",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Statuses",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Employees",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "LaboratoryDepartments",
                schema: "dbo");
        }
    }
}
