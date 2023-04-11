using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial.Control.Infra.Data.Migrations
{
    public partial class alteração_nome_tabela_revenues_para_singular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Revenues_User_UserId",
                table: "Revenues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Revenues",
                table: "Revenues");

            migrationBuilder.RenameTable(
                name: "Revenues",
                newName: "Revenue");

            migrationBuilder.RenameIndex(
                name: "IX_Revenues_UserId",
                table: "Revenue",
                newName: "IX_Revenue_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Revenue",
                table: "Revenue",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Revenue_User_UserId",
                table: "Revenue",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Revenue_User_UserId",
                table: "Revenue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Revenue",
                table: "Revenue");

            migrationBuilder.RenameTable(
                name: "Revenue",
                newName: "Revenues");

            migrationBuilder.RenameIndex(
                name: "IX_Revenue_UserId",
                table: "Revenues",
                newName: "IX_Revenues_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Revenues",
                table: "Revenues",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Revenues_User_UserId",
                table: "Revenues",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
