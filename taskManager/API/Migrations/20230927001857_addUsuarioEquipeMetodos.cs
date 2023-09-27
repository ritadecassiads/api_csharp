using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class addUsuarioEquipeMetodos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CriadoEm",
                table: "Tarefas",
                newName: "CriadaEm");

            migrationBuilder.RenameColumn(
                name: "ConcluidoEm",
                table: "Tarefas",
                newName: "ConcluirEm");

            migrationBuilder.AddColumn<int>(
                name: "EquipeId",
                table: "Tarefas",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Equipes",
                columns: table => new
                {
                    EquipeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipes", x => x.EquipeId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Username = table.Column<string>(type: "TEXT", nullable: true),
                    Senha = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Telefone = table.Column<string>(type: "TEXT", nullable: true),
                    Logado = table.Column<bool>(type: "INTEGER", nullable: false),
                    TarefaId = table.Column<int>(type: "INTEGER", nullable: true),
                    EquipeId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuarios_Equipes_EquipeId",
                        column: x => x.EquipeId,
                        principalTable: "Equipes",
                        principalColumn: "EquipeId");
                    table.ForeignKey(
                        name: "FK_Usuarios_Tarefas_TarefaId",
                        column: x => x.TarefaId,
                        principalTable: "Tarefas",
                        principalColumn: "TarefaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_EquipeId",
                table: "Tarefas",
                column: "EquipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EquipeId",
                table: "Usuarios",
                column: "EquipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_TarefaId",
                table: "Usuarios",
                column: "TarefaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Equipes_EquipeId",
                table: "Tarefas",
                column: "EquipeId",
                principalTable: "Equipes",
                principalColumn: "EquipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Equipes_EquipeId",
                table: "Tarefas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Equipes");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_EquipeId",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "EquipeId",
                table: "Tarefas");

            migrationBuilder.RenameColumn(
                name: "CriadaEm",
                table: "Tarefas",
                newName: "CriadoEm");

            migrationBuilder.RenameColumn(
                name: "ConcluirEm",
                table: "Tarefas",
                newName: "ConcluidoEm");
        }
    }
}
