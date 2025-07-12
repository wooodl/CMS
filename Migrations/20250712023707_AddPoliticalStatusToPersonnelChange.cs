using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComprehensiveManagementSystem.Migrations
{
    public partial class AddPoliticalStatusToPersonnelChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NewPoliticalStatus",
                table: "PersonnelChange",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreviousPoliticalStatus",
                table: "PersonnelChange",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewPoliticalStatus",
                table: "PersonnelChange");

            migrationBuilder.DropColumn(
                name: "PreviousPoliticalStatus",
                table: "PersonnelChange");
        }
    }
}
