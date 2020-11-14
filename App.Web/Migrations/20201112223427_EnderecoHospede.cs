using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Web.Migrations
{
    public partial class EnderecoHospede : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hospedes_Enderecos_EnderecoId",
                table: "Hospedes");

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoId",
                table: "Hospedes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Hospedes_Enderecos_EnderecoId",
                table: "Hospedes",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "EnderecoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hospedes_Enderecos_EnderecoId",
                table: "Hospedes");

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoId",
                table: "Hospedes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Hospedes_Enderecos_EnderecoId",
                table: "Hospedes",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "EnderecoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
