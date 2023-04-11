using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial.Control.Infra.Data.Migrations
{
    public partial class alteração_na_regra_de_usuario_e_revenues_muitos_para_um : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Revenues_RevenueId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_RevenueId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "RevenueId",
                table: "User");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Revenues",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Revenues_UserId",
                table: "Revenues",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Revenues_User_UserId",
                table: "Revenues",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Revenues_User_UserId",
                table: "Revenues");

            migrationBuilder.DropIndex(
                name: "IX_Revenues_UserId",
                table: "Revenues");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Revenues");

            migrationBuilder.AddColumn<long>(
                name: "RevenueId",
                table: "User",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_RevenueId",
                table: "User",
                column: "RevenueId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Revenues_RevenueId",
                table: "User",
                column: "RevenueId",
                principalTable: "Revenues",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
