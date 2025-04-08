using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItFormationCentre.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                name: "Permissions",
                columns: table => new
                {
                    IdPermission = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntitulePermission = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "SessionFormations",
                columns: table => new
                {
                    IdSessionFormation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NombreParticipant = table.Column<int>(type: "int", nullable: false),
                    StatusSession = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdFormation = table.Column<int>(type: "int", nullable: false),
                    FormationIdFormation = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionFormations", x => x.IdSessionFormation);
                    table.ForeignKey(
                        name: "FK_SessionFormations_Formations_FormationIdFormation",
                        column: x => x.FormationIdFormation,
                        principalTable: "Formations",
                        principalColumn: "IdFormation");
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
                    table.PrimaryKey("PK_Detentions", x => x.IdRole);
                    table.ForeignKey(
                        name: "FK_Detentions_Permissions_IdPermission",
                        column: x => x.IdPermission,
                        principalTable: "Permissions",
                        principalColumn: "IdPermission",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Detentions_Roles_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Roles",
                        principalColumn: "IdRole",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissionRole",
                columns: table => new
                {
                    PermissionsIdPermission = table.Column<int>(type: "int", nullable: false),
                    RolesIdRole = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionRole", x => new { x.PermissionsIdPermission, x.RolesIdRole });
                    table.ForeignKey(
                        name: "FK_PermissionRole_Permissions_PermissionsIdPermission",
                        column: x => x.PermissionsIdPermission,
                        principalTable: "Permissions",
                        principalColumn: "IdPermission",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionRole_Roles_RolesIdRole",
                        column: x => x.RolesIdRole,
                        principalTable: "Roles",
                        principalColumn: "IdRole",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Localites",
                columns: table => new
                {
                    IdLocalite = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomLocalite = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CodePostal = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SessionFormationIdSessionFormation = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localites", x => x.IdLocalite);
                    table.ForeignKey(
                        name: "FK_Localites_SessionFormations_SessionFormationIdSessionFormation",
                        column: x => x.SessionFormationIdSessionFormation,
                        principalTable: "SessionFormations",
                        principalColumn: "IdSessionFormation");
                });

            migrationBuilder.CreateTable(
                name: "Planifications",
                columns: table => new
                {
                    IdSessionFormation = table.Column<int>(type: "int", nullable: false),
                    IdHeure = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planifications", x => x.IdSessionFormation);
                    table.ForeignKey(
                        name: "FK_Planifications_Heures_IdHeure",
                        column: x => x.IdHeure,
                        principalTable: "Heures",
                        principalColumn: "IdHeure",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Planifications_SessionFormations_IdSessionFormation",
                        column: x => x.IdSessionFormation,
                        principalTable: "SessionFormations",
                        principalColumn: "IdSessionFormation",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                columns: table => new
                {
                    IdUtilisateur = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRole = table.Column<int>(type: "int", nullable: false),
                    RoleIdRole = table.Column<int>(type: "int", nullable: true),
                    IdLocalite = table.Column<int>(type: "int", nullable: false),
                    LocaliteIdLocalite = table.Column<int>(type: "int", nullable: true),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NomUtilisateur = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotDePasse = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.IdUtilisateur);
                    table.ForeignKey(
                        name: "FK_Utilisateurs_Localites_LocaliteIdLocalite",
                        column: x => x.LocaliteIdLocalite,
                        principalTable: "Localites",
                        principalColumn: "IdLocalite");
                    table.ForeignKey(
                        name: "FK_Utilisateurs_Roles_RoleIdRole",
                        column: x => x.RoleIdRole,
                        principalTable: "Roles",
                        principalColumn: "IdRole");
                });

            migrationBuilder.CreateTable(
                name: "Evaluation",
                columns: table => new
                {
                    IdEvaluation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Note = table.Column<float>(type: "real", nullable: false),
                    Commentaire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateEvaluation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUtilisateur = table.Column<int>(type: "int", nullable: false),
                    UtilisateurIdUtilisateur = table.Column<int>(type: "int", nullable: true),
                    IdSessionFormation = table.Column<int>(type: "int", nullable: false),
                    SessionFormationIdSessionFormation = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluation", x => x.IdEvaluation);
                    table.ForeignKey(
                        name: "FK_Evaluation_SessionFormations_SessionFormationIdSessionFormation",
                        column: x => x.SessionFormationIdSessionFormation,
                        principalTable: "SessionFormations",
                        principalColumn: "IdSessionFormation");
                    table.ForeignKey(
                        name: "FK_Evaluation_Utilisateurs_UtilisateurIdUtilisateur",
                        column: x => x.UtilisateurIdUtilisateur,
                        principalTable: "Utilisateurs",
                        principalColumn: "IdUtilisateur");
                });

            migrationBuilder.CreateTable(
                name: "Inscription",
                columns: table => new
                {
                    IdInscription = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateInscription = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Statut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdSessionFormation = table.Column<int>(type: "int", nullable: false),
                    SessionFormationIdSessionFormation = table.Column<int>(type: "int", nullable: true),
                    IdUtilisateur = table.Column<int>(type: "int", nullable: false),
                    UtilisateurIdUtilisateur = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscription", x => x.IdInscription);
                    table.ForeignKey(
                        name: "FK_Inscription_SessionFormations_SessionFormationIdSessionFormation",
                        column: x => x.SessionFormationIdSessionFormation,
                        principalTable: "SessionFormations",
                        principalColumn: "IdSessionFormation");
                    table.ForeignKey(
                        name: "FK_Inscription_Utilisateurs_UtilisateurIdUtilisateur",
                        column: x => x.UtilisateurIdUtilisateur,
                        principalTable: "Utilisateurs",
                        principalColumn: "IdUtilisateur");
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
                    UtilisateurIdUtilisateur = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paniers", x => x.IdPanier);
                    table.ForeignKey(
                        name: "FK_Paniers_Utilisateurs_UtilisateurIdUtilisateur",
                        column: x => x.UtilisateurIdUtilisateur,
                        principalTable: "Utilisateurs",
                        principalColumn: "IdUtilisateur");
                });

            migrationBuilder.CreateTable(
                name: "Ajouts",
                columns: table => new
                {
                    IdPanier = table.Column<int>(type: "int", nullable: false),
                    IdFormation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ajouts", x => x.IdPanier);
                    table.ForeignKey(
                        name: "FK_Ajouts_Formations_IdFormation",
                        column: x => x.IdFormation,
                        principalTable: "Formations",
                        principalColumn: "IdFormation",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ajouts_Paniers_IdPanier",
                        column: x => x.IdPanier,
                        principalTable: "Paniers",
                        principalColumn: "IdPanier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ajouts_IdFormation",
                table: "Ajouts",
                column: "IdFormation");

            migrationBuilder.CreateIndex(
                name: "IX_Detentions_IdPermission",
                table: "Detentions",
                column: "IdPermission");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluation_SessionFormationIdSessionFormation",
                table: "Evaluation",
                column: "SessionFormationIdSessionFormation");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluation_UtilisateurIdUtilisateur",
                table: "Evaluation",
                column: "UtilisateurIdUtilisateur");

            migrationBuilder.CreateIndex(
                name: "IX_Inscription_SessionFormationIdSessionFormation",
                table: "Inscription",
                column: "SessionFormationIdSessionFormation");

            migrationBuilder.CreateIndex(
                name: "IX_Inscription_UtilisateurIdUtilisateur",
                table: "Inscription",
                column: "UtilisateurIdUtilisateur");

            migrationBuilder.CreateIndex(
                name: "IX_Localites_SessionFormationIdSessionFormation",
                table: "Localites",
                column: "SessionFormationIdSessionFormation");

            migrationBuilder.CreateIndex(
                name: "IX_Paniers_UtilisateurIdUtilisateur",
                table: "Paniers",
                column: "UtilisateurIdUtilisateur");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionRole_RolesIdRole",
                table: "PermissionRole",
                column: "RolesIdRole");

            migrationBuilder.CreateIndex(
                name: "IX_Planifications_IdHeure",
                table: "Planifications",
                column: "IdHeure");

            migrationBuilder.CreateIndex(
                name: "IX_SessionFormations_FormationIdFormation",
                table: "SessionFormations",
                column: "FormationIdFormation");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_LocaliteIdLocalite",
                table: "Utilisateurs",
                column: "LocaliteIdLocalite");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_RoleIdRole",
                table: "Utilisateurs",
                column: "RoleIdRole");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ajouts");

            migrationBuilder.DropTable(
                name: "Detentions");

            migrationBuilder.DropTable(
                name: "Evaluation");

            migrationBuilder.DropTable(
                name: "Inscription");

            migrationBuilder.DropTable(
                name: "PermissionRole");

            migrationBuilder.DropTable(
                name: "Planifications");

            migrationBuilder.DropTable(
                name: "Paniers");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Heures");

            migrationBuilder.DropTable(
                name: "Utilisateurs");

            migrationBuilder.DropTable(
                name: "Localites");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "SessionFormations");

            migrationBuilder.DropTable(
                name: "Formations");
        }
    }
}
