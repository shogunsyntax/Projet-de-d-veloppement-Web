// Importation du namespace EF Core pour les classes DbContext, DbSet, ...
using Microsoft.EntityFrameworkCore;

// Importation du namespace des modèles de l'application
using ItFormationCentre.Models;

namespace ItFormationCentre.Data
{
    // Définition du contexte de db principal de l'application (on hérite de DbContext d'EF Core)

    public class ItFormationCentreDbContext : DbContext

    { public ItFormationCentreDbContext(DbContextOptions<ItFormationCentreDbContext> options)
            : base(options) // Passer les options au constructeur de la classe de base
        {
        }

    public DbSet<Utilisateur> Utilisateurs { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<Localite> Localites { get; set; }
    public DbSet<Stagiaire> Stagiaires { get; set; }
    public DbSet<Formateur> Formateurs { get; set; }
    public DbSet<Inscription> Inscriptions { get; set; }
    public DbSet<Paiement> Paiements { get; set; }
    public DbSet<Evaluation> Evaluations { get; set; }
    public DbSet<SessionFormation> SessionsAnimees { get; set; }
    public DbSet<Formation> Formations { get; set; }
    public DbSet<Panier> Paniers { get; set; }
   public DbSet<Heure> Heures { get; set; }
    public DbSet<Detenir> Detenirs { get; set; }
    public DbSet<Plannifier> Plannifier { get; set; }
    public DbSet<Ajouter> Ajouts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuration des relations
        modelBuilder.Entity<Utilisateur>()
            .HasOne(u => u.Role)
            .WithMany(r => r.Utilisateurs)
            .HasForeignKey(u => u.IdRole)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Utilisateur>()
            .HasOne(u => u.Localite)
            .WithMany(l => l.Utilisateurs)
            .HasForeignKey(u => u.IdLocalite)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Utilisateur>()
            .HasOne(u => u.Adresse)
            .WithMany()
            .HasForeignKey(u => u.IdAdresse)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Stagiaire>()
            .HasBaseType<Utilisateur>();

        modelBuilder.Entity<Formateur>()
            .HasBaseType<Utilisateur>()
           ;

        modelBuilder.Entity<Inscription>()
            .HasOne(i => i.Stagiaire)
            .WithMany()
            .HasForeignKey(i => i.IdUtilisateur)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Inscription>()
            .HasOne(i => i.SessionFormation)
            .WithMany(s => s.Inscriptions)
            .HasForeignKey(i => i.IdSessionFormation)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Paiement>()
            .HasOne(p => p.Inscription)
            .WithMany()
            .HasForeignKey(p => p.IdInscription)
            .OnDelete(DeleteBehavior.Restrict);

         modelBuilder.Entity<Paiement>()
            .HasOne(p => p.Panier)
            .WithMany()
            .HasForeignKey(p => p.IdPanier)
            .OnDelete(DeleteBehavior.Restrict);

      modelBuilder.Entity<Evaluation>()
    .HasOne(e => e.Formateur)
    .WithMany() // Si un formateur peut avoir plusieurs évaluations
    .HasForeignKey(e => e.IdUtilisateurFormateur)
    .OnDelete(DeleteBehavior.Restrict);

modelBuilder.Entity<Evaluation>()
    .HasOne(e => e.Stagiaire)
    .WithMany(u => u.EvaluationsStagiaire) // Lien avec la collection dans Utilisateur
    .HasForeignKey(e => e.IdUtilisateurStagiaire)
    .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<Evaluation>()
    .HasOne(e => e.SessionFormation)
    .WithMany() // Si une session peut avoir plusieurs évaluations
    .HasForeignKey(e => e.IdSessionFormation)
    .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<SessionFormation>()
            .HasOne(s => s.Localite)
            .WithMany(l => l.SessionsFormation)
            .HasForeignKey(s => s.IdLocalite)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<SessionFormation>()
            .HasOne(s => s.Formateur)
            .WithMany()
            .HasForeignKey(s => s.IdUtilisateur)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<SessionFormation>()
            .HasOne(s => s.Formation)
            .WithMany(f => f.SessionsFormation)
            .HasForeignKey(s => s.IdFormation)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Panier>()
            .HasOne(p => p.Utilisateur)
            .WithMany()
            .HasForeignKey(p => p.IdUtilisateur)
            .OnDelete(DeleteBehavior.Restrict);

       modelBuilder.Entity<Ajouter>()
    .HasKey(a => new { a.IdPanier, a.IdFormation }); // Clé composite

modelBuilder.Entity<Ajouter>()
    .HasOne(a => a.Panier)
    .WithMany(p => p.Ajouts) // Assurez-vous que cela correspond à la propriété de collection dans Panier
    .HasForeignKey(a => a.IdPanier)
    .OnDelete(DeleteBehavior.Restrict);

modelBuilder.Entity<Ajouter>()
    .HasOne(a => a.Formation)
    .WithMany(f => f.Paniers) // Assurez-vous que cela correspond à la propriété de collection dans Formation
    .HasForeignKey(a => a.IdFormation)
    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Plannifier>()
            .HasKey(p => new { p.IdSessionFormation, p.IdHeure });

        modelBuilder.Entity<Plannifier>()
            .HasOne(p => p.SessionFormation)
            .WithMany(s => s.Heures)
            .HasForeignKey(p => p.IdSessionFormation)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Plannifier>()
            .HasOne(p => p.Heure)
            .WithMany(h => h.SessionsFormation)
            .HasForeignKey(p => p.IdHeure)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Detenir>()
            .HasKey(d => new { d.IdRole, d.IdPermission });

        modelBuilder.Entity<Detenir>()
            .HasOne(d => d.Role)
            .WithMany(r => r.Permissions)
            .HasForeignKey(d => d.IdRole)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Detenir>()
            .HasOne(d => d.Permission)
            .WithMany(p => p.Roles)
            .HasForeignKey(d => d.IdPermission)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
}