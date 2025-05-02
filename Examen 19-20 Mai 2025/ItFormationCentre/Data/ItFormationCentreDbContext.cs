using Microsoft.EntityFrameworkCore;
using ItFormationCentre.Models;

namespace ItFormationCentre.Data
{
    public class ItFormationCentreDbContext : DbContext
    {
        public ItFormationCentreDbContext(DbContextOptions<ItFormationCentreDbContext> options)
            : base(options) { }

        // DbSets
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Localite> Localites { get; set; }
        public DbSet<Adresse> Adresses { get; set; }
        public DbSet<Stagiaire> Stagiaires { get; set; }
        public DbSet<Formateur> Formateurs { get; set; }
        public DbSet<Inscription> Inscriptions { get; set; }
        public DbSet<Paiement> Paiements { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<SessionFormation> SessionsFormation { get; set; }
        public DbSet<Formation> Formations { get; set; }
        public DbSet<Panier> Paniers { get; set; }
        public DbSet<Ajouter> Ajouts { get; set; }
        public DbSet<Plannifier> Plannifications { get; set; }
        public DbSet<Detenir> Detentions { get; set; }
        public DbSet<Heure> Heures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --- TPH (Table per Hierarchy) Configuration ---

            // Configurer la table unique pour tous les Utilisateurs (Stagiaire, Formateur, etc.)
            modelBuilder.Entity<Utilisateur>()
                .ToTable("Utilisateurs")
                .HasDiscriminator<string>("UserType")  // Ajouter une colonne discriminant le type
                .HasValue<Utilisateur>("Utilisateur")
                .HasValue<Stagiaire>("Stagiaire")
                .HasValue<Formateur>("Formateur");

            // --- Relations Utilisateur ---
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

            // --- Inscription ---
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

            // --- Paiement ---
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

            // --- Evaluation ---
            modelBuilder.Entity<Evaluation>()
                .HasOne(e => e.Formateur)
                .WithMany()
                .HasForeignKey(e => e.IdUtilisateurFormateur)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Evaluation>()
                .HasOne(e => e.Stagiaire)
                .WithMany(u => u.EvaluationsStagiaire)
                .HasForeignKey(e => e.IdUtilisateurStagiaire)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Evaluation>()
                .HasOne(e => e.SessionFormation)
                .WithMany()
                .HasForeignKey(e => e.IdSessionFormation)
                .OnDelete(DeleteBehavior.Restrict);

            // --- SessionFormation ---
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

            // --- Panier ---
            modelBuilder.Entity<Panier>()
                .HasOne(p => p.Utilisateur)
                .WithMany()
                .HasForeignKey(p => p.IdUtilisateur)
                .OnDelete(DeleteBehavior.Restrict);

            // --- Ajouter (Panier <-> Formation) ---
            modelBuilder.Entity<Ajouter>()
                .HasKey(a => new { a.IdPanier, a.IdFormation });

            modelBuilder.Entity<Ajouter>()
                .HasOne(a => a.Panier)
                .WithMany(p => p.Ajouts)
                .HasForeignKey(a => a.IdPanier)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ajouter>()
                .HasOne(a => a.Formation)
                .WithMany(f => f.Paniers)
                .HasForeignKey(a => a.IdFormation)
                .OnDelete(DeleteBehavior.Restrict);

            // --- Plannifier (SessionFormation <-> Heure) ---
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

            // --- Detenir (Role <-> Permission) ---
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
