// Importation du namespace EF Core pour les classes DbContext, DbSet, ...
using Microsoft.EntityFrameworkCore;

// Importation du namespace des modèles de l'application
using ItFormationCentre.Models;

namespace ItFormationCentre.Data
{
    // Définition du contexte de db principal de l'application (on hérite de DbContext d'EF Core)

    public class ItFormationCentreDbContext : DbContext

    {

       // === Tables principales ===
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Localite> Localites { get; set; }
        public DbSet<Formation> Formations { get; set; }
        public DbSet<SessionFormation> SessionFormations { get; set; }
        public DbSet<Panier> Paniers { get; set; }
        public DbSet<Heure> Heures { get; set; }

        // === Tables intermédiaires ===
        public DbSet<Detenir> Detentions { get; set; }
        public DbSet<Ajouter> Ajouts { get; set; }
        public DbSet<Planifier> Planifications { get; set; }

     
    public ItFormationCentreDbContext(DbContextOptions<ItFormationCentreDbContext> options) : base(options) { }
   protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ----- Table Detenir -----
            modelBuilder.Entity<Detenir>()
                .HasOne(d => d.Role)
                .WithMany()
                .HasForeignKey(d => d.IdRole);

            modelBuilder.Entity<Detenir>()
                .HasOne(d => d.Permission)
                .WithMany()
                .HasForeignKey(d => d.IdPermission);

            // ----- Table Ajouter -----
            modelBuilder.Entity<Ajouter>()
                .HasOne(a => a.Panier)
                .WithMany()
                .HasForeignKey(a => a.IdPanier);

            modelBuilder.Entity<Ajouter>()
                .HasOne(a => a.Formation)
                .WithMany()
                .HasForeignKey(a => a.IdFormation);

            // ----- Table Planifier -----
            modelBuilder.Entity<Planifier>()
                .HasOne(p => p.SessionFormation)
                .WithMany()
                .HasForeignKey(p => p.IdSessionFormation);

            modelBuilder.Entity<Planifier>()
                .HasOne(p => p.Heure)
                .WithMany()
                .HasForeignKey(p => p.IdHeure);
        }
    }
}
      

