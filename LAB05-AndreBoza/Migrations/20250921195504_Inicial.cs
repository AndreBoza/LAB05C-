using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB05_AndreBoza.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.IdCategoria);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    IdCurso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Creditos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.IdCurso);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    IdEstudiante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Correo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.IdEstudiante);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Profesores",
                columns: table => new
                {
                    IdProfesor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Especialidad = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Correo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesores", x => x.IdProfesor);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    IdMateria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdCurso = table.Column<int>(type: "int", nullable: true),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdCursoNavigationIdCurso = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.IdMateria);
                    table.ForeignKey(
                        name: "FK_Materias_Cursos_IdCursoNavigationIdCurso",
                        column: x => x.IdCursoNavigationIdCurso,
                        principalTable: "Cursos",
                        principalColumn: "IdCurso");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Asistencias",
                columns: table => new
                {
                    IdAsistencia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdEstudiante = table.Column<int>(type: "int", nullable: true),
                    IdCurso = table.Column<int>(type: "int", nullable: true),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: true),
                    Estado = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdCursoNavigationIdCurso = table.Column<int>(type: "int", nullable: true),
                    IdEstudianteNavigationIdEstudiante = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asistencias", x => x.IdAsistencia);
                    table.ForeignKey(
                        name: "FK_Asistencias_Cursos_IdCursoNavigationIdCurso",
                        column: x => x.IdCursoNavigationIdCurso,
                        principalTable: "Cursos",
                        principalColumn: "IdCurso");
                    table.ForeignKey(
                        name: "FK_Asistencias_Estudiantes_IdEstudianteNavigationIdEstudiante",
                        column: x => x.IdEstudianteNavigationIdEstudiante,
                        principalTable: "Estudiantes",
                        principalColumn: "IdEstudiante");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Evaluaciones",
                columns: table => new
                {
                    IdEvaluacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdEstudiante = table.Column<int>(type: "int", nullable: true),
                    IdCurso = table.Column<int>(type: "int", nullable: true),
                    Calificacion = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: true),
                    IdCursoNavigationIdCurso = table.Column<int>(type: "int", nullable: true),
                    IdEstudianteNavigationIdEstudiante = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluaciones", x => x.IdEvaluacion);
                    table.ForeignKey(
                        name: "FK_Evaluaciones_Cursos_IdCursoNavigationIdCurso",
                        column: x => x.IdCursoNavigationIdCurso,
                        principalTable: "Cursos",
                        principalColumn: "IdCurso");
                    table.ForeignKey(
                        name: "FK_Evaluaciones_Estudiantes_IdEstudianteNavigationIdEstudiante",
                        column: x => x.IdEstudianteNavigationIdEstudiante,
                        principalTable: "Estudiantes",
                        principalColumn: "IdEstudiante");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Matriculas",
                columns: table => new
                {
                    IdMatricula = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdEstudiante = table.Column<int>(type: "int", nullable: true),
                    IdCurso = table.Column<int>(type: "int", nullable: true),
                    Semestre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdCursoNavigationIdCurso = table.Column<int>(type: "int", nullable: true),
                    IdEstudianteNavigationIdEstudiante = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matriculas", x => x.IdMatricula);
                    table.ForeignKey(
                        name: "FK_Matriculas_Cursos_IdCursoNavigationIdCurso",
                        column: x => x.IdCursoNavigationIdCurso,
                        principalTable: "Cursos",
                        principalColumn: "IdCurso");
                    table.ForeignKey(
                        name: "FK_Matriculas_Estudiantes_IdEstudianteNavigationIdEstudiante",
                        column: x => x.IdEstudianteNavigationIdEstudiante,
                        principalTable: "Estudiantes",
                        principalColumn: "IdEstudiante");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_IdCursoNavigationIdCurso",
                table: "Asistencias",
                column: "IdCursoNavigationIdCurso");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_IdEstudianteNavigationIdEstudiante",
                table: "Asistencias",
                column: "IdEstudianteNavigationIdEstudiante");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluaciones_IdCursoNavigationIdCurso",
                table: "Evaluaciones",
                column: "IdCursoNavigationIdCurso");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluaciones_IdEstudianteNavigationIdEstudiante",
                table: "Evaluaciones",
                column: "IdEstudianteNavigationIdEstudiante");

            migrationBuilder.CreateIndex(
                name: "IX_Materias_IdCursoNavigationIdCurso",
                table: "Materias",
                column: "IdCursoNavigationIdCurso");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_IdCursoNavigationIdCurso",
                table: "Matriculas",
                column: "IdCursoNavigationIdCurso");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_IdEstudianteNavigationIdEstudiante",
                table: "Matriculas",
                column: "IdEstudianteNavigationIdEstudiante");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asistencias");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Evaluaciones");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "Matriculas");

            migrationBuilder.DropTable(
                name: "Profesores");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Estudiantes");
        }
    }
}
