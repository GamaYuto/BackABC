using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_1.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numeroidentificacion = table.Column<int>(type: "int", nullable: false),
                    Primernombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Segundonombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Primerapellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Segundoapellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fechanacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valorestimado = table.Column<int>(type: "int", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
