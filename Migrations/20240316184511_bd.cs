using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace systemPV.Migrations
{
    /// <inheritdoc />
    public partial class bd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DbCliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbCliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbVianda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbVianda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbVianda_DbCliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "DbCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbVianda_IdCliente",
                table: "DbVianda",
                column: "IdCliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbVianda");

            migrationBuilder.DropTable(
                name: "DbCliente");
        }
    }
}
