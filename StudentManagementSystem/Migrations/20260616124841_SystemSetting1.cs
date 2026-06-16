using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class SystemSetting1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultCurrency",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "EnableEmailNotifications",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "EnableSmsNotifications",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "RegistrarName",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "SchoolCode",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "SchoolResumptionHour",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "SchoolStampUrl",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "TimeZone",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "VicePrincipalName",
                table: "SystemSettings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DefaultCurrency",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "EnableEmailNotifications",
                table: "SystemSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EnableSmsNotifications",
                table: "SystemSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "RegistrarName",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SchoolCode",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SchoolResumptionHour",
                table: "SystemSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SchoolStampUrl",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TimeZone",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VicePrincipalName",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
