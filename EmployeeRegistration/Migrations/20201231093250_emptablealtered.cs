using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeRegistration.Migrations
{
    public partial class emptablealtered : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Genders",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Question",
                table: "Employees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Genders",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Employees",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Question",
                table: "Employees",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Answer", "Password", "Question" },
                values: new object[] { "Landon", "abcd@123", "In which city you boarn?" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Answer", "Password", "Question" },
                values: new object[] { "MVM", "abcd@456", "High school name" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Answer", "Genders", "Password", "Question" },
                values: new object[] { "boxer", 1, "abcd@456789", "Your pet name" });
        }
    }
}
