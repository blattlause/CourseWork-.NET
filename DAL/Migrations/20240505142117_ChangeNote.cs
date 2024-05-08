using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdVisit",
                table: "Note",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Note_IdVisit",
                table: "Note",
                column: "IdVisit");

            migrationBuilder.AddForeignKey(
                name: "FK_Note_Visit_IdVisit",
                table: "Note",
                column: "IdVisit",
                principalTable: "Visit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Note_Visit_IdVisit",
                table: "Note");

            migrationBuilder.DropIndex(
                name: "IX_Note_IdVisit",
                table: "Note");

            migrationBuilder.DropColumn(
                name: "IdVisit",
                table: "Note");
        }
    }
}
