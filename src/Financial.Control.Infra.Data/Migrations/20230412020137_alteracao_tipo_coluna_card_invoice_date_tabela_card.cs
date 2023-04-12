using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial.Control.Infra.Data.Migrations
{
    public partial class alteracao_tipo_coluna_card_invoice_date_tabela_card : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CardInvoiceDay",
                table: "Card",
                newName: "cardinvoiceday");

            migrationBuilder.AlterColumn<int>(
                name: "cardinvoiceday",
                table: "Card",
                type: "integer",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cardinvoiceday",
                table: "Card",
                newName: "CardInvoiceDay");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CardInvoiceDay",
                table: "Card",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}
