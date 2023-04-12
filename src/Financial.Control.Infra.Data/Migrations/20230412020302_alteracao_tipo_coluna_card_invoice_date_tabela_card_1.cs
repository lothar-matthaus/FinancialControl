using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial.Control.Infra.Data.Migrations
{
    public partial class alteracao_tipo_coluna_card_invoice_date_tabela_card_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cardinvoiceday",
                table: "Card",
                newName: "CardInvoiceDay");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CardInvoiceDay",
                table: "Card",
                newName: "cardinvoiceday");
        }
    }
}
