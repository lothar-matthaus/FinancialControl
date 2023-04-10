using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial.Control.Infra.Data.Migrations
{
    public partial class correcao_adicao_valor_default_colunar_de_data_tabela_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "timestamp",
                table: "User",
                newName: "UpdateDate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "User",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "User",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "User",
                newName: "timestamp");

            migrationBuilder.AlterColumn<DateTime>(
                name: "timestamp",
                table: "User",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");
        }
    }
}
