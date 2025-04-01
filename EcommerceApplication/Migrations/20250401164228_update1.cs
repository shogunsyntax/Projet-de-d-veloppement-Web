using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApplication.Migrations
{
    /// <inheritdoc />
    public partial class update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commande_Panier_PanierId",
                table: "Commande");

            migrationBuilder.AddForeignKey(
                name: "FK_Commande_Panier_PanierId",
                table: "Commande",
                column: "PanierId",
                principalTable: "Panier",
                principalColumn: "PanierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commande_Panier_PanierId",
                table: "Commande");

            migrationBuilder.AddForeignKey(
                name: "FK_Commande_Panier_PanierId",
                table: "Commande",
                column: "PanierId",
                principalTable: "Panier",
                principalColumn: "PanierId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
