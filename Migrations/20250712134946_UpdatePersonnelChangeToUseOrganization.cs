using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComprehensiveManagementSystem.Migrations
{
    public partial class UpdatePersonnelChangeToUseOrganization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonnelChange_Departments_NewDepartmentId",
                table: "PersonnelChange");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonnelChange_Departments_PreviousDepartmentId",
                table: "PersonnelChange");

            migrationBuilder.RenameColumn(
                name: "PreviousDepartmentId",
                table: "PersonnelChange",
                newName: "PreviousOrganizationId");

            migrationBuilder.RenameColumn(
                name: "NewDepartmentId",
                table: "PersonnelChange",
                newName: "NewOrganizationId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonnelChange_PreviousDepartmentId",
                table: "PersonnelChange",
                newName: "IX_PersonnelChange_PreviousOrganizationId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonnelChange_NewDepartmentId",
                table: "PersonnelChange",
                newName: "IX_PersonnelChange_NewOrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonnelChange_Organizations_NewOrganizationId",
                table: "PersonnelChange",
                column: "NewOrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonnelChange_Organizations_PreviousOrganizationId",
                table: "PersonnelChange",
                column: "PreviousOrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonnelChange_Organizations_NewOrganizationId",
                table: "PersonnelChange");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonnelChange_Organizations_PreviousOrganizationId",
                table: "PersonnelChange");

            migrationBuilder.RenameColumn(
                name: "PreviousOrganizationId",
                table: "PersonnelChange",
                newName: "PreviousDepartmentId");

            migrationBuilder.RenameColumn(
                name: "NewOrganizationId",
                table: "PersonnelChange",
                newName: "NewDepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonnelChange_PreviousOrganizationId",
                table: "PersonnelChange",
                newName: "IX_PersonnelChange_PreviousDepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonnelChange_NewOrganizationId",
                table: "PersonnelChange",
                newName: "IX_PersonnelChange_NewDepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonnelChange_Departments_NewDepartmentId",
                table: "PersonnelChange",
                column: "NewDepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonnelChange_Departments_PreviousDepartmentId",
                table: "PersonnelChange",
                column: "PreviousDepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
