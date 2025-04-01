// Importation du namespace EF Core pour les classes DbContext, DbSet, ...
using Microsoft.EntityFrameworkCore;

// Importation du namespace des modèles de l'application
using EcommerceApplication.Models;

namespace EcommerceApplication.Data
{
    // Définition du contexte de db principal de l'application (on hérite de DbContext d'EF Core)
    public class ECommerceDbContext : DbContext
    {
        // Déclarations des tables (DbSet) — chaque DbSet représente une table en base de données
        public DbSet<Appartenir> Appartenir { get; set; } // Table de jointure entre Produit et Categorie
        public DbSet<PanierProduit> Ajouter { get; set; }       // Table de jointure entre Panier et Produit
        public DbSet<Categorie> Categorie { get; set; }   // Table catégories de produits
        public DbSet<Commande> Commande { get; set; }     // Table commandes
        public DbSet<CommandeProduit> Contenir { get; set; }     // Table de jointure entre Commande et Produit
        public DbSet<Detenir> Detenir { get; set; }       // Table de jointure entre Role et Permission
        public DbSet<Localite> Localite { get; set; }     // Table localité
        public DbSet<Panier> Panier { get; set; }         // Table panier
        public DbSet<Permission> Permission { get; set; } // Table permission
        public DbSet<Produit> Produit { get; set; }       // Table produit
        public DbSet<Role> Role { get; set; }             // Table rôle
        public DbSet<TVA> TVA { get; set; }               // Table TVA
        public DbSet<Utilisateur> Utilisateur { get; set; } // Table utilisateur

        // Constructeur du DbContext - EF utilise "options" pour la connexion à la DB (configurée ligne ~7/8 dans Program.cs)
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options) { }

        // Méthode exécutée lors de la création du modèle de données — ici, on configure les relations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ----- Définition des clés primaires composites pour les tables de jointure -----

            modelBuilder.Entity<Appartenir>().HasKey(a => new { a.CategorieId, a.ProduitId });
            modelBuilder.Entity<PanierProduit>().HasKey(a => new { a.PanierId, a.ProduitId });
            modelBuilder.Entity<CommandeProduit>().HasKey(c => new { c.CommandeId, c.ProduitId });
            modelBuilder.Entity<Detenir>().HasKey(d => new { d.PermissionId, d.RoleId });

            // ----- Relations Utilisateur <-> Role -----
            modelBuilder.Entity<Utilisateur>()
                .HasOne(u => u.Role)                     // Un utilisateur a un rôle
                .WithMany(r => r.Utilisateur)            // Un rôle peut être lié à plusieurs utilisateurs
                .HasForeignKey(u => u.IdRole);           // On pointe sur la clé étrangère dans Utilisateur

            // ----- Relations Utilisateur <-> Localite -----
            modelBuilder.Entity<Utilisateur>()
                .HasOne(u => u.Localite)
                .WithMany(l => l.Utilisateur)
                .HasForeignKey(u => u.IdLocalite);

            // ----- Relations Produit <-> TVA -----
            modelBuilder.Entity<Produit>()
                .HasOne<TVA>()                           // Un produit a un seul taux de TVA
                .WithMany()                              // Pourquoi vide ? (PN dans P)
                .HasForeignKey(p => p.TvaId);

            // ----- Relations Panier <-> Utilisateur -----
            modelBuilder.Entity<Panier>()
                .HasOne<Utilisateur>()
                .WithMany()
                .HasForeignKey(p => p.UtilisateurId)
                .OnDelete(DeleteBehavior.ClientCascade);

            // ----- Relations Commande <-> Panier -----
            modelBuilder.Entity<Commande>()
                .HasOne<Panier>()
                .WithMany()
                .HasForeignKey(c => c.PanierId)
                .OnDelete(DeleteBehavior.ClientCascade);

            // ----- Relations Commande <-> Utilisateur -----
            modelBuilder.Entity<Commande>()
                .HasOne<Utilisateur>()
                .WithMany()
                .HasForeignKey(c => c.UtilisateurId);

            // ----- Relations Contenir <-> Produit & Commande -----
            modelBuilder.Entity<CommandeProduit>()
                .HasOne(c => c.Produit)
                .WithMany()
                .HasForeignKey(c => c.ProduitId);

            modelBuilder.Entity<CommandeProduit>()
                .HasOne(c => c.Commande)
                .WithMany()
                .HasForeignKey(c => c.CommandeId);

            // ----- Relations Appartenir <-> Categorie & Produit -----
            modelBuilder.Entity<Appartenir>()
                .HasOne(a => a.Categorie)
                .WithMany()
                .HasForeignKey(a => a.CategorieId);

            modelBuilder.Entity<Appartenir>()
                .HasOne(a => a.Produit)
                .WithMany()
                .HasForeignKey(a => a.ProduitId);

            // ----- Relations Ajouter <-> Panier & Produit -----
            modelBuilder.Entity<PanierProduit>()
                .HasOne(a => a.Panier)
                .WithMany()
                .HasForeignKey(a => a.PanierId);

            modelBuilder.Entity<PanierProduit>()
                .HasOne(a => a.Produit)
                .WithMany()
                .HasForeignKey(a => a.ProduitId);

            // ----- Relations Detenir <-> Role & Permission -----
            modelBuilder.Entity<Detenir>()
                .HasOne(d => d.Role)
                .WithMany()
                .HasForeignKey(d => d.RoleId);

            modelBuilder.Entity<Detenir>()
                .HasOne(d => d.Permission)
                .WithMany()
                .HasForeignKey(d => d.PermissionId);
        }
    }
}