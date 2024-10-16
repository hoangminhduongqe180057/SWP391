using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentsManagement.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBookIssuanceStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookIssuances_SystemCodeDetails_StudentId",
                table: "BookIssuances");

            migrationBuilder.AddForeignKey(
                name: "FK_BookIssuances_Students_StudentId",
                table: "BookIssuances",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookIssuances_Students_StudentId",
                table: "BookIssuances");

            migrationBuilder.AddForeignKey(
                name: "FK_BookIssuances_SystemCodeDetails_StudentId",
                table: "BookIssuances",
                column: "StudentId",
                principalTable: "SystemCodeDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
