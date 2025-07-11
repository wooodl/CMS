using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComprehensiveManagementSystem.Migrations
{
    public partial class AddPersonnelTraining : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonnelTrainings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonnelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainingName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TrainingType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TrainingOrganization = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TrainingLocation = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    TrainingDays = table.Column<int>(type: "int", nullable: false),
                    TrainingContent = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    TrainingResult = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HasCertificate = table.Column<bool>(type: "bit", nullable: false),
                    CertificateName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CertificateNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonnelTrainings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonnelTrainings_PersonnelBasicInfo_PersonnelId",
                        column: x => x.PersonnelId,
                        principalTable: "PersonnelBasicInfo",
                        principalColumn: "PersonnelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonnelTrainings_PersonnelId",
                table: "PersonnelTrainings",
                column: "PersonnelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonnelTrainings");
        }
    }
}
