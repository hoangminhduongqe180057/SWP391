using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentsManagement.Migrations
{
    /// <inheritdoc />
    public partial class StatusBookIssuance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "BookIssuances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BookIssuances_StatusId",
                table: "BookIssuances",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookIssuances_SystemCodeDetails_StatusId",
                table: "BookIssuances",
                column: "StatusId",
                principalTable: "SystemCodeDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookIssuances_SystemCodeDetails_StatusId",
                table: "BookIssuances");

            migrationBuilder.DropIndex(
                name: "IX_BookIssuances_StatusId",
                table: "BookIssuances");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "BookIssuances");
        }
    }
}
