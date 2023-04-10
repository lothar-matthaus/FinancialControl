using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial.Control.Infra.Data.Migrations
{
    public partial class alteracao_default_value_tabela_user_colunas_de_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "User",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 7, 16, 25, 33, 533, DateTimeKind.Local).AddTicks(9620),
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "User",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 7, 16, 25, 33, 533, DateTimeKind.Local).AddTicks(7716),
                oldClrType: typeof(DateTime),
                oldType: "timestamp");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "User",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 4, 7, 16, 25, 33, 533, DateTimeKind.Local).AddTicks(9620));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "User",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 4, 7, 16, 25, 33, 533, DateTimeKind.Local).AddTicks(7716));
        }
    }
}
