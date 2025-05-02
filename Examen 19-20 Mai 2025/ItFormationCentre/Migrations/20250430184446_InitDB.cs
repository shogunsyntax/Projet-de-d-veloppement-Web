using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItFormationCentre.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
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
                name: "Adresses",
                columns: table => new
                {
                    IdAdresse = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rue = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Pays = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdLocalite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.IdAdresse);
                    table.ForeignKey(
                        name: "FK_Adresses_Localites_IdLocalite",
                        column: x => x.IdLocalite,
                        principalTable: "Localites",
                        principalColumn: "IdLocalite",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Detentions",
                columns: table => new
                {
                    IdRole = table.Column<int>(type: "int", nullable: false),
                    IdPermission = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detentions", x => new { x.IdRole, x.IdPermission });
                    table.ForeignKey(
                        name: "FK_Detentions_Permissions_IdPermission",
                        column: x => x.IdPermission,
                        principalTable: "Permissions",
                        principalColumn: "IdPermission",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Detentions_Roles_IdRole",
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
                    IdAdresse = table.Column<int>(type: "int", nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Specialite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarteEtudiant = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.IdUtilisateur);
                    table.ForeignKey(
                        name: "FK_Utilisateurs_Adresses_IdAdresse",
                        column: x => x.IdAdresse,
                        principalTable: "Adresses",
                        principalColumn: "IdAdresse",
                        onDelete: ReferentialAction.Restrict);
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
                name: "Paniers",
                columns: table => new
                {
                    IdPanier = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUtilisateur = table.Column<int>(type: "int", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paniers", x => x.IdPanier);
                    table.ForeignKey(
                        name: "FK_Paniers_Utilisateurs_IdUtilisateur",
                        column: x => x.IdUtilisateur,
                        principalTable: "Utilisateurs",
                        principalColumn: "IdUtilisateur",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SessionsFormation",
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
                    table.PrimaryKey("PK_SessionsFormation", x => x.IdSessionFormation);
                    table.ForeignKey(
                        name: "FK_SessionsFormation_Formations_IdFormation",
                        column: x => x.IdFormation,
                        principalTable: "Formations",
                        principalColumn: "IdFormation",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SessionsFormation_Localites_IdLocalite",
                        column: x => x.IdLocalite,
                        principalTable: "Localites",
                        principalColumn: "IdLocalite",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SessionsFormation_Utilisateurs_FormateurIdUtilisateur",
                        column: x => x.FormateurIdUtilisateur,
                        principalTable: "Utilisateurs",
                        principalColumn: "IdUtilisateur");
                    table.ForeignKey(
                        name: "FK_SessionsFormation_Utilisateurs_IdUtilisateur",
                        column: x => x.IdUtilisateur,
                        principalTable: "Utilisateurs",
                        principalColumn: "IdUtilisateur",
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
                    table.ForeignKey(
                        name: "FK_Ajouts_Paniers_IdPanier",
                        column: x => x.IdPanier,
                        principalTable: "Paniers",
                        principalColumn: "IdPanier",
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
                    Commentaire = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                        name: "FK_Evaluations_SessionsFormation_IdSessionFormation",
                        column: x => x.IdSessionFormation,
                        principalTable: "SessionsFormation",
                        principalColumn: "IdSessionFormation",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Evaluations_SessionsFormation_SessionFormationIdSessionFormation",
                        column: x => x.SessionFormationIdSessionFormation,
                        principalTable: "SessionsFormation",
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
                        name: "FK_Inscriptions_SessionsFormation_IdSessionFormation",
                        column: x => x.IdSessionFormation,
                        principalTable: "SessionsFormation",
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
                        name: "FK_Local_SessionsFormation_SessionFormationIdSessionFormation",
                        column: x => x.SessionFormationIdSessionFormation,
                        principalTable: "SessionsFormation",
                        principalColumn: "IdSessionFormation");
                });

            migrationBuilder.CreateTable(
                name: "Plannifications",
                columns: table => new
                {
                    IdSessionFormation = table.Column<int>(type: "int", nullable: false),
                    IdHeure = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plannifications", x => new { x.IdSessionFormation, x.IdHeure });
                    table.ForeignKey(
                        name: "FK_Plannifications_Heures_IdHeure",
                        column: x => x.IdHeure,
                        principalTable: "Heures",
                        principalColumn: "IdHeure",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Plannifications_SessionsFormation_IdSessionFormation",
                        column: x => x.IdSessionFormation,
                        principalTable: "SessionsFormation",
                        principalColumn: "IdSessionFormation",
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
                    table.ForeignKey(
                        name: "FK_Paiements_Paniers_IdPanier",
                        column: x => x.IdPanier,
                        principalTable: "Paniers",
                        principalColumn: "IdPanier",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_IdLocalite",
                table: "Adresses",
                column: "IdLocalite");

            migrationBuilder.CreateIndex(
                name: "IX_Ajouts_IdFormation",
                table: "Ajouts",
                column: "IdFormation");

            migrationBuilder.CreateIndex(
                name: "IX_Detentions_IdPermission",
                table: "Detentions",
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
                name: "IX_Local_SessionFormationIdSessionFormation",
                table: "Local",
                column: "SessionFormationIdSessionFormation");

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
                name: "IX_Plannifications_IdHeure",
                table: "Plannifications",
                column: "IdHeure");

            migrationBuilder.CreateIndex(
                name: "IX_SessionsFormation_FormateurIdUtilisateur",
                table: "SessionsFormation",
                column: "FormateurIdUtilisateur");

            migrationBuilder.CreateIndex(
                name: "IX_SessionsFormation_IdFormation",
                table: "SessionsFormation",
                column: "IdFormation");

            migrationBuilder.CreateIndex(
                name: "IX_SessionsFormation_IdLocalite",
                table: "SessionsFormation",
                column: "IdLocalite");

            migrationBuilder.CreateIndex(
                name: "IX_SessionsFormation_IdUtilisateur",
                table: "SessionsFormation",
                column: "IdUtilisateur");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_IdAdresse",
                table: "Utilisateurs",
                column: "IdAdresse");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_IdLocalite",
                table: "Utilisateurs",
                column: "IdLocalite");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_IdRole",
                table: "Utilisateurs",
                column: "IdRole");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ajouts");

            migrationBuilder.DropTable(
                name: "Detentions");

            migrationBuilder.DropTable(
                name: "Evaluations");

            migrationBuilder.DropTable(
                name: "Local");

            migrationBuilder.DropTable(
                name: "Paiements");

            migrationBuilder.DropTable(
                name: "Plannifications");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Inscriptions");

            migrationBuilder.DropTable(
                name: "Paniers");

            migrationBuilder.DropTable(
                name: "Heures");

            migrationBuilder.DropTable(
                name: "SessionsFormation");

            migrationBuilder.DropTable(
                name: "Formations");

            migrationBuilder.DropTable(
                name: "Utilisateurs");

            migrationBuilder.DropTable(
                name: "Adresses");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Localites");
        }
    }
}
