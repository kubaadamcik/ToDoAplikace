using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoAplikace.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoTask_AspNetUsers_UserId",
                table: "ToDoTask");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ToDoTask",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoTask_AspNetUsers_UserId",
                table: "ToDoTask",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoTask_AspNetUsers_UserId",
                table: "ToDoTask");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ToDoTask",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoTask_AspNetUsers_UserId",
                table: "ToDoTask",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
