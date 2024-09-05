using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnClocService.Portal.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerFeedbackQuestions",
                columns: table => new
                {
                    CustomerFeedbackQuestionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeedbackQuestion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeedbackDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerFeedbackQuestions", x => x.CustomerFeedbackQuestionID);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentCategories",
                columns: table => new
                {
                    EquipmentCategoryID = table.Column<int>(type: "int", nullable: false),
                    CategoryCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CategorytName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentCategories", x => x.EquipmentCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentFamilies",
                columns: table => new
                {
                    EquipmentFamilyID = table.Column<int>(type: "int", nullable: false),
                    FamilyCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FamilyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentFamilies", x => x.EquipmentFamilyID);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentGroups",
                columns: table => new
                {
                    EquipmentGroupID = table.Column<int>(type: "int", nullable: false),
                    GroupCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentGroups", x => x.EquipmentGroupID);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentManufacturers",
                columns: table => new
                {
                    EquipmentManufacturerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentManufacturerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentManufacturers", x => x.EquipmentManufacturerID);
                });

            migrationBuilder.CreateTable(
                name: "JobCardCategories",
                columns: table => new
                {
                    JobCardCategoryID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColourCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCardCategories", x => x.JobCardCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "JobCardChecklistTemplates",
                columns: table => new
                {
                    JobCardChecklistTemplateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChecklistName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChecklistDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCardChecklistTemplates", x => x.JobCardChecklistTemplateID);
                });

            migrationBuilder.CreateTable(
                name: "JobCardClasses",
                columns: table => new
                {
                    JobCardClassID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColourCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCardClasses", x => x.JobCardClassID);
                });

            migrationBuilder.CreateTable(
                name: "JobCardGenres",
                columns: table => new
                {
                    JobCardGenreID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColourCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCardGenres", x => x.JobCardGenreID);
                });

            migrationBuilder.CreateTable(
                name: "JobCardGroups",
                columns: table => new
                {
                    JobCardGroupID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColourCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCardGroups", x => x.JobCardGroupID);
                });

            migrationBuilder.CreateTable(
                name: "JobCardPriorityLevels",
                columns: table => new
                {
                    JobCardPriorityLevelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriorityIndex = table.Column<int>(type: "int", nullable: false),
                    PriorityLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColourCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllowEscalation = table.Column<bool>(type: "bit", nullable: false),
                    EscalationTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCardPriorityLevels", x => x.JobCardPriorityLevelID);
                });

            migrationBuilder.CreateTable(
                name: "JobCardStatuses",
                columns: table => new
                {
                    JobCardStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ColourCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCardStatuses", x => x.JobCardStatusID);
                });

            migrationBuilder.CreateTable(
                name: "JobCardTypes",
                columns: table => new
                {
                    JobCardTypeID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColourCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCardTypes", x => x.JobCardTypeID);
                });

            migrationBuilder.CreateTable(
                name: "JobTasks",
                columns: table => new
                {
                    JobTaskID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskDuration = table.Column<TimeSpan>(type: "time", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTasks", x => x.JobTaskID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    PaymentMethodID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentMethodName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.PaymentMethodID);
                });

            migrationBuilder.CreateTable(
                name: "ServiceDesks",
                columns: table => new
                {
                    ServiceDeskID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceDeskName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceDeskDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceDesks", x => x.ServiceDeskID);
                });

            migrationBuilder.CreateTable(
                name: "ServiceOfficerDesignations",
                columns: table => new
                {
                    ServiceOfficerDesignationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesignationTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceOfficerDesignations", x => x.ServiceOfficerDesignationID);
                });

            migrationBuilder.CreateTable(
                name: "ServiceProjects",
                columns: table => new
                {
                    ServiceProjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceProjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProjects", x => x.ServiceProjectID);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTicketCategories",
                columns: table => new
                {
                    ServiceTicketCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColourCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTicketCategories", x => x.ServiceTicketCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTicketPriorityLevels",
                columns: table => new
                {
                    ServiceTicketPriorityLevelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriorityIndex = table.Column<int>(type: "int", nullable: false),
                    PriorityLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColourCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllowEscalation = table.Column<bool>(type: "bit", nullable: false),
                    EscalationTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTicketPriorityLevels", x => x.ServiceTicketPriorityLevelID);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTicketStatuses",
                columns: table => new
                {
                    ServiceTicketStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ColourCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTicketStatuses", x => x.ServiceTicketStatusID);
                });

            migrationBuilder.CreateTable(
                name: "StockWarehouses",
                columns: table => new
                {
                    StockWarehouseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockWarehouseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StockWarehouseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockWarehouses", x => x.StockWarehouseID);
                });

            migrationBuilder.CreateTable(
                name: "SystemsAuthenticationTickets",
                columns: table => new
                {
                    TicketID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceFamily = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperatingSystemFamily = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperatingSystemVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAgentFamily = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAgentVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemoteIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    LastActivity = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Expires = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemsAuthenticationTickets", x => x.TicketID);
                });

            migrationBuilder.CreateTable(
                name: "SystemsCurrencies",
                columns: table => new
                {
                    SystemsCurrencyID = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    SystemsCurrencyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemsCurrencySymbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrefixCurrencySymbol = table.Column<bool>(type: "bit", nullable: false),
                    SurfixCurrencySymbol = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemsCurrencies", x => x.SystemsCurrencyID);
                });

            migrationBuilder.CreateTable(
                name: "SystemsFunctionalRoles",
                columns: table => new
                {
                    FunctionalRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemsFunctionalRoles", x => x.FunctionalRoleId);
                });

            migrationBuilder.CreateTable(
                name: "SystemsModules",
                columns: table => new
                {
                    SystemsModuleID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ParentModuleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefaultModule = table.Column<bool>(type: "bit", nullable: false),
                    AspArea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModuleImageFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Index = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShowInMenu = table.Column<bool>(type: "bit", nullable: false),
                    EnableMenuItem = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemsModules", x => x.SystemsModuleID);
                });

            migrationBuilder.CreateTable(
                name: "SystemsNotificationTypes",
                columns: table => new
                {
                    SystemsNotificationTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriorityLevel = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemsNotificationTypes", x => x.SystemsNotificationTypeID);
                });

            migrationBuilder.CreateTable(
                name: "SystemsRefreshTokens",
                columns: table => new
                {
                    TokenID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Revoked = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Expiry = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemsRefreshTokens", x => x.TokenID);
                });

            migrationBuilder.CreateTable(
                name: "SystemsRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSystemRole = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemsRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemsSettings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemsSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxationTypes",
                columns: table => new
                {
                    TaxationTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxationRate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxationTypes", x => x.TaxationTypeID);
                });

            migrationBuilder.CreateTable(
                name: "TravelEvents",
                columns: table => new
                {
                    TravelEventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TravelEventName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TravelEventDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelEvents", x => x.TravelEventID);
                });

            migrationBuilder.CreateTable(
                name: "TravelPlans",
                columns: table => new
                {
                    TravelPlanID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TravelPlanSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TravelPlanDestination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TravelPlanDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelPlans", x => x.TravelPlanID);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentFamilyCategories",
                columns: table => new
                {
                    EquipmentFamilyCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentFamilyId = table.Column<int>(type: "int", nullable: false),
                    EquipmentCategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentFamilyCategories", x => x.EquipmentFamilyCategoryID);
                    table.ForeignKey(
                        name: "FK_EquipmentFamilyCategories_EquipmentCategories_EquipmentCategoryId",
                        column: x => x.EquipmentCategoryId,
                        principalTable: "EquipmentCategories",
                        principalColumn: "EquipmentCategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentFamilyCategories_EquipmentFamilies_EquipmentFamilyId",
                        column: x => x.EquipmentFamilyId,
                        principalTable: "EquipmentFamilies",
                        principalColumn: "EquipmentFamilyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentCategoryGroups",
                columns: table => new
                {
                    EquipmentCategoryGroupID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentCategoryId = table.Column<int>(type: "int", nullable: false),
                    EquipmentGroupId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentCategoryGroups", x => x.EquipmentCategoryGroupID);
                    table.ForeignKey(
                        name: "FK_EquipmentCategoryGroups_EquipmentCategories_EquipmentCategoryId",
                        column: x => x.EquipmentCategoryId,
                        principalTable: "EquipmentCategories",
                        principalColumn: "EquipmentCategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentCategoryGroups_EquipmentGroups_EquipmentGroupId",
                        column: x => x.EquipmentGroupId,
                        principalTable: "EquipmentGroups",
                        principalColumn: "EquipmentGroupID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentBrands",
                columns: table => new
                {
                    EquipmentBrandID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentManufacturerId = table.Column<int>(type: "int", nullable: false),
                    BrandCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentBrands", x => x.EquipmentBrandID);
                    table.ForeignKey(
                        name: "FK_EquipmentBrands_EquipmentManufacturers_EquipmentManufacturerId",
                        column: x => x.EquipmentManufacturerId,
                        principalTable: "EquipmentManufacturers",
                        principalColumn: "EquipmentManufacturerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobCardCategoryClasses",
                columns: table => new
                {
                    JobCardCategoryClassID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobCardCategoryId = table.Column<int>(type: "int", nullable: false),
                    JobCardClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCardCategoryClasses", x => x.JobCardCategoryClassID);
                    table.ForeignKey(
                        name: "FK_JobCardCategoryClasses_JobCardCategories_JobCardCategoryId",
                        column: x => x.JobCardCategoryId,
                        principalTable: "JobCardCategories",
                        principalColumn: "JobCardCategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobCardCategoryClasses_JobCardClasses_JobCardClassId",
                        column: x => x.JobCardClassId,
                        principalTable: "JobCardClasses",
                        principalColumn: "JobCardClassID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobCardClassGroups",
                columns: table => new
                {
                    JobCardClassGroupID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobCardClassId = table.Column<int>(type: "int", nullable: false),
                    JobCardGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCardClassGroups", x => x.JobCardClassGroupID);
                    table.ForeignKey(
                        name: "FK_JobCardClassGroups_JobCardClasses_JobCardClassId",
                        column: x => x.JobCardClassId,
                        principalTable: "JobCardClasses",
                        principalColumn: "JobCardClassID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobCardClassGroups_JobCardGroups_JobCardGroupId",
                        column: x => x.JobCardGroupId,
                        principalTable: "JobCardGroups",
                        principalColumn: "JobCardGroupID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobCardGroupGenres",
                columns: table => new
                {
                    JobCardGroupGenreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobCardGroupId = table.Column<int>(type: "int", nullable: false),
                    JobCardGenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCardGroupGenres", x => x.JobCardGroupGenreID);
                    table.ForeignKey(
                        name: "FK_JobCardGroupGenres_JobCardGenres_JobCardGenreId",
                        column: x => x.JobCardGenreId,
                        principalTable: "JobCardGenres",
                        principalColumn: "JobCardGenreID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobCardGroupGenres_JobCardGroups_JobCardGroupId",
                        column: x => x.JobCardGroupId,
                        principalTable: "JobCardGroups",
                        principalColumn: "JobCardGroupID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobCardTypeCategories",
                columns: table => new
                {
                    JobCardTypeCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobCardTypeId = table.Column<int>(type: "int", nullable: false),
                    JobCardCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCardTypeCategories", x => x.JobCardTypeCategoryID);
                    table.ForeignKey(
                        name: "FK_JobCardTypeCategories_JobCardCategories_JobCardCategoryId",
                        column: x => x.JobCardCategoryId,
                        principalTable: "JobCardCategories",
                        principalColumn: "JobCardCategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobCardTypeCategories_JobCardTypes_JobCardTypeId",
                        column: x => x.JobCardTypeId,
                        principalTable: "JobCardTypes",
                        principalColumn: "JobCardTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobCardChecklistTemplateTasks",
                columns: table => new
                {
                    JobCardChecklistTemplateTaskID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobCardChecklistTemplateId = table.Column<int>(type: "int", nullable: false),
                    JobTaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCardChecklistTemplateTasks", x => x.JobCardChecklistTemplateTaskID);
                    table.ForeignKey(
                        name: "FK_JobCardChecklistTemplateTasks_JobCardChecklistTemplates_JobCardChecklistTemplateId",
                        column: x => x.JobCardChecklistTemplateId,
                        principalTable: "JobCardChecklistTemplates",
                        principalColumn: "JobCardChecklistTemplateID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobCardChecklistTemplateTasks_JobTasks_JobTaskId",
                        column: x => x.JobTaskId,
                        principalTable: "JobTasks",
                        principalColumn: "JobTaskID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobTaskSteps",
                columns: table => new
                {
                    JobTaskStepID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobTaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StepTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StepDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTaskSteps", x => x.JobTaskStepID);
                    table.ForeignKey(
                        name: "FK_JobTaskSteps_JobTasks_JobTaskId",
                        column: x => x.JobTaskId,
                        principalTable: "JobTasks",
                        principalColumn: "JobTaskID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceDeskProjectAllocations",
                columns: table => new
                {
                    ServiceProjectDeskID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceDeskId = table.Column<int>(type: "int", nullable: false),
                    ServiceProjectId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceDeskProjectAllocations", x => x.ServiceProjectDeskID);
                    table.ForeignKey(
                        name: "FK_ServiceDeskProjectAllocations_ServiceDesks_ServiceDeskId",
                        column: x => x.ServiceDeskId,
                        principalTable: "ServiceDesks",
                        principalColumn: "ServiceDeskID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceDeskProjectAllocations_ServiceProjects_ServiceProjectId",
                        column: x => x.ServiceProjectId,
                        principalTable: "ServiceProjects",
                        principalColumn: "ServiceProjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceDeskPortfolios",
                columns: table => new
                {
                    ServiceDeskProtfolioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceDeskId = table.Column<int>(type: "int", nullable: false),
                    ServiceTicketCategoryId = table.Column<int>(type: "int", nullable: false),
                    JobCardTypeId = table.Column<int>(type: "int", nullable: false),
                    JobCardCategoryId = table.Column<int>(type: "int", nullable: false),
                    JobCardClassId = table.Column<int>(type: "int", nullable: false),
                    JobCardGroupId = table.Column<int>(type: "int", nullable: false),
                    JobCardGenreId = table.Column<int>(type: "int", nullable: false),
                    ManageServiceTicketCategory = table.Column<bool>(type: "bit", nullable: false),
                    ManageJobCardType = table.Column<bool>(type: "bit", nullable: false),
                    ManageJobCardCategory = table.Column<bool>(type: "bit", nullable: false),
                    ManageJobCardClass = table.Column<bool>(type: "bit", nullable: false),
                    ManageJobCardGroup = table.Column<bool>(type: "bit", nullable: false),
                    ManageJobCardGenre = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceDeskPortfolios", x => x.ServiceDeskProtfolioID);
                    table.ForeignKey(
                        name: "FK_ServiceDeskPortfolios_JobCardCategories_JobCardCategoryId",
                        column: x => x.JobCardCategoryId,
                        principalTable: "JobCardCategories",
                        principalColumn: "JobCardCategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceDeskPortfolios_JobCardClasses_JobCardClassId",
                        column: x => x.JobCardClassId,
                        principalTable: "JobCardClasses",
                        principalColumn: "JobCardClassID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceDeskPortfolios_JobCardGenres_JobCardGenreId",
                        column: x => x.JobCardGenreId,
                        principalTable: "JobCardGenres",
                        principalColumn: "JobCardGenreID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceDeskPortfolios_JobCardGroups_JobCardGroupId",
                        column: x => x.JobCardGroupId,
                        principalTable: "JobCardGroups",
                        principalColumn: "JobCardGroupID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceDeskPortfolios_JobCardTypes_JobCardTypeId",
                        column: x => x.JobCardTypeId,
                        principalTable: "JobCardTypes",
                        principalColumn: "JobCardTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceDeskPortfolios_ServiceDesks_ServiceDeskId",
                        column: x => x.ServiceDeskId,
                        principalTable: "ServiceDesks",
                        principalColumn: "ServiceDeskID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceDeskPortfolios_ServiceTicketCategories_ServiceTicketCategoryId",
                        column: x => x.ServiceTicketCategoryId,
                        principalTable: "ServiceTicketCategories",
                        principalColumn: "ServiceTicketCategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTickets",
                columns: table => new
                {
                    ServiceTicketID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceTicketStatusId = table.Column<int>(type: "int", nullable: false),
                    ServiceTicketPriorityLevelId = table.Column<int>(type: "int", nullable: false),
                    ServiceTicketCategoryId = table.Column<int>(type: "int", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpenedOnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosedOnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AllowTransition = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTickets", x => x.ServiceTicketID);
                    table.ForeignKey(
                        name: "FK_ServiceTickets_ServiceTicketCategories_ServiceTicketCategoryId",
                        column: x => x.ServiceTicketCategoryId,
                        principalTable: "ServiceTicketCategories",
                        principalColumn: "ServiceTicketCategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceTickets_ServiceTicketPriorityLevels_ServiceTicketPriorityLevelId",
                        column: x => x.ServiceTicketPriorityLevelId,
                        principalTable: "ServiceTicketPriorityLevels",
                        principalColumn: "ServiceTicketPriorityLevelID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceTickets_ServiceTicketStatuses_ServiceTicketStatusId",
                        column: x => x.ServiceTicketStatusId,
                        principalTable: "ServiceTicketStatuses",
                        principalColumn: "ServiceTicketStatusID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SystemsCountries",
                columns: table => new
                {
                    SystemsCountryID = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    SystemsCurrencyId = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    SystemsCountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SystemsCountryShortCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemsCountries", x => x.SystemsCountryID);
                    table.ForeignKey(
                        name: "FK_SystemsCountries_SystemsCurrencies_SystemsCurrencyId",
                        column: x => x.SystemsCurrencyId,
                        principalTable: "SystemsCurrencies",
                        principalColumn: "SystemsCurrencyID");
                });

            migrationBuilder.CreateTable(
                name: "SystemsPages",
                columns: table => new
                {
                    SystemsPageID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SystemsModuleId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IsDefaultPage = table.Column<bool>(type: "bit", nullable: false),
                    AspPage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AspParentFolder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Index = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShowInMenu = table.Column<bool>(type: "bit", nullable: false),
                    EnableMenuItem = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemsPages", x => x.SystemsPageID);
                    table.ForeignKey(
                        name: "FK_SystemsPages_SystemsModules_SystemsModuleId",
                        column: x => x.SystemsModuleId,
                        principalTable: "SystemsModules",
                        principalColumn: "SystemsModuleID");
                });

            migrationBuilder.CreateTable(
                name: "SystemsNotifications",
                columns: table => new
                {
                    SystemsNotificationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemsNotificationTypeId = table.Column<int>(type: "int", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expiration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkToAction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SentSuccessfully = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemsNotifications", x => x.SystemsNotificationID);
                    table.ForeignKey(
                        name: "FK_SystemsNotifications_SystemsNotificationTypes_SystemsNotificationTypeId",
                        column: x => x.SystemsNotificationTypeId,
                        principalTable: "SystemsNotificationTypes",
                        principalColumn: "SystemsNotificationTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SystemsRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemsRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemsRoleClaims_SystemsRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "SystemsRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SystemsRoleFunctionalRoles",
                columns: table => new
                {
                    RoleFunctionalRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FunctionalRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuthorizationLevel = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemsRoleFunctionalRoles", x => x.RoleFunctionalRoleId);
                    table.ForeignKey(
                        name: "FK_SystemsRoleFunctionalRoles_SystemsFunctionalRoles_FunctionalRoleId",
                        column: x => x.FunctionalRoleId,
                        principalTable: "SystemsFunctionalRoles",
                        principalColumn: "FunctionalRoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SystemsRoleFunctionalRoles_SystemsRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "SystemsRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockProducts",
                columns: table => new
                {
                    StockProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockWarehouseId = table.Column<int>(type: "int", nullable: false),
                    EquipmentBrandId = table.Column<int>(type: "int", nullable: false),
                    EquipmentFamilyId = table.Column<int>(type: "int", nullable: false),
                    EquipmentCategoryId = table.Column<int>(type: "int", nullable: false),
                    EquipmentGroupId = table.Column<int>(type: "int", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductPartNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductSerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InventoryCount = table.Column<double>(type: "float", nullable: false),
                    AveragePrice = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockProducts", x => x.StockProductID);
                    table.ForeignKey(
                        name: "FK_StockProducts_EquipmentBrands_EquipmentBrandId",
                        column: x => x.EquipmentBrandId,
                        principalTable: "EquipmentBrands",
                        principalColumn: "EquipmentBrandID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockProducts_EquipmentCategories_EquipmentCategoryId",
                        column: x => x.EquipmentCategoryId,
                        principalTable: "EquipmentCategories",
                        principalColumn: "EquipmentCategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockProducts_EquipmentFamilies_EquipmentFamilyId",
                        column: x => x.EquipmentFamilyId,
                        principalTable: "EquipmentFamilies",
                        principalColumn: "EquipmentFamilyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockProducts_EquipmentGroups_EquipmentGroupId",
                        column: x => x.EquipmentGroupId,
                        principalTable: "EquipmentGroups",
                        principalColumn: "EquipmentGroupID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockProducts_StockWarehouses_StockWarehouseId",
                        column: x => x.StockWarehouseId,
                        principalTable: "StockWarehouses",
                        principalColumn: "StockWarehouseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobCards",
                columns: table => new
                {
                    JobCardID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceTicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceProjectId = table.Column<int>(type: "int", nullable: false),
                    JobCardStatusId = table.Column<int>(type: "int", nullable: false),
                    JobCardPriorityLevelId = table.Column<int>(type: "int", nullable: false),
                    JobCardTypeId = table.Column<int>(type: "int", nullable: false),
                    JobCardCategoryId = table.Column<int>(type: "int", nullable: false),
                    JobCardClassId = table.Column<int>(type: "int", nullable: false),
                    JobCardGroupId = table.Column<int>(type: "int", nullable: false),
                    JobCardGenreId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstimatedDuration = table.Column<TimeSpan>(type: "time", nullable: false),
                    ActualDuration = table.Column<TimeSpan>(type: "time", nullable: false),
                    AllowReOpen = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCards", x => x.JobCardID);
                    table.ForeignKey(
                        name: "FK_JobCards_JobCardCategories_JobCardCategoryId",
                        column: x => x.JobCardCategoryId,
                        principalTable: "JobCardCategories",
                        principalColumn: "JobCardCategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobCards_JobCardClasses_JobCardClassId",
                        column: x => x.JobCardClassId,
                        principalTable: "JobCardClasses",
                        principalColumn: "JobCardClassID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobCards_JobCardGenres_JobCardGenreId",
                        column: x => x.JobCardGenreId,
                        principalTable: "JobCardGenres",
                        principalColumn: "JobCardGenreID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobCards_JobCardGroups_JobCardGroupId",
                        column: x => x.JobCardGroupId,
                        principalTable: "JobCardGroups",
                        principalColumn: "JobCardGroupID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobCards_JobCardPriorityLevels_JobCardPriorityLevelId",
                        column: x => x.JobCardPriorityLevelId,
                        principalTable: "JobCardPriorityLevels",
                        principalColumn: "JobCardPriorityLevelID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobCards_JobCardStatuses_JobCardStatusId",
                        column: x => x.JobCardStatusId,
                        principalTable: "JobCardStatuses",
                        principalColumn: "JobCardStatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobCards_JobCardTypes_JobCardTypeId",
                        column: x => x.JobCardTypeId,
                        principalTable: "JobCardTypes",
                        principalColumn: "JobCardTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobCards_ServiceProjects_ServiceProjectId",
                        column: x => x.ServiceProjectId,
                        principalTable: "ServiceProjects",
                        principalColumn: "ServiceProjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobCards_ServiceTickets_ServiceTicketId",
                        column: x => x.ServiceTicketId,
                        principalTable: "ServiceTickets",
                        principalColumn: "ServiceTicketID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTicketAttachments",
                columns: table => new
                {
                    ServiceTicketAttachmentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceTicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttachmentUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTicketAttachments", x => x.ServiceTicketAttachmentID);
                    table.ForeignKey(
                        name: "FK_ServiceTicketAttachments_ServiceTickets_ServiceTicketId",
                        column: x => x.ServiceTicketId,
                        principalTable: "ServiceTickets",
                        principalColumn: "ServiceTicketID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SystemsCities",
                columns: table => new
                {
                    SystemCityID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemsCountryId = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemsCities", x => x.SystemCityID);
                    table.ForeignKey(
                        name: "FK_SystemsCities_SystemsCountries_SystemsCountryId",
                        column: x => x.SystemsCountryId,
                        principalTable: "SystemsCountries",
                        principalColumn: "SystemsCountryID");
                });

            migrationBuilder.CreateTable(
                name: "SystemsCountryPhoneCodes",
                columns: table => new
                {
                    SystemsCountryPhoneCodeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemsCountryId = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    SystemsCountryPhoneDialCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemsCountryPhoneCodes", x => x.SystemsCountryPhoneCodeID);
                    table.ForeignKey(
                        name: "FK_SystemsCountryPhoneCodes_SystemsCountries_SystemsCountryId",
                        column: x => x.SystemsCountryId,
                        principalTable: "SystemsCountries",
                        principalColumn: "SystemsCountryID");
                });

            migrationBuilder.CreateTable(
                name: "JobCardChecklists",
                columns: table => new
                {
                    JobCardChecklistID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobCardChecklistTemplateId = table.Column<int>(type: "int", nullable: false),
                    JobCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChecklistName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChecklistDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChecklistDuration = table.Column<TimeSpan>(type: "time", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCardChecklists", x => x.JobCardChecklistID);
                    table.ForeignKey(
                        name: "FK_JobCardChecklists_JobCardChecklistTemplates_JobCardChecklistTemplateId",
                        column: x => x.JobCardChecklistTemplateId,
                        principalTable: "JobCardChecklistTemplates",
                        principalColumn: "JobCardChecklistTemplateID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobCardChecklists_JobCards_JobCardId",
                        column: x => x.JobCardId,
                        principalTable: "JobCards",
                        principalColumn: "JobCardID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SystemsContactDetails",
                columns: table => new
                {
                    SystemsContactDetailID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemCityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemsCountryId = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    OfficeNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhysicalAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondaryPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPrimaryContact = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemsContactDetails", x => x.SystemsContactDetailID);
                    table.ForeignKey(
                        name: "FK_SystemsContactDetails_SystemsCities_SystemCityId",
                        column: x => x.SystemCityId,
                        principalTable: "SystemsCities",
                        principalColumn: "SystemCityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SystemsContactDetails_SystemsCountries_SystemsCountryId",
                        column: x => x.SystemsCountryId,
                        principalTable: "SystemsCountries",
                        principalColumn: "SystemsCountryID");
                });

            migrationBuilder.CreateTable(
                name: "SystemsBusinessProfiles",
                columns: table => new
                {
                    SystemsBusinessID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemsContactDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemsBusinessFullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemsBusinessShortname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemsBusinessLogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceNumberPrefix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuoteNumberPrefix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsVatEnabled = table.Column<bool>(type: "bit", nullable: false),
                    VatNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataConnectionString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemsBusinessProfiles", x => x.SystemsBusinessID);
                    table.ForeignKey(
                        name: "FK_SystemsBusinessProfiles_SystemsContactDetails_SystemsContactDetailId",
                        column: x => x.SystemsContactDetailId,
                        principalTable: "SystemsContactDetails",
                        principalColumn: "SystemsContactDetailID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SystemsBusinessCurrencies",
                columns: table => new
                {
                    SystemsBusinessCurrencyID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemsBusinessProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemsCurrencyId = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    IsBaseCurrency = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemsBusinessCurrencies", x => x.SystemsBusinessCurrencyID);
                    table.ForeignKey(
                        name: "FK_SystemsBusinessCurrencies_SystemsBusinessProfiles_SystemsBusinessProfileId",
                        column: x => x.SystemsBusinessProfileId,
                        principalTable: "SystemsBusinessProfiles",
                        principalColumn: "SystemsBusinessID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SystemsBusinessCurrencies_SystemsCurrencies_SystemsCurrencyId",
                        column: x => x.SystemsCurrencyId,
                        principalTable: "SystemsCurrencies",
                        principalColumn: "SystemsCurrencyID");
                });

            migrationBuilder.CreateTable(
                name: "SystemsBusinessLicenses",
                columns: table => new
                {
                    SystemsBusinessLicenseID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemsBusinessProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LicenseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicenseKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicenseStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LicenseExpiry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemsBusinessLicenses", x => x.SystemsBusinessLicenseID);
                    table.ForeignKey(
                        name: "FK_SystemsBusinessLicenses_SystemsBusinessProfiles_SystemsBusinessProfileId",
                        column: x => x.SystemsBusinessProfileId,
                        principalTable: "SystemsBusinessProfiles",
                        principalColumn: "SystemsBusinessID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SystemsUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemsBusinessProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvatorFileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsBuiltInSystemsUser = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_SystemsUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemsUsers_SystemsBusinessProfiles_SystemsBusinessProfileId",
                        column: x => x.SystemsBusinessProfileId,
                        principalTable: "SystemsBusinessProfiles",
                        principalColumn: "SystemsBusinessID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerInvoices",
                columns: table => new
                {
                    CustomerInvoiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemsBusinessProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalTaxDue = table.Column<double>(type: "float", nullable: false),
                    TotalInvoiceAmount = table.Column<double>(type: "float", nullable: false),
                    SystemsBusinessCurrencyID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInvoices", x => x.CustomerInvoiceID);
                    table.ForeignKey(
                        name: "FK_CustomerInvoices_SystemsBusinessCurrencies_SystemsBusinessCurrencyID",
                        column: x => x.SystemsBusinessCurrencyID,
                        principalTable: "SystemsBusinessCurrencies",
                        principalColumn: "SystemsBusinessCurrencyID");
                    table.ForeignKey(
                        name: "FK_CustomerInvoices_SystemsBusinessProfiles_SystemsBusinessProfileId",
                        column: x => x.SystemsBusinessProfileId,
                        principalTable: "SystemsBusinessProfiles",
                        principalColumn: "SystemsBusinessID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPayments",
                columns: table => new
                {
                    CustomerPaymentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemsBusinessProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalAmountDue = table.Column<double>(type: "float", nullable: false),
                    TotalPaidAmount = table.Column<double>(type: "float", nullable: false),
                    SystemsBusinessCurrencyID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPayments", x => x.CustomerPaymentID);
                    table.ForeignKey(
                        name: "FK_CustomerPayments_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "PaymentMethodID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerPayments_SystemsBusinessCurrencies_SystemsBusinessCurrencyID",
                        column: x => x.SystemsBusinessCurrencyID,
                        principalTable: "SystemsBusinessCurrencies",
                        principalColumn: "SystemsBusinessCurrencyID");
                    table.ForeignKey(
                        name: "FK_CustomerPayments_SystemsBusinessProfiles_SystemsBusinessProfileId",
                        column: x => x.SystemsBusinessProfileId,
                        principalTable: "SystemsBusinessProfiles",
                        principalColumn: "SystemsBusinessID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerProfiles",
                columns: table => new
                {
                    CustomerProfileID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemsContactDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemsUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerProfiles", x => x.CustomerProfileID);
                    table.ForeignKey(
                        name: "FK_CustomerProfiles_SystemsContactDetails_SystemsContactDetailId",
                        column: x => x.SystemsContactDetailId,
                        principalTable: "SystemsContactDetails",
                        principalColumn: "SystemsContactDetailID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerProfiles_SystemsUsers_SystemsUserId",
                        column: x => x.SystemsUserId,
                        principalTable: "SystemsUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServiceOfficerProfiles",
                columns: table => new
                {
                    ServiceOfficerProfileID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemsContactDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceOfficerDesignationId = table.Column<int>(type: "int", nullable: false),
                    InputterLevel = table.Column<int>(type: "int", nullable: false),
                    AuthorizerLevel = table.Column<int>(type: "int", nullable: false),
                    SystemsUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceOfficerProfiles", x => x.ServiceOfficerProfileID);
                    table.ForeignKey(
                        name: "FK_ServiceOfficerProfiles_ServiceOfficerDesignations_ServiceOfficerDesignationId",
                        column: x => x.ServiceOfficerDesignationId,
                        principalTable: "ServiceOfficerDesignations",
                        principalColumn: "ServiceOfficerDesignationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceOfficerProfiles_SystemsContactDetails_SystemsContactDetailId",
                        column: x => x.SystemsContactDetailId,
                        principalTable: "SystemsContactDetails",
                        principalColumn: "SystemsContactDetailID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceOfficerProfiles_SystemsUsers_SystemsUserId",
                        column: x => x.SystemsUserId,
                        principalTable: "SystemsUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SystemsActivityLogs",
                columns: table => new
                {
                    SystemsActivityLogID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimeStampUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogLevel = table.Column<int>(type: "int", nullable: false),
                    ActivityStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemsActivityLogs", x => x.SystemsActivityLogID);
                    table.ForeignKey(
                        name: "FK_SystemsActivityLogs_SystemsUsers_SystemsActivityLogID",
                        column: x => x.SystemsActivityLogID,
                        principalTable: "SystemsUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SystemsUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemsUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemsUserClaims_SystemsUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "SystemsUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SystemsUserDevices",
                columns: table => new
                {
                    SystemsUserDeviceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemsUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CPUArchitecture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceVendor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngineName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngineVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperatingSystemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperatingSystemVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UA = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemsUserDevices", x => x.SystemsUserDeviceID);
                    table.ForeignKey(
                        name: "FK_SystemsUserDevices_SystemsUsers_SystemsUserDeviceID",
                        column: x => x.SystemsUserDeviceID,
                        principalTable: "SystemsUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SystemsUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemsUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_SystemsUserLogins_SystemsUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "SystemsUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SystemsUserNotifications",
                columns: table => new
                {
                    SystemsUserNotificationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemsNotificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemsUserNotifications", x => x.SystemsUserNotificationID);
                    table.ForeignKey(
                        name: "FK_SystemsUserNotifications_SystemsNotifications_SystemsNotificationId",
                        column: x => x.SystemsNotificationId,
                        principalTable: "SystemsNotifications",
                        principalColumn: "SystemsNotificationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SystemsUserNotifications_SystemsUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "SystemsUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SystemsUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemsUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_SystemsUserRoles_SystemsRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "SystemsRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SystemsUserRoles_SystemsUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "SystemsUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SystemsUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemsUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_SystemsUserTokens_SystemsUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "SystemsUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerInvoiceTaxations",
                columns: table => new
                {
                    CustomerInvoiceTaxationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerInvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxationTypeId = table.Column<int>(type: "int", nullable: false),
                    TaxableAmount = table.Column<double>(type: "float", nullable: false),
                    TaxDue = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInvoiceTaxations", x => x.CustomerInvoiceTaxationID);
                    table.ForeignKey(
                        name: "FK_CustomerInvoiceTaxations_CustomerInvoices_CustomerInvoiceId",
                        column: x => x.CustomerInvoiceId,
                        principalTable: "CustomerInvoices",
                        principalColumn: "CustomerInvoiceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerInvoiceTaxations_TaxationTypes_TaxationTypeId",
                        column: x => x.TaxationTypeId,
                        principalTable: "TaxationTypes",
                        principalColumn: "TaxationTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerEquipment",
                columns: table => new
                {
                    CustomerEquipmentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquipmentBrandId = table.Column<int>(type: "int", nullable: false),
                    EquipmentFamilyId = table.Column<int>(type: "int", nullable: false),
                    EquipmentCategoryId = table.Column<int>(type: "int", nullable: false),
                    EquipmentGroupId = table.Column<int>(type: "int", nullable: false),
                    EquipmentCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EquipmentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EquipmentDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EquipmentModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EquipmentPartNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EquipmentSerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EquipmentCount = table.Column<double>(type: "float", nullable: false),
                    WarrantyTerms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerEquipment", x => x.CustomerEquipmentID);
                    table.ForeignKey(
                        name: "FK_CustomerEquipment_CustomerProfiles_CustomerProfileId",
                        column: x => x.CustomerProfileId,
                        principalTable: "CustomerProfiles",
                        principalColumn: "CustomerProfileID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerEquipment_EquipmentBrands_EquipmentBrandId",
                        column: x => x.EquipmentBrandId,
                        principalTable: "EquipmentBrands",
                        principalColumn: "EquipmentBrandID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerEquipment_EquipmentCategories_EquipmentCategoryId",
                        column: x => x.EquipmentCategoryId,
                        principalTable: "EquipmentCategories",
                        principalColumn: "EquipmentCategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerEquipment_EquipmentFamilies_EquipmentFamilyId",
                        column: x => x.EquipmentFamilyId,
                        principalTable: "EquipmentFamilies",
                        principalColumn: "EquipmentFamilyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerEquipment_EquipmentGroups_EquipmentGroupId",
                        column: x => x.EquipmentGroupId,
                        principalTable: "EquipmentGroups",
                        principalColumn: "EquipmentGroupID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerServiceTickets",
                columns: table => new
                {
                    CustomerServiceTicketID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceTicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceRating = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerServiceTickets", x => x.CustomerServiceTicketID);
                    table.ForeignKey(
                        name: "FK_CustomerServiceTickets_CustomerProfiles_CustomerProfileId",
                        column: x => x.CustomerProfileId,
                        principalTable: "CustomerProfiles",
                        principalColumn: "CustomerProfileID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerServiceTickets_ServiceTickets_ServiceTicketId",
                        column: x => x.ServiceTicketId,
                        principalTable: "ServiceTickets",
                        principalColumn: "ServiceTicketID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobCardChecklistTasks",
                columns: table => new
                {
                    JobCardChecklistTaskID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceOfficerProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobCardChecklistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobTaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskStarted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskCompleted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TechnicalRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCardChecklistTasks", x => x.JobCardChecklistTaskID);
                    table.ForeignKey(
                        name: "FK_JobCardChecklistTasks_JobCardChecklists_JobCardChecklistId",
                        column: x => x.JobCardChecklistId,
                        principalTable: "JobCardChecklists",
                        principalColumn: "JobCardChecklistID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobCardChecklistTasks_JobTasks_JobTaskId",
                        column: x => x.JobTaskId,
                        principalTable: "JobTasks",
                        principalColumn: "JobTaskID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobCardChecklistTasks_ServiceOfficerProfiles_ServiceOfficerProfileId",
                        column: x => x.ServiceOfficerProfileId,
                        principalTable: "ServiceOfficerProfiles",
                        principalColumn: "ServiceOfficerProfileID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceDeskMembers",
                columns: table => new
                {
                    ServiceDeskMemberID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceDeskId = table.Column<int>(type: "int", nullable: false),
                    ServiceOfficerProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceDeskMembers", x => x.ServiceDeskMemberID);
                    table.ForeignKey(
                        name: "FK_ServiceDeskMembers_ServiceDesks_ServiceDeskId",
                        column: x => x.ServiceDeskId,
                        principalTable: "ServiceDesks",
                        principalColumn: "ServiceDeskID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceDeskMembers_ServiceOfficerProfiles_ServiceOfficerProfileId",
                        column: x => x.ServiceOfficerProfileId,
                        principalTable: "ServiceOfficerProfiles",
                        principalColumn: "ServiceOfficerProfileID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TravelPlanBookings",
                columns: table => new
                {
                    TravelPlanBookingID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TravelPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceOfficerProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeferredDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsDeferred = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelPlanBookings", x => x.TravelPlanBookingID);
                    table.ForeignKey(
                        name: "FK_TravelPlanBookings_ServiceOfficerProfiles_ServiceOfficerProfileId",
                        column: x => x.ServiceOfficerProfileId,
                        principalTable: "ServiceOfficerProfiles",
                        principalColumn: "ServiceOfficerProfileID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TravelPlanBookings_TravelPlans_TravelPlanId",
                        column: x => x.TravelPlanId,
                        principalTable: "TravelPlans",
                        principalColumn: "TravelPlanID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SystemsAuditEvents",
                columns: table => new
                {
                    SystemsAuditEventID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemsActivityLogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemsModuleId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    SystemsPageId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    EventDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemsAuditEvents", x => x.SystemsAuditEventID);
                    table.ForeignKey(
                        name: "FK_SystemsAuditEvents_SystemsActivityLogs_SystemsActivityLogId",
                        column: x => x.SystemsActivityLogId,
                        principalTable: "SystemsActivityLogs",
                        principalColumn: "SystemsActivityLogID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SystemsAuditEvents_SystemsModules_SystemsModuleId",
                        column: x => x.SystemsModuleId,
                        principalTable: "SystemsModules",
                        principalColumn: "SystemsModuleID");
                    table.ForeignKey(
                        name: "FK_SystemsAuditEvents_SystemsPages_SystemsPageId",
                        column: x => x.SystemsPageId,
                        principalTable: "SystemsPages",
                        principalColumn: "SystemsPageID");
                });

            migrationBuilder.CreateTable(
                name: "SystemsUserDeviceLogins",
                columns: table => new
                {
                    SystemsUserDeviceLoginID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemsUserDeviceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogoutTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<double>(type: "float", nullable: false),
                    TimeZone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublicIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrowserUniqueID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrowserMajor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrowserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrowserVersion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemsUserDeviceLogins", x => x.SystemsUserDeviceLoginID);
                    table.ForeignKey(
                        name: "FK_SystemsUserDeviceLogins_SystemsUserDevices_SystemsUserDeviceId",
                        column: x => x.SystemsUserDeviceId,
                        principalTable: "SystemsUserDevices",
                        principalColumn: "SystemsUserDeviceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerServiceRatings",
                columns: table => new
                {
                    CustomerServiceRatingID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerFeedbackQuestionId = table.Column<int>(type: "int", nullable: false),
                    CustomerServiceTicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RatingScore = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerServiceRatings", x => x.CustomerServiceRatingID);
                    table.ForeignKey(
                        name: "FK_CustomerServiceRatings_CustomerFeedbackQuestions_CustomerFeedbackQuestionId",
                        column: x => x.CustomerFeedbackQuestionId,
                        principalTable: "CustomerFeedbackQuestions",
                        principalColumn: "CustomerFeedbackQuestionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerServiceRatings_CustomerServiceTickets_CustomerServiceTicketId",
                        column: x => x.CustomerServiceTicketId,
                        principalTable: "CustomerServiceTickets",
                        principalColumn: "CustomerServiceTicketID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobCardsAllocations",
                columns: table => new
                {
                    JobCardAllocationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceDeskMemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceLevelDuration = table.Column<TimeSpan>(type: "time", nullable: false),
                    AssignOnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPrimaryTechnician = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCardsAllocations", x => x.JobCardAllocationID);
                    table.ForeignKey(
                        name: "FK_JobCardsAllocations_JobCards_JobCardId",
                        column: x => x.JobCardId,
                        principalTable: "JobCards",
                        principalColumn: "JobCardID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobCardsAllocations_ServiceDeskMembers_ServiceDeskMemberId",
                        column: x => x.ServiceDeskMemberId,
                        principalTable: "ServiceDeskMembers",
                        principalColumn: "ServiceDeskMemberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTicketAllocations",
                columns: table => new
                {
                    ServiceTicketAllocationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceTicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceDeskMemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceLevelDuration = table.Column<TimeSpan>(type: "time", nullable: false),
                    AssignOnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTicketAllocations", x => x.ServiceTicketAllocationID);
                    table.ForeignKey(
                        name: "FK_ServiceTicketAllocations_ServiceDeskMembers_ServiceDeskMemberId",
                        column: x => x.ServiceDeskMemberId,
                        principalTable: "ServiceDeskMembers",
                        principalColumn: "ServiceDeskMemberID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceTicketAllocations_ServiceTickets_ServiceTicketId",
                        column: x => x.ServiceTicketId,
                        principalTable: "ServiceTickets",
                        principalColumn: "ServiceTicketID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TravelIteneraries",
                columns: table => new
                {
                    TravelIteneraryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TravelEventId = table.Column<int>(type: "int", nullable: false),
                    TravelPlanBookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LatitudeAccuracy = table.Column<double>(type: "float", nullable: false),
                    LongitudeAccuracy = table.Column<double>(type: "float", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelIteneraries", x => x.TravelIteneraryID);
                    table.ForeignKey(
                        name: "FK_TravelIteneraries_TravelEvents_TravelEventId",
                        column: x => x.TravelEventId,
                        principalTable: "TravelEvents",
                        principalColumn: "TravelEventID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TravelIteneraries_TravelPlanBookings_TravelPlanBookingId",
                        column: x => x.TravelPlanBookingId,
                        principalTable: "TravelPlanBookings",
                        principalColumn: "TravelPlanBookingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SystemsChangeLogs",
                columns: table => new
                {
                    SystemsChangeLogID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemsAuditEventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChangeStatus = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChangedToValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemsChangeLogs", x => x.SystemsChangeLogID);
                    table.ForeignKey(
                        name: "FK_SystemsChangeLogs_SystemsAuditEvents_SystemsAuditEventId",
                        column: x => x.SystemsAuditEventId,
                        principalTable: "SystemsAuditEvents",
                        principalColumn: "SystemsAuditEventID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTicketTasks",
                columns: table => new
                {
                    ServiceTicketTaskID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceTicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceOfficerProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskStarted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskCompleted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TechnicalRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    ServiceTicketAllocationID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTicketTasks", x => x.ServiceTicketTaskID);
                    table.ForeignKey(
                        name: "FK_ServiceTicketTasks_ServiceOfficerProfiles_ServiceOfficerProfileId",
                        column: x => x.ServiceOfficerProfileId,
                        principalTable: "ServiceOfficerProfiles",
                        principalColumn: "ServiceOfficerProfileID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceTicketTasks_ServiceTicketAllocations_ServiceTicketAllocationID",
                        column: x => x.ServiceTicketAllocationID,
                        principalTable: "ServiceTicketAllocations",
                        principalColumn: "ServiceTicketAllocationID");
                    table.ForeignKey(
                        name: "FK_ServiceTicketTasks_ServiceTickets_ServiceTicketId",
                        column: x => x.ServiceTicketId,
                        principalTable: "ServiceTickets",
                        principalColumn: "ServiceTicketID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobTimeCards",
                columns: table => new
                {
                    JobTimeCardID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TravelIteneraryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TravelIteneraryDuration = table.Column<TimeSpan>(type: "time", nullable: false),
                    ApprovedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISApproved = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTimeCards", x => x.JobTimeCardID);
                    table.ForeignKey(
                        name: "FK_JobTimeCards_JobCards_JobCardId",
                        column: x => x.JobCardId,
                        principalTable: "JobCards",
                        principalColumn: "JobCardID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobTimeCards_TravelIteneraries_TravelIteneraryId",
                        column: x => x.TravelIteneraryId,
                        principalTable: "TravelIteneraries",
                        principalColumn: "TravelIteneraryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTicketTaskSteps",
                columns: table => new
                {
                    CustomerServiceTicketTaskStepID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceTicketTaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StepsTaken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTicketTaskSteps", x => x.CustomerServiceTicketTaskStepID);
                    table.ForeignKey(
                        name: "FK_ServiceTicketTaskSteps_ServiceTicketTasks_ServiceTicketTaskId",
                        column: x => x.ServiceTicketTaskId,
                        principalTable: "ServiceTicketTasks",
                        principalColumn: "ServiceTicketTaskID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerEquipment_CustomerProfileId",
                table: "CustomerEquipment",
                column: "CustomerProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerEquipment_EquipmentBrandId",
                table: "CustomerEquipment",
                column: "EquipmentBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerEquipment_EquipmentCategoryId",
                table: "CustomerEquipment",
                column: "EquipmentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerEquipment_EquipmentFamilyId",
                table: "CustomerEquipment",
                column: "EquipmentFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerEquipment_EquipmentGroupId",
                table: "CustomerEquipment",
                column: "EquipmentGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInvoices_SystemsBusinessCurrencyID",
                table: "CustomerInvoices",
                column: "SystemsBusinessCurrencyID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInvoices_SystemsBusinessProfileId",
                table: "CustomerInvoices",
                column: "SystemsBusinessProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInvoiceTaxations_CustomerInvoiceId",
                table: "CustomerInvoiceTaxations",
                column: "CustomerInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInvoiceTaxations_TaxationTypeId",
                table: "CustomerInvoiceTaxations",
                column: "TaxationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPayments_PaymentMethodId",
                table: "CustomerPayments",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPayments_SystemsBusinessCurrencyID",
                table: "CustomerPayments",
                column: "SystemsBusinessCurrencyID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPayments_SystemsBusinessProfileId",
                table: "CustomerPayments",
                column: "SystemsBusinessProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProfiles_SystemsContactDetailId",
                table: "CustomerProfiles",
                column: "SystemsContactDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProfiles_SystemsUserId",
                table: "CustomerProfiles",
                column: "SystemsUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerServiceRatings_CustomerFeedbackQuestionId",
                table: "CustomerServiceRatings",
                column: "CustomerFeedbackQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerServiceRatings_CustomerServiceTicketId",
                table: "CustomerServiceRatings",
                column: "CustomerServiceTicketId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerServiceTickets_CustomerProfileId",
                table: "CustomerServiceTickets",
                column: "CustomerProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerServiceTickets_ServiceTicketId",
                table: "CustomerServiceTickets",
                column: "ServiceTicketId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentBrands_EquipmentManufacturerId",
                table: "EquipmentBrands",
                column: "EquipmentManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentCategoryGroups_EquipmentCategoryId",
                table: "EquipmentCategoryGroups",
                column: "EquipmentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentCategoryGroups_EquipmentGroupId",
                table: "EquipmentCategoryGroups",
                column: "EquipmentGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentFamilyCategories_EquipmentCategoryId",
                table: "EquipmentFamilyCategories",
                column: "EquipmentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentFamilyCategories_EquipmentFamilyId",
                table: "EquipmentFamilyCategories",
                column: "EquipmentFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_JobCardCategoryClasses_JobCardCategoryId",
                table: "JobCardCategoryClasses",
                column: "JobCardCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_JobCardCategoryClasses_JobCardClassId",
                table: "JobCardCategoryClasses",
                column: "JobCardClassId");

            migrationBuilder.CreateIndex(
                name: "IX_JobCardChecklists_JobCardChecklistTemplateId",
                table: "JobCardChecklists",
                column: "JobCardChecklistTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_JobCardChecklists_JobCardId",
                table: "JobCardChecklists",
                column: "JobCardId");

            migrationBuilder.CreateIndex(
                name: "IX_JobCardChecklistTasks_JobCardChecklistId",
                table: "JobCardChecklistTasks",
                column: "JobCardChecklistId");

            migrationBuilder.CreateIndex(
                name: "IX_JobCardChecklistTasks_JobTaskId",
                table: "JobCardChecklistTasks",
                column: "JobTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_JobCardChecklistTasks_ServiceOfficerProfileId",
                table: "JobCardChecklistTasks",
                column: "ServiceOfficerProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_JobCardChecklistTemplateTasks_JobCardChecklistTemplateId",
                table: "JobCardChecklistTemplateTasks",
                column: "JobCardChecklistTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_JobCardChecklistTemplateTasks_JobTaskId",
                table: "JobCardChecklistTemplateTasks",
                column: "JobTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_JobCardClassGroups_JobCardClassId",
                table: "JobCardClassGroups",
                column: "JobCardClassId");

            migrationBuilder.CreateIndex(
                name: "IX_JobCardClassGroups_JobCardGroupId",
                table: "JobCardClassGroups",
                column: "JobCardGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_JobCardGroupGenres_JobCardGenreId",
                table: "JobCardGroupGenres",
                column: "JobCardGenreId");

            migrationBuilder.CreateIndex(
                name: "IX_JobCardGroupGenres_JobCardGroupId",
                table: "JobCardGroupGenres",
                column: "JobCardGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_JobCards_JobCardCategoryId",
                table: "JobCards",
                column: "JobCardCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_JobCards_JobCardClassId",
                table: "JobCards",
                column: "JobCardClassId");

            migrationBuilder.CreateIndex(
                name: "IX_JobCards_JobCardGenreId",
                table: "JobCards",
                column: "JobCardGenreId");

            migrationBuilder.CreateIndex(
                name: "IX_JobCards_JobCardGroupId",
                table: "JobCards",
                column: "JobCardGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_JobCards_JobCardPriorityLevelId",
                table: "JobCards",
                column: "JobCardPriorityLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_JobCards_JobCardStatusId",
                table: "JobCards",
                column: "JobCardStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_JobCards_JobCardTypeId",
                table: "JobCards",
                column: "JobCardTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobCards_ServiceProjectId",
                table: "JobCards",
                column: "ServiceProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_JobCards_ServiceTicketId",
                table: "JobCards",
                column: "ServiceTicketId");

            migrationBuilder.CreateIndex(
                name: "IX_JobCardsAllocations_JobCardId",
                table: "JobCardsAllocations",
                column: "JobCardId");

            migrationBuilder.CreateIndex(
                name: "IX_JobCardsAllocations_ServiceDeskMemberId",
                table: "JobCardsAllocations",
                column: "ServiceDeskMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_JobCardTypeCategories_JobCardCategoryId",
                table: "JobCardTypeCategories",
                column: "JobCardCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_JobCardTypeCategories_JobCardTypeId",
                table: "JobCardTypeCategories",
                column: "JobCardTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTaskSteps_JobTaskId",
                table: "JobTaskSteps",
                column: "JobTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTimeCards_JobCardId",
                table: "JobTimeCards",
                column: "JobCardId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTimeCards_TravelIteneraryId",
                table: "JobTimeCards",
                column: "TravelIteneraryId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDeskMembers_ServiceDeskId",
                table: "ServiceDeskMembers",
                column: "ServiceDeskId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDeskMembers_ServiceOfficerProfileId",
                table: "ServiceDeskMembers",
                column: "ServiceOfficerProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDeskPortfolios_JobCardCategoryId",
                table: "ServiceDeskPortfolios",
                column: "JobCardCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDeskPortfolios_JobCardClassId",
                table: "ServiceDeskPortfolios",
                column: "JobCardClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDeskPortfolios_JobCardGenreId",
                table: "ServiceDeskPortfolios",
                column: "JobCardGenreId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDeskPortfolios_JobCardGroupId",
                table: "ServiceDeskPortfolios",
                column: "JobCardGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDeskPortfolios_JobCardTypeId",
                table: "ServiceDeskPortfolios",
                column: "JobCardTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDeskPortfolios_ServiceDeskId",
                table: "ServiceDeskPortfolios",
                column: "ServiceDeskId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDeskPortfolios_ServiceTicketCategoryId",
                table: "ServiceDeskPortfolios",
                column: "ServiceTicketCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDeskProjectAllocations_ServiceDeskId",
                table: "ServiceDeskProjectAllocations",
                column: "ServiceDeskId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDeskProjectAllocations_ServiceProjectId",
                table: "ServiceDeskProjectAllocations",
                column: "ServiceProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOfficerProfiles_ServiceOfficerDesignationId",
                table: "ServiceOfficerProfiles",
                column: "ServiceOfficerDesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOfficerProfiles_SystemsContactDetailId",
                table: "ServiceOfficerProfiles",
                column: "SystemsContactDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOfficerProfiles_SystemsUserId",
                table: "ServiceOfficerProfiles",
                column: "SystemsUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTicketAllocations_ServiceDeskMemberId",
                table: "ServiceTicketAllocations",
                column: "ServiceDeskMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTicketAllocations_ServiceTicketId",
                table: "ServiceTicketAllocations",
                column: "ServiceTicketId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTicketAttachments_ServiceTicketId",
                table: "ServiceTicketAttachments",
                column: "ServiceTicketId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTickets_ServiceTicketCategoryId",
                table: "ServiceTickets",
                column: "ServiceTicketCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTickets_ServiceTicketPriorityLevelId",
                table: "ServiceTickets",
                column: "ServiceTicketPriorityLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTickets_ServiceTicketStatusId",
                table: "ServiceTickets",
                column: "ServiceTicketStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTicketTasks_ServiceOfficerProfileId",
                table: "ServiceTicketTasks",
                column: "ServiceOfficerProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTicketTasks_ServiceTicketAllocationID",
                table: "ServiceTicketTasks",
                column: "ServiceTicketAllocationID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTicketTasks_ServiceTicketId",
                table: "ServiceTicketTasks",
                column: "ServiceTicketId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTicketTaskSteps_ServiceTicketTaskId",
                table: "ServiceTicketTaskSteps",
                column: "ServiceTicketTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_StockProducts_EquipmentBrandId",
                table: "StockProducts",
                column: "EquipmentBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_StockProducts_EquipmentCategoryId",
                table: "StockProducts",
                column: "EquipmentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_StockProducts_EquipmentFamilyId",
                table: "StockProducts",
                column: "EquipmentFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_StockProducts_EquipmentGroupId",
                table: "StockProducts",
                column: "EquipmentGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_StockProducts_StockWarehouseId",
                table: "StockProducts",
                column: "StockWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemsAuditEvents_SystemsActivityLogId",
                table: "SystemsAuditEvents",
                column: "SystemsActivityLogId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemsAuditEvents_SystemsModuleId",
                table: "SystemsAuditEvents",
                column: "SystemsModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemsAuditEvents_SystemsPageId",
                table: "SystemsAuditEvents",
                column: "SystemsPageId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemsBusinessCurrencies_SystemsBusinessProfileId",
                table: "SystemsBusinessCurrencies",
                column: "SystemsBusinessProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemsBusinessCurrencies_SystemsCurrencyId",
                table: "SystemsBusinessCurrencies",
                column: "SystemsCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemsBusinessLicenses_SystemsBusinessProfileId",
                table: "SystemsBusinessLicenses",
                column: "SystemsBusinessProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemsBusinessProfiles_SystemsContactDetailId",
                table: "SystemsBusinessProfiles",
                column: "SystemsContactDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemsChangeLogs_SystemsAuditEventId",
                table: "SystemsChangeLogs",
                column: "SystemsAuditEventId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemsCities_SystemsCountryId",
                table: "SystemsCities",
                column: "SystemsCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemsContactDetails_SystemCityId",
                table: "SystemsContactDetails",
                column: "SystemCityId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemsContactDetails_SystemsCountryId",
                table: "SystemsContactDetails",
                column: "SystemsCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemsCountries_SystemsCurrencyId",
                table: "SystemsCountries",
                column: "SystemsCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemsCountryPhoneCodes_SystemsCountryId",
                table: "SystemsCountryPhoneCodes",
                column: "SystemsCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemsNotifications_SystemsNotificationTypeId",
                table: "SystemsNotifications",
                column: "SystemsNotificationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemsPages_SystemsModuleId",
                table: "SystemsPages",
                column: "SystemsModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemsRoleClaims_RoleId",
                table: "SystemsRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemsRoleFunctionalRoles_FunctionalRoleId",
                table: "SystemsRoleFunctionalRoles",
                column: "FunctionalRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemsRoleFunctionalRoles_RoleId",
                table: "SystemsRoleFunctionalRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "SystemsRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SystemsUserClaims_UserId",
                table: "SystemsUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemsUserDeviceLogins_SystemsUserDeviceId",
                table: "SystemsUserDeviceLogins",
                column: "SystemsUserDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemsUserLogins_UserId",
                table: "SystemsUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemsUserNotifications_SystemsNotificationId",
                table: "SystemsUserNotifications",
                column: "SystemsNotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemsUserNotifications_UserId",
                table: "SystemsUserNotifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemsUserRoles_RoleId",
                table: "SystemsUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "SystemsUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_SystemsUsers_SystemsBusinessProfileId",
                table: "SystemsUsers",
                column: "SystemsBusinessProfileId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "SystemsUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TravelIteneraries_TravelEventId",
                table: "TravelIteneraries",
                column: "TravelEventId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelIteneraries_TravelPlanBookingId",
                table: "TravelIteneraries",
                column: "TravelPlanBookingId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelPlanBookings_ServiceOfficerProfileId",
                table: "TravelPlanBookings",
                column: "ServiceOfficerProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelPlanBookings_TravelPlanId",
                table: "TravelPlanBookings",
                column: "TravelPlanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerEquipment");

            migrationBuilder.DropTable(
                name: "CustomerInvoiceTaxations");

            migrationBuilder.DropTable(
                name: "CustomerPayments");

            migrationBuilder.DropTable(
                name: "CustomerServiceRatings");

            migrationBuilder.DropTable(
                name: "EquipmentCategoryGroups");

            migrationBuilder.DropTable(
                name: "EquipmentFamilyCategories");

            migrationBuilder.DropTable(
                name: "JobCardCategoryClasses");

            migrationBuilder.DropTable(
                name: "JobCardChecklistTasks");

            migrationBuilder.DropTable(
                name: "JobCardChecklistTemplateTasks");

            migrationBuilder.DropTable(
                name: "JobCardClassGroups");

            migrationBuilder.DropTable(
                name: "JobCardGroupGenres");

            migrationBuilder.DropTable(
                name: "JobCardsAllocations");

            migrationBuilder.DropTable(
                name: "JobCardTypeCategories");

            migrationBuilder.DropTable(
                name: "JobTaskSteps");

            migrationBuilder.DropTable(
                name: "JobTimeCards");

            migrationBuilder.DropTable(
                name: "ServiceDeskPortfolios");

            migrationBuilder.DropTable(
                name: "ServiceDeskProjectAllocations");

            migrationBuilder.DropTable(
                name: "ServiceTicketAttachments");

            migrationBuilder.DropTable(
                name: "ServiceTicketTaskSteps");

            migrationBuilder.DropTable(
                name: "StockProducts");

            migrationBuilder.DropTable(
                name: "SystemsAuthenticationTickets");

            migrationBuilder.DropTable(
                name: "SystemsBusinessLicenses");

            migrationBuilder.DropTable(
                name: "SystemsChangeLogs");

            migrationBuilder.DropTable(
                name: "SystemsCountryPhoneCodes");

            migrationBuilder.DropTable(
                name: "SystemsRefreshTokens");

            migrationBuilder.DropTable(
                name: "SystemsRoleClaims");

            migrationBuilder.DropTable(
                name: "SystemsRoleFunctionalRoles");

            migrationBuilder.DropTable(
                name: "SystemsSettings");

            migrationBuilder.DropTable(
                name: "SystemsUserClaims");

            migrationBuilder.DropTable(
                name: "SystemsUserDeviceLogins");

            migrationBuilder.DropTable(
                name: "SystemsUserLogins");

            migrationBuilder.DropTable(
                name: "SystemsUserNotifications");

            migrationBuilder.DropTable(
                name: "SystemsUserRoles");

            migrationBuilder.DropTable(
                name: "SystemsUserTokens");

            migrationBuilder.DropTable(
                name: "CustomerInvoices");

            migrationBuilder.DropTable(
                name: "TaxationTypes");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "CustomerFeedbackQuestions");

            migrationBuilder.DropTable(
                name: "CustomerServiceTickets");

            migrationBuilder.DropTable(
                name: "JobCardChecklists");

            migrationBuilder.DropTable(
                name: "JobTasks");

            migrationBuilder.DropTable(
                name: "TravelIteneraries");

            migrationBuilder.DropTable(
                name: "ServiceTicketTasks");

            migrationBuilder.DropTable(
                name: "EquipmentBrands");

            migrationBuilder.DropTable(
                name: "EquipmentCategories");

            migrationBuilder.DropTable(
                name: "EquipmentFamilies");

            migrationBuilder.DropTable(
                name: "EquipmentGroups");

            migrationBuilder.DropTable(
                name: "StockWarehouses");

            migrationBuilder.DropTable(
                name: "SystemsAuditEvents");

            migrationBuilder.DropTable(
                name: "SystemsFunctionalRoles");

            migrationBuilder.DropTable(
                name: "SystemsUserDevices");

            migrationBuilder.DropTable(
                name: "SystemsNotifications");

            migrationBuilder.DropTable(
                name: "SystemsRoles");

            migrationBuilder.DropTable(
                name: "SystemsBusinessCurrencies");

            migrationBuilder.DropTable(
                name: "CustomerProfiles");

            migrationBuilder.DropTable(
                name: "JobCardChecklistTemplates");

            migrationBuilder.DropTable(
                name: "JobCards");

            migrationBuilder.DropTable(
                name: "TravelEvents");

            migrationBuilder.DropTable(
                name: "TravelPlanBookings");

            migrationBuilder.DropTable(
                name: "ServiceTicketAllocations");

            migrationBuilder.DropTable(
                name: "EquipmentManufacturers");

            migrationBuilder.DropTable(
                name: "SystemsActivityLogs");

            migrationBuilder.DropTable(
                name: "SystemsPages");

            migrationBuilder.DropTable(
                name: "SystemsNotificationTypes");

            migrationBuilder.DropTable(
                name: "JobCardCategories");

            migrationBuilder.DropTable(
                name: "JobCardClasses");

            migrationBuilder.DropTable(
                name: "JobCardGenres");

            migrationBuilder.DropTable(
                name: "JobCardGroups");

            migrationBuilder.DropTable(
                name: "JobCardPriorityLevels");

            migrationBuilder.DropTable(
                name: "JobCardStatuses");

            migrationBuilder.DropTable(
                name: "JobCardTypes");

            migrationBuilder.DropTable(
                name: "ServiceProjects");

            migrationBuilder.DropTable(
                name: "TravelPlans");

            migrationBuilder.DropTable(
                name: "ServiceDeskMembers");

            migrationBuilder.DropTable(
                name: "ServiceTickets");

            migrationBuilder.DropTable(
                name: "SystemsModules");

            migrationBuilder.DropTable(
                name: "ServiceDesks");

            migrationBuilder.DropTable(
                name: "ServiceOfficerProfiles");

            migrationBuilder.DropTable(
                name: "ServiceTicketCategories");

            migrationBuilder.DropTable(
                name: "ServiceTicketPriorityLevels");

            migrationBuilder.DropTable(
                name: "ServiceTicketStatuses");

            migrationBuilder.DropTable(
                name: "ServiceOfficerDesignations");

            migrationBuilder.DropTable(
                name: "SystemsUsers");

            migrationBuilder.DropTable(
                name: "SystemsBusinessProfiles");

            migrationBuilder.DropTable(
                name: "SystemsContactDetails");

            migrationBuilder.DropTable(
                name: "SystemsCities");

            migrationBuilder.DropTable(
                name: "SystemsCountries");

            migrationBuilder.DropTable(
                name: "SystemsCurrencies");
        }
    }
}
