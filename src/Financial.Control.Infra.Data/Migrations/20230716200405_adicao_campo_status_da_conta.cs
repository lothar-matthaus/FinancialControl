using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial.Control.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class adicao_campo_status_da_conta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEnable",
                table: "Account");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Account",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Account");

            migrationBuilder.AddColumn<bool>(
                name: "IsEnable",
                table: "Account",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
