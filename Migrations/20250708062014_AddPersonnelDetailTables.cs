using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComprehensiveManagementSystem.Migrations
{
    public partial class AddPersonnelDetailTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonnelBasicInfo",
                columns: table => new
                {
                    PersonnelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NativePlace = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Education = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IdCard = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PoliticalStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartyJoinDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MaritalStatus = table.Column<int>(type: "int", nullable: false),
                    PersonnelCategory = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Grade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastGradeAdjustmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TreatmentLevel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastTreatmentAdjustmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    DepartmentJoinDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Duty = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DutyLevel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RankAssessmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastAssessmentResult = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ExcellentCount = table.Column<int>(type: "int", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HomeAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    WorkAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonnelBasicInfo", x => x.PersonnelId);
                    table.ForeignKey(
                        name: "FK_PersonnelBasicInfo_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PersonnelActivityRecord",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonnelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActivityPlace = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ActivityName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ParticipantRole = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ActivityType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OrganizingUnit = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ActivityDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Performance = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Achievement = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonnelActivityRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonnelActivityRecord_PersonnelBasicInfo_PersonnelId",
                        column: x => x.PersonnelId,
                        principalTable: "PersonnelBasicInfo",
                        principalColumn: "PersonnelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonnelFamilyMember",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonnelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RelationType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    NativePlace = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Nation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PoliticalStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IdCard = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    WorkUnit = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonnelFamilyMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonnelFamilyMember_PersonnelBasicInfo_PersonnelId",
                        column: x => x.PersonnelId,
                        principalTable: "PersonnelBasicInfo",
                        principalColumn: "PersonnelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonnelHistory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonnelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WorkPlace = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WorkDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonnelHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonnelHistory_PersonnelBasicInfo_PersonnelId",
                        column: x => x.PersonnelId,
                        principalTable: "PersonnelBasicInfo",
                        principalColumn: "PersonnelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonnelRewardPunishment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonnelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecordDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DecisionUnit = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DecisionDocument = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonnelRewardPunishment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonnelRewardPunishment_PersonnelBasicInfo_PersonnelId",
                        column: x => x.PersonnelId,
                        principalTable: "PersonnelBasicInfo",
                        principalColumn: "PersonnelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonnelSpouse",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonnelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NativePlace = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Education = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MarriageDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PoliticalStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsSameType = table.Column<bool>(type: "bit", nullable: false),
                    IsLocal = table.Column<bool>(type: "bit", nullable: false),
                    LocalArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WorkUnit = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IdCard = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    WorkId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonnelSpouse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonnelSpouse_PersonnelBasicInfo_PersonnelId",
                        column: x => x.PersonnelId,
                        principalTable: "PersonnelBasicInfo",
                        principalColumn: "PersonnelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonnelWorkRecord",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonnelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkPlace = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    WorkContent = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    WorkType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Participants = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    WorkResult = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonnelWorkRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonnelWorkRecord_PersonnelBasicInfo_PersonnelId",
                        column: x => x.PersonnelId,
                        principalTable: "PersonnelBasicInfo",
                        principalColumn: "PersonnelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonnelActivityRecord_PersonnelId",
                table: "PersonnelActivityRecord",
                column: "PersonnelId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonnelBasicInfo_DepartmentId",
                table: "PersonnelBasicInfo",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonnelBasicInfo_IdCard",
                table: "PersonnelBasicInfo",
                column: "IdCard",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonnelFamilyMember_PersonnelId",
                table: "PersonnelFamilyMember",
                column: "PersonnelId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonnelHistory_PersonnelId",
                table: "PersonnelHistory",
                column: "PersonnelId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonnelRewardPunishment_PersonnelId",
                table: "PersonnelRewardPunishment",
                column: "PersonnelId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonnelSpouse_PersonnelId",
                table: "PersonnelSpouse",
                column: "PersonnelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonnelWorkRecord_PersonnelId",
                table: "PersonnelWorkRecord",
                column: "PersonnelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonnelActivityRecord");

            migrationBuilder.DropTable(
                name: "PersonnelFamilyMember");

            migrationBuilder.DropTable(
                name: "PersonnelHistory");

            migrationBuilder.DropTable(
                name: "PersonnelRewardPunishment");

            migrationBuilder.DropTable(
                name: "PersonnelSpouse");

            migrationBuilder.DropTable(
                name: "PersonnelWorkRecord");

            migrationBuilder.DropTable(
                name: "PersonnelBasicInfo");
        }
    }
}
