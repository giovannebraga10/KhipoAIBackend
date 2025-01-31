using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KhipoAI.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoLogicaEPropriedades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "PlanosCotacao",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "PlanosCotacao");
        }
    }
}
