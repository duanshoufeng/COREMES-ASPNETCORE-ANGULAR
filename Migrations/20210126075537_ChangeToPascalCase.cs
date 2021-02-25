using Microsoft.EntityFrameworkCore.Migrations;

namespace COREMES.Migrations
{
    public partial class ChangeToPascalCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_model_make_MakeId",
                table: "model");

            migrationBuilder.DropPrimaryKey(
                name: "PK_model",
                table: "model");

            migrationBuilder.DropPrimaryKey(
                name: "PK_make",
                table: "make");

            migrationBuilder.RenameTable(
                name: "model",
                newName: "Model");

            migrationBuilder.RenameTable(
                name: "make",
                newName: "Make");

            migrationBuilder.RenameIndex(
                name: "IX_model_MakeId",
                table: "Model",
                newName: "IX_Model_MakeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Model",
                table: "Model",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Make",
                table: "Make",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Model_Make_MakeId",
                table: "Model",
                column: "MakeId",
                principalTable: "Make",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Model_Make_MakeId",
                table: "Model");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Model",
                table: "Model");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Make",
                table: "Make");

            migrationBuilder.RenameTable(
                name: "Model",
                newName: "model");

            migrationBuilder.RenameTable(
                name: "Make",
                newName: "make");

            migrationBuilder.RenameIndex(
                name: "IX_Model_MakeId",
                table: "model",
                newName: "IX_model_MakeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_model",
                table: "model",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_make",
                table: "make",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_model_make_MakeId",
                table: "model",
                column: "MakeId",
                principalTable: "make",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
