using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InnerBalance.API.Migrations
{
    /// <inheritdoc />
    public partial class DifferentUserTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_YogaClasses_YogaClassId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_YogaClassId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "YogaClassId",
                table: "AspNetUsers",
                newName: "YearsOfExperience");

            migrationBuilder.AddColumn<string>(
                name: "Certification",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Membership",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "YogaClassYogaStudent",
                columns: table => new
                {
                    ClassesParticipatingId = table.Column<int>(type: "integer", nullable: false),
                    ParticipantsId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YogaClassYogaStudent", x => new { x.ClassesParticipatingId, x.ParticipantsId });
                    table.ForeignKey(
                        name: "FK_YogaClassYogaStudent_AspNetUsers_ParticipantsId",
                        column: x => x.ParticipantsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_YogaClassYogaStudent_YogaClasses_ClassesParticipatingId",
                        column: x => x.ClassesParticipatingId,
                        principalTable: "YogaClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_YogaClassYogaStudent_ParticipantsId",
                table: "YogaClassYogaStudent",
                column: "ParticipantsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "YogaClassYogaStudent");

            migrationBuilder.DropColumn(
                name: "Certification",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Membership",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "YearsOfExperience",
                table: "AspNetUsers",
                newName: "YogaClassId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_YogaClassId",
                table: "AspNetUsers",
                column: "YogaClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_YogaClasses_YogaClassId",
                table: "AspNetUsers",
                column: "YogaClassId",
                principalTable: "YogaClasses",
                principalColumn: "Id");
        }
    }
}
