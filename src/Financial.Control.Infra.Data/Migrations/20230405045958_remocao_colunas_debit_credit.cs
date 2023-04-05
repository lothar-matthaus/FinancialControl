using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial.Control.Infra.Data.Migrations
{
    public partial class remocao_colunas_debit_credit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Credit",
                table: "Card");

            migrationBuilder.DropColumn(
                name: "Debit",
                table: "Card");

            migrationBuilder.RenameColumn(
                name: "Payment_Value",
                table: "Expense",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "Payment_PaymentType",
                table: "Expense",
                newName: "PaymentType");

            migrationBuilder.RenameColumn(
                name: "Payment_Instalment",
                table: "Expense",
                newName: "Instalment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Expense",
                newName: "Payment_Value");

            migrationBuilder.RenameColumn(
                name: "PaymentType",
                table: "Expense",
                newName: "Payment_PaymentType");

            migrationBuilder.RenameColumn(
                name: "Instalment",
                table: "Expense",
                newName: "Payment_Instalment");

            migrationBuilder.AddColumn<string>(
                name: "Credit",
                table: "Card",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Debit",
                table: "Card",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
