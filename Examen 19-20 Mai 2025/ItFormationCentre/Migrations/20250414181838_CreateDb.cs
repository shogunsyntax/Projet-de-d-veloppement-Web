using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItFormationCentre.Migrations
{
    /// <inheritdoc />
    public partial class CreateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Formations",
                columns: table => new
                {
                    IdFormation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomFormation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prix = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Duree = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formations", x => x.IdFormation);
                });

            migrationBuilder.CreateTable(
                name: "Heures",
                columns: table => new
                {
                    IdHeure = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeureDebut = table.Column<TimeSpan>(type: "time", nullable: false),
                    HeureFin = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heures", x => x.IdHeure);
                });

            migrationBuilder.CreateTable(
                name: "Localites",
                columns: table => new
                {
                    IdLocalite = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomLocalite = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CodePostal = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localites", x => x.IdLocalite);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    IdPermission = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntitulePermission = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.IdPermission);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IdRole = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntituleRole = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.IdRole);
                });

            migrationBuilder.CreateTable(
                name: "Adresse",
                columns: table => new
                {
                    IdAdresse = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rue = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Pays = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdLocalite = table.Column<int>(type: "int", nullable: false),
                    LocaliteIdLocalite = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresse", x => x.IdAdresse);
                    table.ForeignKey(
                        name: "FK_Adresse_Localites_LocaliteIdLocalite",
                        column: x => x.LocaliteIdLocalite,
                        principalTable: "Localites",
                        principalColumn: "IdLocalite");
                });

            migrationBuilder.CreateTable(
                name: "Detenirs",
                columns: table => new
                {
                    IdRole = table.Column<int>(type: "int", nullable: false),
                    IdPermission = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detenirs", x => new { x.IdRole, x.IdPermission });
                    table.ForeignKey(
                        name: "FK_Detenirs_Permissions_IdPermission",
                        column: x => x.IdPermission,
                        principalTable: "Permissions",
                        principalColumn: "IdPermission",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Detenirs_Roles_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Roles",
                        principalColumn: "IdRole",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                columns: table => new
                {
                    IdUtilisateur = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRole = table.Column<int>(type: "int", nullable: false),
                    IdLocalite = table.Column<int>(type: "int", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NomUtilisateur = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotDePasse = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diplome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdAdresse = table.Column<int>(type: "int", maxLength: 250, nullable: false),
                    AdresseIdAdresse = table.Column<int>(type: "int", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Specialite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Experience = table.Column<int>(type: "int", nullable: true),
                    CarteEtudiant = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.IdUtilisateur);
                    table.ForeignKey(
                        name: "FK_Utilisateurs_Adresse_AdresseIdAdresse",
                        column: x => x.AdresseIdAdresse,
                        principalTable: "Adresse",
                        principalColumn: "IdAdresse");
                    table.ForeignKey(
                        name: "FK_Utilisateurs_Localites_IdLocalite",
                        column: x => x.IdLocalite,
                        principalTable: "Localites",
                        principalColumn: "IdLocalite",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Utilisateurs_Roles_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Roles",
                        principalColumn: "IdRole",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SessionsAnimees",
                columns: table => new
                {
                    IdSessionFormation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLocalite = table.Column<int>(type: "int", nullable: false),
                    IdUtilisateur = table.Column<int>(type: "int", nullable: false),
                    IdFormation = table.Column<int>(type: "int", nullable: false),
                    FormateurIdUtilisateur = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionsAnimees", x => x.IdSessionFormation);
                    table.ForeignKey(
                        name: "FK_SessionsAnimees_Formations_IdFormation",
                        column: x => x.IdFormation,
                        principalTable: "Formations",
                        principalColumn: "IdFormation",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SessionsAnimees_Localites_IdLocalite",
                        column: x => x.IdLocalite,
                        principalTable: "Localites",
                        principalColumn: "IdLocalite",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SessionsAnimees_Utilisateurs_FormateurIdUtilisateur",
                        column: x => x.FormateurIdUtilisateur,
                        principalTable: "Utilisateurs",
                        principalColumn: "IdUtilisateur");
                    table.ForeignKey(
                        name: "FK_SessionsAnimees_Utilisateurs_IdUtilisateur",
                        column: x => x.IdUtilisateur,
                        principalTable: "Utilisateurs",
                        principalColumn: "IdUtilisateur",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Evaluations",
                columns: table => new
                {
                    IdEvaluation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUtilisateurFormateur = table.Column<int>(type: "int", nullable: false),
                    IdUtilisateurStagiaire = table.Column<int>(type: "int", nullable: false),
                    IdSessionFormation = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Commentaire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateEvaluation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FormateurIdUtilisateur = table.Column<int>(type: "int", nullable: true),
                    FormateurIdUtilisateur1 = table.Column<int>(type: "int", nullable: true),
                    SessionFormationIdSessionFormation = table.Column<int>(type: "int", nullable: true),
                    StagiaireIdUtilisateur = table.Column<int>(type: "int", nullable: true),
                    UtilisateurIdUtilisateur = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluations", x => x.IdEvaluation);
                    table.ForeignKey(
                        name: "FK_Evaluations_SessionsAnimees_IdSessionFormation",
                        column: x => x.IdSessionFormation,
                        principalTable: "SessionsAnimees",
                        principalColumn: "IdSessionFormation",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Evaluations_SessionsAnimees_SessionFormationIdSessionFormation",
                        column: x => x.SessionFormationIdSessionFormation,
                        principalTable: "SessionsAnimees",
                        principalColumn: "IdSessionFormation");
                    table.ForeignKey(
                        name: "FK_Evaluations_Utilisateurs_FormateurIdUtilisateur",
                        column: x => x.FormateurIdUtilisateur,
                        principalTable: "Utilisateurs",
                        principalColumn: "IdUtilisateur");
                    table.ForeignKey(
                        name: "FK_Evaluations_Utilisateurs_FormateurIdUtilisateur1",
                        column: x => x.FormateurIdUtilisateur1,
                        principalTable: "Utilisateurs",
                        principalColumn: "IdUtilisateur");
                    table.ForeignKey(
                        name: "FK_Evaluations_Utilisateurs_IdUtilisateurFormateur",
                        column: x => x.IdUtilisateurFormateur,
                        principalTable: "Utilisateurs",
                        principalColumn: "IdUtilisateur",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Evaluations_Utilisateurs_IdUtilisateurStagiaire",
                        column: x => x.IdUtilisateurStagiaire,
                        principalTable: "Utilisateurs",
                        principalColumn: "IdUtilisateur",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Evaluations_Utilisateurs_StagiaireIdUtilisateur",
                        column: x => x.StagiaireIdUtilisateur,
                        principalTable: "Utilisateurs",
                        principalColumn: "IdUtilisateur");
                    table.ForeignKey(
                        name: "FK_Evaluations_Utilisateurs_UtilisateurIdUtilisateur",
                        column: x => x.UtilisateurIdUtilisateur,
                        principalTable: "Utilisateurs",
                        principalColumn: "IdUtilisateur");
                });

            migrationBuilder.CreateTable(
                name: "Inscriptions",
                columns: table => new
                {
                    IdInscription = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateInscription = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Statut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdSessionFormation = table.Column<int>(type: "int", nullable: false),
                    IdUtilisateur = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscriptions", x => x.IdInscription);
                    table.ForeignKey(
                        name: "FK_Inscriptions_SessionsAnimees_IdSessionFormation",
                        column: x => x.IdSessionFormation,
                        principalTable: "SessionsAnimees",
                        principalColumn: "IdSessionFormation",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inscriptions_Utilisateurs_IdUtilisateur",
                        column: x => x.IdUtilisateur,
                        principalTable: "Utilisateurs",
                        principalColumn: "IdUtilisateur",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Plannifier",
                columns: table => new
                {
                    IdSessionFormation = table.Column<int>(type: "int", nullable: false),
                    IdHeure = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plannifier", x => new { x.IdSessionFormation, x.IdHeure });
                    table.ForeignKey(
                        name: "FK_Plannifier_Heures_IdHeure",
                        column: x => x.IdHeure,
                        principalTable: "Heures",
                        principalColumn: "IdHeure",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Plannifier_SessionsAnimees_IdSessionFormation",
                        column: x => x.IdSessionFormation,
                        principalTable: "SessionsAnimees",
                        principalColumn: "IdSessionFormation",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ajouts",
                columns: table => new
                {
                    IdPanier = table.Column<int>(type: "int", nullable: false),
                    IdFormation = table.Column<int>(type: "int", nullable: false),
                    IdAjouter = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ajouts", x => new { x.IdPanier, x.IdFormation });
                    table.ForeignKey(
                        name: "FK_Ajouts_Formations_IdFormation",
                        column: x => x.IdFormation,
                        principalTable: "Formations",
                        principalColumn: "IdFormation",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Paiements",
                columns: table => new
                {
                    IdPaiement = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Montant = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TypePaiement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatePaiement = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatutPaiement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdInscription = table.Column<int>(type: "int", nullable: false),
                    IdPanier = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paiements", x => x.IdPaiement);
                    table.ForeignKey(
                        name: "FK_Paiements_Inscriptions_IdInscription",
                        column: x => x.IdInscription,
                        principalTable: "Inscriptions",
                        principalColumn: "IdInscription",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Paniers",
                columns: table => new
                {
                    IdPanier = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateValidation = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Statut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MethodePaiement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodePromo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reduction = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Tva = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetAPayer = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdUtilisateur = table.Column<int>(type: "int", nullable: false),
                    IdPaiement = table.Column<int>(type: "int", nullable: false),
                    PaiementIdPaiement = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paniers", x => x.IdPanier);
                    table.ForeignKey(
                        name: "FK_Paniers_Paiements_PaiementIdPaiement",
                        column: x => x.PaiementIdPaiement,
                        principalTable: "Paiements",
                        principalColumn: "IdPaiement");
                    table.ForeignKey(
                        name: "FK_Paniers_Utilisateurs_IdUtilisateur",
                        column: x => x.IdUtilisateur,
                        principalTable: "Utilisateurs",
                        principalColumn: "IdUtilisateur",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresse_LocaliteIdLocalite",
                table: "Adresse",
                column: "LocaliteIdLocalite");

            migrationBuilder.CreateIndex(
                name: "IX_Ajouts_IdFormation",
                table: "Ajouts",
                column: "IdFormation");

            migrationBuilder.CreateIndex(
                name: "IX_Detenirs_IdPermission",
                table: "Detenirs",
                column: "IdPermission");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_FormateurIdUtilisateur",
                table: "Evaluations",
                column: "FormateurIdUtilisateur");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_FormateurIdUtilisateur1",
                table: "Evaluations",
                column: "FormateurIdUtilisateur1");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_IdSessionFormation",
                table: "Evaluations",
                column: "IdSessionFormation");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_IdUtilisateurFormateur",
                table: "Evaluations",
                column: "IdUtilisateurFormateur");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_IdUtilisateurStagiaire",
                table: "Evaluations",
                column: "IdUtilisateurStagiaire");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_SessionFormationIdSessionFormation",
                table: "Evaluations",
                column: "SessionFormationIdSessionFormation");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_StagiaireIdUtilisateur",
                table: "Evaluations",
                column: "StagiaireIdUtilisateur");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_UtilisateurIdUtilisateur",
                table: "Evaluations",
                column: "UtilisateurIdUtilisateur");

            migrationBuilder.CreateIndex(
                name: "IX_Inscriptions_IdSessionFormation",
                table: "Inscriptions",
                column: "IdSessionFormation");

            migrationBuilder.CreateIndex(
                name: "IX_Inscriptions_IdUtilisateur",
                table: "Inscriptions",
                column: "IdUtilisateur");

            migrationBuilder.CreateIndex(
                name: "IX_Paiements_IdInscription",
                table: "Paiements",
                column: "IdInscription");

            migrationBuilder.CreateIndex(
                name: "IX_Paiements_IdPanier",
                table: "Paiements",
                column: "IdPanier");

            migrationBuilder.CreateIndex(
                name: "IX_Paniers_IdUtilisateur",
                table: "Paniers",
                column: "IdUtilisateur");

            migrationBuilder.CreateIndex(
                name: "IX_Paniers_PaiementIdPaiement",
                table: "Paniers",
                column: "PaiementIdPaiement");

            migrationBuilder.CreateIndex(
                name: "IX_Plannifier_IdHeure",
                table: "Plannifier",
                column: "IdHeure");

            migrationBuilder.CreateIndex(
                name: "IX_SessionsAnimees_FormateurIdUtilisateur",
                table: "SessionsAnimees",
                column: "FormateurIdUtilisateur");

            migrationBuilder.CreateIndex(
                name: "IX_SessionsAnimees_IdFormation",
                table: "SessionsAnimees",
                column: "IdFormation");

            migrationBuilder.CreateIndex(
                name: "IX_SessionsAnimees_IdLocalite",
                table: "SessionsAnimees",
                column: "IdLocalite");

            migrationBuilder.CreateIndex(
                name: "IX_SessionsAnimees_IdUtilisateur",
                table: "SessionsAnimees",
                column: "IdUtilisateur");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_AdresseIdAdresse",
                table: "Utilisateurs",
                column: "AdresseIdAdresse");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_IdLocalite",
                table: "Utilisateurs",
                column: "IdLocalite");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_IdRole",
                table: "Utilisateurs",
                column: "IdRole");

            migrationBuilder.AddForeignKey(
                name: "FK_Ajouts_Paniers_IdPanier",
                table: "Ajouts",
                column: "IdPanier",
                principalTable: "Paniers",
                principalColumn: "IdPanier",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Paiements_Paniers_IdPanier",
                table: "Paiements",
                column: "IdPanier",
                principalTable: "Paniers",
                principalColumn: "IdPanier",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresse_Localites_LocaliteIdLocalite",
                table: "Adresse");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionsAnimees_Localites_IdLocalite",
                table: "SessionsAnimees");

            migrationBuilder.DropForeignKey(
                name: "FK_Utilisateurs_Localites_IdLocalite",
                table: "Utilisateurs");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionsAnimees_Formations_IdFormation",
                table: "SessionsAnimees");

            migrationBuilder.DropForeignKey(
                name: "FK_Paiements_Paniers_IdPanier",
                table: "Paiements");

            migrationBuilder.DropTable(
                name: "Ajouts");

            migrationBuilder.DropTable(
                name: "Detenirs");

            migrationBuilder.DropTable(
                name: "Evaluations");

            migrationBuilder.DropTable(
                name: "Plannifier");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Heures");

            migrationBuilder.DropTable(
                name: "Localites");

            migrationBuilder.DropTable(
                name: "Formations");

            migrationBuilder.DropTable(
                name: "Paniers");

            migrationBuilder.DropTable(
                name: "Paiements");

            migrationBuilder.DropTable(
                name: "Inscriptions");

            migrationBuilder.DropTable(
                name: "SessionsAnimees");

            migrationBuilder.DropTable(
                name: "Utilisateurs");

            migrationBuilder.DropTable(
                name: "Adresse");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
