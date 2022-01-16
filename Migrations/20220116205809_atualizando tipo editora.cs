using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteca.Migrations
{
    public partial class atualizandotipoeditora : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Editora",
                table: "Livros",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldMaxLength: 200);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Editora",
                table: "Livros",
                type: "INTEGER",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200);
        }
    }
}
