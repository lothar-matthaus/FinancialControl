using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial.Control.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class alteraçãotabelacardcolunascardnumbercardtype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CardType",
                table: "Card",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "CardNumber",
                table: "Card",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "CardInvoiceDay",
                table: "Card",
                newName: "InvoiceDay");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Card",
                newName: "CardType");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Card",
                newName: "CardNumber");

            migrationBuilder.RenameColumn(
                name: "InvoiceDay",
                table: "Card",
                newName: "CardInvoiceDay");
        }
    }
}
