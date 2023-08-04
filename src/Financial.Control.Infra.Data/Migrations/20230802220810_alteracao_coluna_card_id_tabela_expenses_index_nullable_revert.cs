using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial.Control.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class alteracao_coluna_card_id_tabela_expenses_index_nullable_revert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_Card_CardId",
                table: "Expense");

            migrationBuilder.AlterColumn<long>(
                name: "CardId",
                table: "Expense",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

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

            migrationBuilder.AlterColumn<long>(
                name: "CardId",
                table: "Expense",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_Card_CardId",
                table: "Expense",
                column: "CardId",
                principalTable: "Card",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
