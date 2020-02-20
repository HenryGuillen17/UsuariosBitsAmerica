using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.SqlServer.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ciudades",
                columns: table => new
                {
                    CiudadId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudades", x => x.CiudadId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PrimerNombre = table.Column<string>(maxLength: 50, nullable: false),
                    SegundoNombre = table.Column<string>(maxLength: 50, nullable: true),
                    PrimerApellido = table.Column<string>(maxLength: 50, nullable: false),
                    SegundoApellido = table.Column<string>(maxLength: 50, nullable: true),
                    TipoDocumento = table.Column<byte>(nullable: false),
                    NumeroDocumento = table.Column<string>(maxLength: 20, nullable: false),
                    CorreoElectronico = table.Column<string>(maxLength: 50, nullable: false),
                    DireccionResidencia = table.Column<string>(maxLength: 200, nullable: false),
                    CiudadId = table.Column<int>(nullable: false),
                    Telefono = table.Column<string>(maxLength: 25, nullable: true),
                    Celular = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuarios_Ciudades_CiudadId",
                        column: x => x.CiudadId,
                        principalTable: "Ciudades",
                        principalColumn: "CiudadId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CiudadId",
                table: "Usuarios",
                column: "CiudadId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Ciudades");
        }
    }
}
