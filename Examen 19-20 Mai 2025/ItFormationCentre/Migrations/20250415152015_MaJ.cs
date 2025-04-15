using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItFormationCentre.Migrations
{
    /// <inheritdoc />
    public partial class MaJ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utilisateurs_Adresse_AdresseIdAdresse",
                table: "Utilisateurs");

            migrationBuilder.DropIndex(
                name: "IX_Utilisateurs_AdresseIdAdresse",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "AdresseIdAdresse",
                table: "Utilisateurs");

            migrationBuilder.AddColumn<int>(
                name: "IdUtilisateur",
                table: "Adresse",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UtilisateurIdUtilisateur",
                table: "Adresse",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Local",
                columns: table => new
                {
                    IdLocal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroLocal = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Capacite = table.Column<int>(type: "int", nullable: false),
                    Disponibilite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SessionFormationIdSessionFormation = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Local", x => x.IdLocal);
                    table.ForeignKey(
                        name: "FK_Local_SessionsAnimees_SessionFormationIdSessionFormation",
                        column: x => x.SessionFormationIdSessionFormation,
                        principalTable: "SessionsAnimees",
                        principalColumn: "IdSessionFormation");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_IdAdresse",
                table: "Utilisateurs",
                column: "IdAdresse");

            migrationBuilder.CreateIndex(
                name: "IX_Adresse_UtilisateurIdUtilisateur",
                table: "Adresse",
                column: "UtilisateurIdUtilisateur");

            migrationBuilder.CreateIndex(
                name: "IX_Local_SessionFormationIdSessionFormation",
                table: "Local",
                column: "SessionFormationIdSessionFormation");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresse_Utilisateurs_UtilisateurIdUtilisateur",
                table: "Adresse",
                column: "UtilisateurIdUtilisateur",
                principalTable: "Utilisateurs",
                principalColumn: "IdUtilisateur");

            migrationBuilder.AddForeignKey(
                name: "FK_Utilisateurs_Adresse_IdAdresse",
                table: "Utilisateurs",
                column: "IdAdresse",
                principalTable: "Adresse",
                principalColumn: "IdAdresse",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresse_Utilisateurs_UtilisateurIdUtilisateur",
                table: "Adresse");

            migrationBuilder.DropForeignKey(
                name: "FK_Utilisateurs_Adresse_IdAdresse",
                table: "Utilisateurs");

            migrationBuilder.DropTable(
                name: "Local");

            migrationBuilder.DropIndex(
                name: "IX_Utilisateurs_IdAdresse",
                table: "Utilisateurs");

            migrationBuilder.DropIndex(
                name: "IX_Adresse_UtilisateurIdUtilisateur",
                table: "Adresse");

            migrationBuilder.DropColumn(
                name: "IdUtilisateur",
                table: "Adresse");

            migrationBuilder.DropColumn(
                name: "UtilisateurIdUtilisateur",
                table: "Adresse");

            migrationBuilder.AddColumn<int>(
                name: "AdresseIdAdresse",
                table: "Utilisateurs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_AdresseIdAdresse",
                table: "Utilisateurs",
                column: "AdresseIdAdresse");

            migrationBuilder.AddForeignKey(
                name: "FK_Utilisateurs_Adresse_AdresseIdAdresse",
                table: "Utilisateurs",
                column: "AdresseIdAdresse",
                principalTable: "Adresse",
                principalColumn: "IdAdresse");
        }
    }
}
