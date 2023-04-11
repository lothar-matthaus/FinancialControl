using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial.Control.Infra.Data.Migrations
{
    public partial class alteracao_tipo_coluna_flag_tabela_card : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Flag",
                table: "Card",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Flag",
                table: "Card",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }
    }
}
