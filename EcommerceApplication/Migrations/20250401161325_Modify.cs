using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApplication.Migrations
{
    /// <inheritdoc />
    public partial class Modify : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appartenir",
                columns: table => new
                {
                    CategorieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProduitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appartenir", x => new { x.CategorieId, x.ProduitId });
                });

            migrationBuilder.CreateTable(
                name: "Detenir",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detenir", x => new { x.PermissionId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "Localite",
                columns: table => new
                {
                    LocaliteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomLocalite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodePostal = table.Column<int>(type: "int", nullable: false),
                    Intitule = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localite", x => x.LocaliteId);
                });

            migrationBuilder.CreateTable(
                name: "TVA",
                columns: table => new
                {
                    TvaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TauxTva = table.Column<int>(type: "int", nullable: false),
                    TypeProduitTva = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TVA", x => x.TvaId);
                });

            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    CategorieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomCategorie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AppartenirCategorieId = table.Column<int>(type: "int", nullable: true),
                    AppartenirProduitId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.CategorieId);
                    table.ForeignKey(
                        name: "FK_Categorie_Appartenir_AppartenirCategorieId_AppartenirProduitId",
                        columns: x => new { x.AppartenirCategorieId, x.AppartenirProduitId },
                        principalTable: "Appartenir",
                        principalColumns: new[] { "CategorieId", "ProduitId" });
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Intitule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DetenirPermissionId = table.Column<int>(type: "int", nullable: true),
                    DetenirRoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.PermissionId);
                    table.ForeignKey(
                        name: "FK_Permission_Detenir_DetenirPermissionId_DetenirRoleId",
                        columns: x => new { x.DetenirPermissionId, x.DetenirRoleId },
                        principalTable: "Detenir",
                        principalColumns: new[] { "PermissionId", "RoleId" });
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntituleRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DetailRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DetenirPermissionId = table.Column<int>(type: "int", nullable: true),
                    DetenirRoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                    table.ForeignKey(
                        name: "FK_Role_Detenir_DetenirPermissionId_DetenirRoleId",
                        columns: x => new { x.DetenirPermissionId, x.DetenirRoleId },
                        principalTable: "Detenir",
                        principalColumns: new[] { "PermissionId", "RoleId" });
                });

            migrationBuilder.CreateTable(
                name: "Produit",
                columns: table => new
                {
                    IdProduit = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TvaId = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    NomProduit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionProduit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prix = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    CategorieId = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppartenirCategorieId = table.Column<int>(type: "int", nullable: true),
                    AppartenirProduitId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produit", x => x.IdProduit);
                    table.ForeignKey(
                        name: "FK_Produit_Appartenir_AppartenirCategorieId_AppartenirProduitId",
                        columns: x => new { x.AppartenirCategorieId, x.AppartenirProduitId },
                        principalTable: "Appartenir",
                        principalColumns: new[] { "CategorieId", "ProduitId" });
                    table.ForeignKey(
                        name: "FK_Produit_Categorie_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categorie",
                        principalColumn: "CategorieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produit_TVA_TvaId",
                        column: x => x.TvaId,
                        principalTable: "TVA",
                        principalColumn: "TvaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateur",
                columns: table => new
                {
                    IdUtilisateur = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRole = table.Column<int>(type: "int", nullable: false),
                    IdLocalite = table.Column<int>(type: "int", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotDePasse = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateur", x => x.IdUtilisateur);
                    table.ForeignKey(
                        name: "FK_Utilisateur_Localite_IdLocalite",
                        column: x => x.IdLocalite,
                        principalTable: "Localite",
                        principalColumn: "LocaliteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Utilisateur_Role_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Panier",
                columns: table => new
                {
                    PanierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilisateurId = table.Column<int>(type: "int", nullable: false),
                    UtilisateurIdUtilisateur = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Panier", x => x.PanierId);
                    table.ForeignKey(
                        name: "FK_Panier_Utilisateur_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateur",
                        principalColumn: "IdUtilisateur",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Panier_Utilisateur_UtilisateurIdUtilisateur",
                        column: x => x.UtilisateurIdUtilisateur,
                        principalTable: "Utilisateur",
                        principalColumn: "IdUtilisateur",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ajouter",
                columns: table => new
                {
                    PanierId = table.Column<int>(type: "int", nullable: false),
                    ProduitId = table.Column<int>(type: "int", nullable: false),
                    Quantite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ajouter", x => new { x.PanierId, x.ProduitId });
                    table.ForeignKey(
                        name: "FK_Ajouter_Panier_PanierId",
                        column: x => x.PanierId,
                        principalTable: "Panier",
                        principalColumn: "PanierId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ajouter_Produit_ProduitId",
                        column: x => x.ProduitId,
                        principalTable: "Produit",
                        principalColumn: "IdProduit",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commande",
                columns: table => new
                {
                    CommandeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PanierId = table.Column<int>(type: "int", nullable: false),
                    UtilisateurId = table.Column<int>(type: "int", nullable: false),
                    UtilisateurIdUtilisateur = table.Column<int>(type: "int", nullable: false),
                    DateCommande = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Statut = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commande", x => x.CommandeId);
                    table.ForeignKey(
                        name: "FK_Commande_Panier_PanierId",
                        column: x => x.PanierId,
                        principalTable: "Panier",
                        principalColumn: "PanierId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commande_Utilisateur_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateur",
                        principalColumn: "IdUtilisateur",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commande_Utilisateur_UtilisateurIdUtilisateur",
                        column: x => x.UtilisateurIdUtilisateur,
                        principalTable: "Utilisateur",
                        principalColumn: "IdUtilisateur",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contenir",
                columns: table => new
                {
                    CommandeId = table.Column<int>(type: "int", nullable: false),
                    ProduitId = table.Column<int>(type: "int", nullable: false),
                    Quantite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contenir", x => new { x.CommandeId, x.ProduitId });
                    table.ForeignKey(
                        name: "FK_Contenir_Commande_CommandeId",
                        column: x => x.CommandeId,
                        principalTable: "Commande",
                        principalColumn: "CommandeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contenir_Produit_ProduitId",
                        column: x => x.ProduitId,
                        principalTable: "Produit",
                        principalColumn: "IdProduit",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ajouter_ProduitId",
                table: "Ajouter",
                column: "ProduitId");

            migrationBuilder.CreateIndex(
                name: "IX_Categorie_AppartenirCategorieId_AppartenirProduitId",
                table: "Categorie",
                columns: new[] { "AppartenirCategorieId", "AppartenirProduitId" });

            migrationBuilder.CreateIndex(
                name: "IX_Commande_PanierId",
                table: "Commande",
                column: "PanierId");

            migrationBuilder.CreateIndex(
                name: "IX_Commande_UtilisateurId",
                table: "Commande",
                column: "UtilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Commande_UtilisateurIdUtilisateur",
                table: "Commande",
                column: "UtilisateurIdUtilisateur");

            migrationBuilder.CreateIndex(
                name: "IX_Contenir_ProduitId",
                table: "Contenir",
                column: "ProduitId");

            migrationBuilder.CreateIndex(
                name: "IX_Panier_UtilisateurId",
                table: "Panier",
                column: "UtilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Panier_UtilisateurIdUtilisateur",
                table: "Panier",
                column: "UtilisateurIdUtilisateur");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_DetenirPermissionId_DetenirRoleId",
                table: "Permission",
                columns: new[] { "DetenirPermissionId", "DetenirRoleId" });

            migrationBuilder.CreateIndex(
                name: "IX_Produit_AppartenirCategorieId_AppartenirProduitId",
                table: "Produit",
                columns: new[] { "AppartenirCategorieId", "AppartenirProduitId" });

            migrationBuilder.CreateIndex(
                name: "IX_Produit_CategorieId",
                table: "Produit",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Produit_TvaId",
                table: "Produit",
                column: "TvaId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_DetenirPermissionId_DetenirRoleId",
                table: "Role",
                columns: new[] { "DetenirPermissionId", "DetenirRoleId" });

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateur_IdLocalite",
                table: "Utilisateur",
                column: "IdLocalite");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateur_IdRole",
                table: "Utilisateur",
                column: "IdRole");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ajouter");

            migrationBuilder.DropTable(
                name: "Contenir");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Commande");

            migrationBuilder.DropTable(
                name: "Produit");

            migrationBuilder.DropTable(
                name: "Panier");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropTable(
                name: "TVA");

            migrationBuilder.DropTable(
                name: "Utilisateur");

            migrationBuilder.DropTable(
                name: "Appartenir");

            migrationBuilder.DropTable(
                name: "Localite");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Detenir");
        }
    }
}
