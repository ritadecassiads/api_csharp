using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class addControllerAssociacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipeUsuarioTarefa_Equipes_EquipeId",
                table: "EquipeUsuarioTarefa");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipeUsuarioTarefa_Tarefas_TarefaId",
                table: "EquipeUsuarioTarefa");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipeUsuarioTarefa_Usuarios_UsuarioId",
                table: "EquipeUsuarioTarefa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipeUsuarioTarefa",
                table: "EquipeUsuarioTarefa");

            migrationBuilder.RenameTable(
                name: "EquipeUsuarioTarefa",
                newName: "EquipeUsuarioTarefas");

            migrationBuilder.RenameIndex(
                name: "IX_EquipeUsuarioTarefa_UsuarioId",
                table: "EquipeUsuarioTarefas",
                newName: "IX_EquipeUsuarioTarefas_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipeUsuarioTarefa_TarefaId",
                table: "EquipeUsuarioTarefas",
                newName: "IX_EquipeUsuarioTarefas_TarefaId");

            migrationBuilder.AddColumn<int>(
                name: "EquipeUsuarioTarefaId",
                table: "EquipeUsuarioTarefas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipeUsuarioTarefas",
                table: "EquipeUsuarioTarefas",
                columns: new[] { "EquipeId", "UsuarioId", "TarefaId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EquipeUsuarioTarefas_Equipes_EquipeId",
                table: "EquipeUsuarioTarefas",
                column: "EquipeId",
                principalTable: "Equipes",
                principalColumn: "EquipeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipeUsuarioTarefas_Tarefas_TarefaId",
                table: "EquipeUsuarioTarefas",
                column: "TarefaId",
                principalTable: "Tarefas",
                principalColumn: "TarefaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipeUsuarioTarefas_Usuarios_UsuarioId",
                table: "EquipeUsuarioTarefas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipeUsuarioTarefas_Equipes_EquipeId",
                table: "EquipeUsuarioTarefas");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipeUsuarioTarefas_Tarefas_TarefaId",
                table: "EquipeUsuarioTarefas");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipeUsuarioTarefas_Usuarios_UsuarioId",
                table: "EquipeUsuarioTarefas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipeUsuarioTarefas",
                table: "EquipeUsuarioTarefas");

            migrationBuilder.DropColumn(
                name: "EquipeUsuarioTarefaId",
                table: "EquipeUsuarioTarefas");

            migrationBuilder.RenameTable(
                name: "EquipeUsuarioTarefas",
                newName: "EquipeUsuarioTarefa");

            migrationBuilder.RenameIndex(
                name: "IX_EquipeUsuarioTarefas_UsuarioId",
                table: "EquipeUsuarioTarefa",
                newName: "IX_EquipeUsuarioTarefa_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipeUsuarioTarefas_TarefaId",
                table: "EquipeUsuarioTarefa",
                newName: "IX_EquipeUsuarioTarefa_TarefaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipeUsuarioTarefa",
                table: "EquipeUsuarioTarefa",
                columns: new[] { "EquipeId", "UsuarioId", "TarefaId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EquipeUsuarioTarefa_Equipes_EquipeId",
                table: "EquipeUsuarioTarefa",
                column: "EquipeId",
                principalTable: "Equipes",
                principalColumn: "EquipeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipeUsuarioTarefa_Tarefas_TarefaId",
                table: "EquipeUsuarioTarefa",
                column: "TarefaId",
                principalTable: "Tarefas",
                principalColumn: "TarefaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipeUsuarioTarefa_Usuarios_UsuarioId",
                table: "EquipeUsuarioTarefa",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
