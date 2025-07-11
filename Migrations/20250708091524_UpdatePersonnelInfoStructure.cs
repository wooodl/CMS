using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComprehensiveManagementSystem.Migrations
{
    public partial class UpdatePersonnelInfoStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartmentJoinDate",
                table: "PersonnelBasicInfo");

            migrationBuilder.DropColumn(
                name: "ExcellentCount",
                table: "PersonnelBasicInfo");

            migrationBuilder.DropColumn(
                name: "HomeAddress",
                table: "PersonnelBasicInfo");

            migrationBuilder.DropColumn(
                name: "LastGradeAdjustmentDate",
                table: "PersonnelBasicInfo");

            migrationBuilder.DropColumn(
                name: "LastTreatmentAdjustmentDate",
                table: "PersonnelBasicInfo");

            migrationBuilder.DropColumn(
                name: "PartyJoinDate",
                table: "PersonnelBasicInfo");

            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "PersonnelBasicInfo");

            migrationBuilder.DropColumn(
                name: "RankAssessmentDate",
                table: "PersonnelBasicInfo");

            migrationBuilder.DropColumn(
                name: "WorkAddress",
                table: "PersonnelBasicInfo");

            migrationBuilder.RenameColumn(
                name: "TreatmentLevel",
                table: "PersonnelBasicInfo",
                newName: "WorkId");

            migrationBuilder.RenameColumn(
                name: "LastAssessmentResult",
                table: "PersonnelBasicInfo",
                newName: "Nation");

            migrationBuilder.CreateTable(
                name: "PersonnelSupplementaryInfo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonnelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PartyJoinDate = table.Column<DateTime>(type: "date", nullable: true),
                    LastGradeAdjustmentDate = table.Column<DateTime>(type: "date", nullable: true),
                    TreatmentLevel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastTreatmentAdjustmentDate = table.Column<DateTime>(type: "date", nullable: true),
                    DepartmentJoinDate = table.Column<DateTime>(type: "date", nullable: true),
                    RankAssessmentDate = table.Column<DateTime>(type: "date", nullable: true),
                    LastAssessmentResult = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ExcellentCount = table.Column<int>(type: "int", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    HomeAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    WorkAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonnelSupplementaryInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonnelSupplementaryInfo_PersonnelBasicInfo_PersonnelId",
                        column: x => x.PersonnelId,
                        principalTable: "PersonnelBasicInfo",
                        principalColumn: "PersonnelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonnelSupplementaryInfo_PersonnelId",
                table: "PersonnelSupplementaryInfo",
                column: "PersonnelId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonnelSupplementaryInfo");

            migrationBuilder.RenameColumn(
                name: "WorkId",
                table: "PersonnelBasicInfo",
                newName: "TreatmentLevel");

            migrationBuilder.RenameColumn(
                name: "Nation",
                table: "PersonnelBasicInfo",
                newName: "LastAssessmentResult");

            migrationBuilder.AddColumn<DateTime>(
                name: "DepartmentJoinDate",
                table: "PersonnelBasicInfo",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExcellentCount",
                table: "PersonnelBasicInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "HomeAddress",
                table: "PersonnelBasicInfo",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastGradeAdjustmentDate",
                table: "PersonnelBasicInfo",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastTreatmentAdjustmentDate",
                table: "PersonnelBasicInfo",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PartyJoinDate",
                table: "PersonnelBasicInfo",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "PersonnelBasicInfo",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RankAssessmentDate",
                table: "PersonnelBasicInfo",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkAddress",
                table: "PersonnelBasicInfo",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }
    }
}
