using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoListApplication.Domain.Migrations
{
    public partial class added_TODOListId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_toDo_toDoLists_ToDoListId",
                table: "toDo");

            migrationBuilder.AlterColumn<int>(
                name: "ToDoListId",
                table: "toDo",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_toDo_toDoLists_ToDoListId",
                table: "toDo",
                column: "ToDoListId",
                principalTable: "toDoLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_toDo_toDoLists_ToDoListId",
                table: "toDo");

            migrationBuilder.AlterColumn<int>(
                name: "ToDoListId",
                table: "toDo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_toDo_toDoLists_ToDoListId",
                table: "toDo",
                column: "ToDoListId",
                principalTable: "toDoLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
