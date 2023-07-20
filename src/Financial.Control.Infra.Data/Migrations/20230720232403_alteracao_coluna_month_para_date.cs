using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial.Control.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class alteracao_coluna_month_para_date : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Month",
                table: "Revenue");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Revenue",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Revenue");

            migrationBuilder.AddColumn<string>(
                name: "Month",
                table: "Revenue",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
