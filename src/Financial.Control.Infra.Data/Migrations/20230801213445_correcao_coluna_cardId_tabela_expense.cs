using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial.Control.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class correcao_coluna_cardId_tabela_expense : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_Card_CardId",
                table: "Expense");

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_Card_CardId",
                table: "Expense",
                column: "CardId",
                principalTable: "Card",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_Card_CardId",
                table: "Expense");

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_Card_CardId",
                table: "Expense",
                column: "CardId",
                principalTable: "Card",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
