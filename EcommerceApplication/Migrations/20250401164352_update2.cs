using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApplication.Migrations
{
    /// <inheritdoc />
    public partial class update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Panier_Utilisateur_UtilisateurId",
                table: "Panier");

            migrationBuilder.AddForeignKey(
                name: "FK_Panier_Utilisateur_UtilisateurId",
                table: "Panier",
                column: "UtilisateurId",
                principalTable: "Utilisateur",
                principalColumn: "IdUtilisateur");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Panier_Utilisateur_UtilisateurId",
                table: "Panier");

            migrationBuilder.AddForeignKey(
                name: "FK_Panier_Utilisateur_UtilisateurId",
                table: "Panier",
                column: "UtilisateurId",
                principalTable: "Utilisateur",
                principalColumn: "IdUtilisateur",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
