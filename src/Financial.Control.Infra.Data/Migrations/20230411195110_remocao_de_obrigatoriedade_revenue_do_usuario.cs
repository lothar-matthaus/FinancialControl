using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial.Control.Infra.Data.Migrations
{
    public partial class remocao_de_obrigatoriedade_revenue_do_usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Revenues_RevenueId",
                table: "User");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Revenues_RevenueId",
                table: "User",
                column: "RevenueId",
                principalTable: "Revenues",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Revenues_RevenueId",
                table: "User");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Revenues_RevenueId",
                table: "User",
                column: "RevenueId",
                principalTable: "Revenues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
