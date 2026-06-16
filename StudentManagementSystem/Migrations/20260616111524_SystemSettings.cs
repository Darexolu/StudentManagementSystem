using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class SystemSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SystemSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SchoolName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolWebsite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrincipalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolMotto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentSession = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentTerm = table.Column<int>(type: "int", nullable: false),
                    ReportCardFooter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResultSignatureName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResultSignatureTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResultPublishingEnabled = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SchoolLogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VicePrincipalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrarName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolStampUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultCurrency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeZone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolResumptionHour = table.Column<int>(type: "int", nullable: false),
                    EnableSmsNotifications = table.Column<bool>(type: "bit", nullable: false),
                    EnableEmailNotifications = table.Column<bool>(type: "bit", nullable: false),
                    SchoolCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemSettings", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SystemSettings");
        }
    }
}
