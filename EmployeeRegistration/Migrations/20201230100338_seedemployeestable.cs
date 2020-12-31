using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeRegistration.Migrations
{
    public partial class seedemployeestable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Answer", "Email", "FirstName", "Genders", "LastName", "Password", "Phone", "Question" },
                values: new object[] { 1, "Landon", "Pat.Collumn@abc.com", "Pat", 0, "Collumn", "abcd@123", 9923128577L, "In which city you boarn?" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Answer", "Email", "FirstName", "Genders", "LastName", "Password", "Phone", "Question" },
                values: new object[] { 2, "MVM", "Colin.Bell@abc.com", "Colin", 0, "Bell", "abcd@456", 9923128578L, "High school name" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Answer", "Email", "FirstName", "Genders", "LastName", "Password", "Phone", "Question" },
                values: new object[] { 3, "boxer", "Mery.John@abc.com", "Mery", 1, "John", "abcd@456789", 9923128580L, "Your pet name" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
