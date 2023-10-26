using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InnerBalance.API.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class ModelChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_YogaClasses_AspNetUsers_TeacherId",
                table: "YogaClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_YogaClasses_Rooms_RoomId",
                table: "YogaClasses");

            migrationBuilder.AlterColumn<string>(
                name: "TeacherId",
                table: "YogaClasses",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "YogaClasses",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_YogaClasses_AspNetUsers_TeacherId",
                table: "YogaClasses",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_YogaClasses_Rooms_RoomId",
                table: "YogaClasses",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_YogaClasses_AspNetUsers_TeacherId",
                table: "YogaClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_YogaClasses_Rooms_RoomId",
                table: "YogaClasses");

            migrationBuilder.AlterColumn<string>(
                name: "TeacherId",
                table: "YogaClasses",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "YogaClasses",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_YogaClasses_AspNetUsers_TeacherId",
                table: "YogaClasses",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_YogaClasses_Rooms_RoomId",
                table: "YogaClasses",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
