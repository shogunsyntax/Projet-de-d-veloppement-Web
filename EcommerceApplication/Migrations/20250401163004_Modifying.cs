using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApplication.Migrations
{
    /// <inheritdoc />
    public partial class Modifying : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorie_Appartenir_AppartenirCategorieId_AppartenirProduitId",
                table: "Categorie");

            migrationBuilder.DropForeignKey(
                name: "FK_Permission_Detenir_DetenirPermissionId_DetenirRoleId",
                table: "Permission");

            migrationBuilder.DropForeignKey(
                name: "FK_Produit_Appartenir_AppartenirCategorieId_AppartenirProduitId",
                table: "Produit");

            migrationBuilder.DropForeignKey(
                name: "FK_Role_Detenir_DetenirPermissionId_DetenirRoleId",
                table: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Role_DetenirPermissionId_DetenirRoleId",
                table: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Produit_AppartenirCategorieId_AppartenirProduitId",
                table: "Produit");

            migrationBuilder.DropIndex(
                name: "IX_Permission_DetenirPermissionId_DetenirRoleId",
                table: "Permission");

            migrationBuilder.DropIndex(
                name: "IX_Categorie_AppartenirCategorieId_AppartenirProduitId",
                table: "Categorie");

            migrationBuilder.DropColumn(
                name: "DetenirPermissionId",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "DetenirRoleId",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "AppartenirCategorieId",
                table: "Produit");

            migrationBuilder.DropColumn(
                name: "AppartenirProduitId",
                table: "Produit");

            migrationBuilder.DropColumn(
                name: "DetenirPermissionId",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "DetenirRoleId",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "AppartenirCategorieId",
                table: "Categorie");

            migrationBuilder.DropColumn(
                name: "AppartenirProduitId",
                table: "Categorie");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Detenir",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "CategorieId",
                table: "Appartenir",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_Detenir_RoleId",
                table: "Detenir",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Appartenir_ProduitId",
                table: "Appartenir",
                column: "ProduitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appartenir_Categorie_CategorieId",
                table: "Appartenir",
                column: "CategorieId",
                principalTable: "Categorie",
                principalColumn: "CategorieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appartenir_Produit_ProduitId",
                table: "Appartenir",
                column: "ProduitId",
                principalTable: "Produit",
                principalColumn: "IdProduit",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Detenir_Permission_PermissionId",
                table: "Detenir",
                column: "PermissionId",
                principalTable: "Permission",
                principalColumn: "PermissionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Detenir_Role_RoleId",
                table: "Detenir",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appartenir_Categorie_CategorieId",
                table: "Appartenir");

            migrationBuilder.DropForeignKey(
                name: "FK_Appartenir_Produit_ProduitId",
                table: "Appartenir");

            migrationBuilder.DropForeignKey(
                name: "FK_Detenir_Permission_PermissionId",
                table: "Detenir");

            migrationBuilder.DropForeignKey(
                name: "FK_Detenir_Role_RoleId",
                table: "Detenir");

            migrationBuilder.DropIndex(
                name: "IX_Detenir_RoleId",
                table: "Detenir");

            migrationBuilder.DropIndex(
                name: "IX_Appartenir_ProduitId",
                table: "Appartenir");

            migrationBuilder.AddColumn<int>(
                name: "DetenirPermissionId",
                table: "Role",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DetenirRoleId",
                table: "Role",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppartenirCategorieId",
                table: "Produit",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppartenirProduitId",
                table: "Produit",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DetenirPermissionId",
                table: "Permission",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DetenirRoleId",
                table: "Permission",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Detenir",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "AppartenirCategorieId",
                table: "Categorie",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppartenirProduitId",
                table: "Categorie",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategorieId",
                table: "Appartenir",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_Role_DetenirPermissionId_DetenirRoleId",
                table: "Role",
                columns: new[] { "DetenirPermissionId", "DetenirRoleId" });

            migrationBuilder.CreateIndex(
                name: "IX_Produit_AppartenirCategorieId_AppartenirProduitId",
                table: "Produit",
                columns: new[] { "AppartenirCategorieId", "AppartenirProduitId" });

            migrationBuilder.CreateIndex(
                name: "IX_Permission_DetenirPermissionId_DetenirRoleId",
                table: "Permission",
                columns: new[] { "DetenirPermissionId", "DetenirRoleId" });

            migrationBuilder.CreateIndex(
                name: "IX_Categorie_AppartenirCategorieId_AppartenirProduitId",
                table: "Categorie",
                columns: new[] { "AppartenirCategorieId", "AppartenirProduitId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Categorie_Appartenir_AppartenirCategorieId_AppartenirProduitId",
                table: "Categorie",
                columns: new[] { "AppartenirCategorieId", "AppartenirProduitId" },
                principalTable: "Appartenir",
                principalColumns: new[] { "CategorieId", "ProduitId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Permission_Detenir_DetenirPermissionId_DetenirRoleId",
                table: "Permission",
                columns: new[] { "DetenirPermissionId", "DetenirRoleId" },
                principalTable: "Detenir",
                principalColumns: new[] { "PermissionId", "RoleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Produit_Appartenir_AppartenirCategorieId_AppartenirProduitId",
                table: "Produit",
                columns: new[] { "AppartenirCategorieId", "AppartenirProduitId" },
                principalTable: "Appartenir",
                principalColumns: new[] { "CategorieId", "ProduitId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Role_Detenir_DetenirPermissionId_DetenirRoleId",
                table: "Role",
                columns: new[] { "DetenirPermissionId", "DetenirRoleId" },
                principalTable: "Detenir",
                principalColumns: new[] { "PermissionId", "RoleId" });
        }
    }
}
