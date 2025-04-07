using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApplication.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseCreating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    IdCategorie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomCategorie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.IdCategorie);
                });

            migrationBuilder.CreateTable(
                name: "Localite",
                columns: table => new
                {
                    IdLocalite = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomLocalite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodePostal = table.Column<int>(type: "int", nullable: false),
                    Intitule = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localite", x => x.IdLocalite);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    IdPermission = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Intitule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.IdPermission);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    IdRole = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntituleRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DetailRole = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.IdRole);
                });

            migrationBuilder.CreateTable(
                name: "TVA",
                columns: table => new
                {
                    IdTVA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TauxTva = table.Column<int>(type: "int", nullable: false),
                    TypeProduitTva = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TVA", x => x.IdTVA);
                });

            migrationBuilder.CreateTable(
                name: "Detenir",
                columns: table => new
                {
                    IdRole = table.Column<int>(type: "int", nullable: false),
                    IdPermission = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detenir", x => new { x.IdPermission, x.IdRole });
                    table.ForeignKey(
                        name: "FK_Detenir_Permission_IdPermission",
                        column: x => x.IdPermission,
                        principalTable: "Permission",
                        principalColumn: "IdPermission",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Detenir_Role_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Role",
                        principalColumn: "IdRole",
                        onDelete: ReferentialAction.Restrict);
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
                        principalColumn: "IdLocalite",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Utilisateur_Role_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Role",
                        principalColumn: "IdRole",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Produit",
                columns: table => new
                {
                    IdProduit = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTVA = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    NomProduit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionProduit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prix = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    IdCategorie = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    CategorieIdCategorie = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produit", x => x.IdProduit);
                    table.ForeignKey(
                        name: "FK_Produit_Categorie_CategorieIdCategorie",
                        column: x => x.CategorieIdCategorie,
                        principalTable: "Categorie",
                        principalColumn: "IdCategorie",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produit_TVA_IdTVA",
                        column: x => x.IdTVA,
                        principalTable: "TVA",
                        principalColumn: "IdTVA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Panier",
                columns: table => new
                {
                    IdPanier = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUtilisateur = table.Column<int>(type: "int", nullable: true),
                    UtilisateurIdUtilisateur = table.Column<int>(type: "int", nullable: true),
                    DatePanier = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Panier", x => x.IdPanier);
                    table.ForeignKey(
                        name: "FK_Panier_Utilisateur_IdUtilisateur",
                        column: x => x.IdUtilisateur,
                        principalTable: "Utilisateur",
                        principalColumn: "IdUtilisateur",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Panier_Utilisateur_UtilisateurIdUtilisateur",
                        column: x => x.UtilisateurIdUtilisateur,
                        principalTable: "Utilisateur",
                        principalColumn: "IdUtilisateur");
                });

            migrationBuilder.CreateTable(
                name: "Appartenir",
                columns: table => new
                {
                    IdCategorie = table.Column<int>(type: "int", nullable: false),
                    IdProduit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appartenir", x => new { x.IdCategorie, x.IdProduit });
                    table.ForeignKey(
                        name: "FK_Appartenir_Categorie_IdCategorie",
                        column: x => x.IdCategorie,
                        principalTable: "Categorie",
                        principalColumn: "IdCategorie",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appartenir_Produit_IdProduit",
                        column: x => x.IdProduit,
                        principalTable: "Produit",
                        principalColumn: "IdProduit",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ajouter",
                columns: table => new
                {
                    IdPanier = table.Column<int>(type: "int", nullable: false),
                    IdProduit = table.Column<int>(type: "int", nullable: false),
                    Quantite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ajouter", x => new { x.IdPanier, x.IdProduit });
                    table.ForeignKey(
                        name: "FK_Ajouter_Panier_IdPanier",
                        column: x => x.IdPanier,
                        principalTable: "Panier",
                        principalColumn: "IdPanier",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ajouter_Produit_IdProduit",
                        column: x => x.IdProduit,
                        principalTable: "Produit",
                        principalColumn: "IdProduit",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Commande",
                columns: table => new
                {
                    IdCommande = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPanier = table.Column<int>(type: "int", nullable: false),
                    IdUtilisateur = table.Column<int>(type: "int", nullable: false),
                    UtilisateurIdUtilisateur = table.Column<int>(type: "int", nullable: true),
                    DateCommande = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Statut = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commande", x => x.IdCommande);
                    table.ForeignKey(
                        name: "FK_Commande_Panier_IdPanier",
                        column: x => x.IdPanier,
                        principalTable: "Panier",
                        principalColumn: "IdPanier",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Commande_Utilisateur_IdUtilisateur",
                        column: x => x.IdUtilisateur,
                        principalTable: "Utilisateur",
                        principalColumn: "IdUtilisateur",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Commande_Utilisateur_UtilisateurIdUtilisateur",
                        column: x => x.UtilisateurIdUtilisateur,
                        principalTable: "Utilisateur",
                        principalColumn: "IdUtilisateur");
                });

            migrationBuilder.CreateTable(
                name: "Contenir",
                columns: table => new
                {
                    IdCommande = table.Column<int>(type: "int", nullable: false),
                    IdProduit = table.Column<int>(type: "int", nullable: false),
                    Quantite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contenir", x => new { x.IdCommande, x.IdProduit });
                    table.ForeignKey(
                        name: "FK_Contenir_Commande_IdCommande",
                        column: x => x.IdCommande,
                        principalTable: "Commande",
                        principalColumn: "IdCommande",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contenir_Produit_IdProduit",
                        column: x => x.IdProduit,
                        principalTable: "Produit",
                        principalColumn: "IdProduit",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ajouter_IdProduit",
                table: "Ajouter",
                column: "IdProduit");

            migrationBuilder.CreateIndex(
                name: "IX_Appartenir_IdProduit",
                table: "Appartenir",
                column: "IdProduit");

            migrationBuilder.CreateIndex(
                name: "IX_Commande_IdPanier",
                table: "Commande",
                column: "IdPanier");

            migrationBuilder.CreateIndex(
                name: "IX_Commande_IdUtilisateur",
                table: "Commande",
                column: "IdUtilisateur");

            migrationBuilder.CreateIndex(
                name: "IX_Commande_UtilisateurIdUtilisateur",
                table: "Commande",
                column: "UtilisateurIdUtilisateur");

            migrationBuilder.CreateIndex(
                name: "IX_Contenir_IdProduit",
                table: "Contenir",
                column: "IdProduit");

            migrationBuilder.CreateIndex(
                name: "IX_Detenir_IdRole",
                table: "Detenir",
                column: "IdRole");

            migrationBuilder.CreateIndex(
                name: "IX_Panier_IdUtilisateur",
                table: "Panier",
                column: "IdUtilisateur");

            migrationBuilder.CreateIndex(
                name: "IX_Panier_UtilisateurIdUtilisateur",
                table: "Panier",
                column: "UtilisateurIdUtilisateur");

            migrationBuilder.CreateIndex(
                name: "IX_Produit_CategorieIdCategorie",
                table: "Produit",
                column: "CategorieIdCategorie");

            migrationBuilder.CreateIndex(
                name: "IX_Produit_IdTVA",
                table: "Produit",
                column: "IdTVA");

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
                name: "Appartenir");

            migrationBuilder.DropTable(
                name: "Contenir");

            migrationBuilder.DropTable(
                name: "Detenir");

            migrationBuilder.DropTable(
                name: "Commande");

            migrationBuilder.DropTable(
                name: "Produit");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Panier");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropTable(
                name: "TVA");

            migrationBuilder.DropTable(
                name: "Utilisateur");

            migrationBuilder.DropTable(
                name: "Localite");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
