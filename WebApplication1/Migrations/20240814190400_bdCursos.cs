using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class bdCursos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "disciplina",
                columns: table => new
                {
                    disciplinaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_disciplina", x => x.disciplinaId);
                });

            migrationBuilder.CreateTable(
                name: "instituicao",
                columns: table => new
                {
                    instid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    instnome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    insendereco = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instituicao", x => x.instid);
                });

            migrationBuilder.CreateTable(
                name: "departamento",
                columns: table => new
                {
                    depid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    depnome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    instid = table.Column<int>(type: "int", nullable: false),
                    instituicaoinstid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departamento", x => x.depid);
                    table.ForeignKey(
                        name: "FK_departamento_instituicao_instituicaoinstid",
                        column: x => x.instituicaoinstid,
                        principalTable: "instituicao",
                        principalColumn: "instid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "curso",
                columns: table => new
                {
                    cursoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    depid = table.Column<int>(type: "int", nullable: false),
                    departamentodepid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_curso", x => x.cursoId);
                    table.ForeignKey(
                        name: "FK_curso_departamento_departamentodepid",
                        column: x => x.departamentodepid,
                        principalTable: "departamento",
                        principalColumn: "depid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cursoDisciplina",
                columns: table => new
                {
                    cursoDisciplinaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cursoID = table.Column<int>(type: "int", nullable: false),
                    disciplinaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cursoDisciplina", x => x.cursoDisciplinaID);
                    table.ForeignKey(
                        name: "FK_cursoDisciplina_curso_cursoID",
                        column: x => x.cursoID,
                        principalTable: "curso",
                        principalColumn: "cursoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cursoDisciplina_disciplina_disciplinaID",
                        column: x => x.disciplinaID,
                        principalTable: "disciplina",
                        principalColumn: "disciplinaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_curso_departamentodepid",
                table: "curso",
                column: "departamentodepid");

            migrationBuilder.CreateIndex(
                name: "IX_cursoDisciplina_cursoID",
                table: "cursoDisciplina",
                column: "cursoID");

            migrationBuilder.CreateIndex(
                name: "IX_cursoDisciplina_disciplinaID",
                table: "cursoDisciplina",
                column: "disciplinaID");

            migrationBuilder.CreateIndex(
                name: "IX_departamento_instituicaoinstid",
                table: "departamento",
                column: "instituicaoinstid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cursoDisciplina");

            migrationBuilder.DropTable(
                name: "curso");

            migrationBuilder.DropTable(
                name: "disciplina");

            migrationBuilder.DropTable(
                name: "departamento");

            migrationBuilder.DropTable(
                name: "instituicao");
        }
    }
}
