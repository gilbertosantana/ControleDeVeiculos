using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeVeiculos.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyMarca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculo_Marca_MarcaId",
                table: "Veiculo");

            migrationBuilder.AlterColumn<int>(
                name: "MarcaId",
                table: "Veiculo",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculo_Marca_MarcaId",
                table: "Veiculo",
                column: "MarcaId",
                principalTable: "Marca",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculo_Marca_MarcaId",
                table: "Veiculo");

            migrationBuilder.AlterColumn<int>(
                name: "MarcaId",
                table: "Veiculo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculo_Marca_MarcaId",
                table: "Veiculo",
                column: "MarcaId",
                principalTable: "Marca",
                principalColumn: "Id");
        }
    }
}
