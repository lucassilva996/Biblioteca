using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteca.Migrations
{
    public partial class atualizandorequiredfoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Foto",
                table: "Livros",
                type: "TEXT",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 300);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Foto",
                table: "Livros",
                type: "TEXT",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 300,
                oldNullable: true);
        }
    }
}
