using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial.Control.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class atualizacao_coluna_installment_tabela_expense : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Instalment",
                table: "Expense",
                newName: "Installment");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Installment",
                table: "Expense",
                newName: "Instalment");
        }
    }
}
