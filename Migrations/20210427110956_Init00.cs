using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebFormacion.Migrations
{
    public partial class Init00 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alumno",
                columns: table => new
                {
                    AlumnoID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoPostal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumno", x => x.AlumnoID);
                });

            migrationBuilder.CreateTable(
                name: "Contacto",
                columns: table => new
                {
                    ContactoID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Puesto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacto", x => x.ContactoID);
                });

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    CursoID = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    NombreCurso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescripcionCurso = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.CursoID);
                });

            migrationBuilder.CreateTable(
                name: "Entidad",
                columns: table => new
                {
                    EntidadID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RazonSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoPostal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entidad", x => x.EntidadID);
                });

            migrationBuilder.CreateTable(
                name: "HistorialContactos",
                columns: table => new
                {
                    HistorialID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlumnoID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ContactoID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CursoID = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Medio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mensaje = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialContactos", x => x.HistorialID);
                    table.ForeignKey(
                        name: "FK_HistorialContactos_Alumno_AlumnoID",
                        column: x => x.AlumnoID,
                        principalTable: "Alumno",
                        principalColumn: "AlumnoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistorialContactos_Contacto_ContactoID",
                        column: x => x.ContactoID,
                        principalTable: "Contacto",
                        principalColumn: "ContactoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistorialContactos_Curso_CursoID",
                        column: x => x.CursoID,
                        principalTable: "Curso",
                        principalColumn: "CursoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CursoEntidad",
                columns: table => new
                {
                    EntidadID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CursoID = table.Column<string>(type: "nvarchar(15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoEntidad", x => new { x.EntidadID, x.CursoID });
                    table.ForeignKey(
                        name: "FK_CursoEntidad_Curso_CursoID",
                        column: x => x.CursoID,
                        principalTable: "Curso",
                        principalColumn: "CursoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CursoEntidad_Entidad_EntidadID",
                        column: x => x.EntidadID,
                        principalTable: "Entidad",
                        principalColumn: "EntidadID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntidadContacto",
                columns: table => new
                {
                    EntidadID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ContactoID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntidadContacto", x => new { x.EntidadID, x.ContactoID });
                    table.ForeignKey(
                        name: "FK_EntidadContacto_Contacto_ContactoID",
                        column: x => x.ContactoID,
                        principalTable: "Contacto",
                        principalColumn: "ContactoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntidadContacto_Entidad_EntidadID",
                        column: x => x.EntidadID,
                        principalTable: "Entidad",
                        principalColumn: "EntidadID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CursoEntidad_CursoID",
                table: "CursoEntidad",
                column: "CursoID");

            migrationBuilder.CreateIndex(
                name: "IX_EntidadContacto_ContactoID",
                table: "EntidadContacto",
                column: "ContactoID");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialContactos_AlumnoID",
                table: "HistorialContactos",
                column: "AlumnoID");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialContactos_ContactoID",
                table: "HistorialContactos",
                column: "ContactoID");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialContactos_CursoID",
                table: "HistorialContactos",
                column: "CursoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CursoEntidad");

            migrationBuilder.DropTable(
                name: "EntidadContacto");

            migrationBuilder.DropTable(
                name: "HistorialContactos");

            migrationBuilder.DropTable(
                name: "Entidad");

            migrationBuilder.DropTable(
                name: "Alumno");

            migrationBuilder.DropTable(
                name: "Contacto");

            migrationBuilder.DropTable(
                name: "Curso");
        }
    }
}
