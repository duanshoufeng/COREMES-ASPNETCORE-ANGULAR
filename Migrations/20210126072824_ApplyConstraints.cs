using Microsoft.EntityFrameworkCore.Migrations;

namespace COREMES.Migrations
{
    public partial class ApplyConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "model",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "make",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Model",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Make",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

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
    }
}
