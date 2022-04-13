using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoListApplication.Domain.Migrations
{
    public partial class addedtodotable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDo_toDoLists_ToDoListId",
                table: "ToDo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToDo",
                table: "ToDo");

            migrationBuilder.RenameTable(
                name: "ToDo",
                newName: "toDo");

            migrationBuilder.RenameIndex(
                name: "IX_ToDo_ToDoListId",
                table: "toDo",
                newName: "IX_toDo_ToDoListId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_toDo",
                table: "toDo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_toDo_toDoLists_ToDoListId",
                table: "toDo",
                column: "ToDoListId",
                principalTable: "toDoLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_toDo_toDoLists_ToDoListId",
                table: "toDo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_toDo",
                table: "toDo");

            migrationBuilder.RenameTable(
                name: "toDo",
                newName: "ToDo");

            migrationBuilder.RenameIndex(
                name: "IX_toDo_ToDoListId",
                table: "ToDo",
                newName: "IX_ToDo_ToDoListId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToDo",
                table: "ToDo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDo_toDoLists_ToDoListId",
                table: "ToDo",
                column: "ToDoListId",
                principalTable: "toDoLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
