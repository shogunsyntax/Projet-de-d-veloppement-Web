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

        public DbSet<Ajouter> Ajouter { get; set; }       // Table de jointure entre Panier et Produit

        public DbSet<Categorie> Categorie { get; set; }   // Table catégories de produits

        public DbSet<Commande> Commande { get; set; }     // Table commandes

        public DbSet<Contenir> Contenir { get; set; }     // Table de jointure entre Commande et Produit

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


            modelBuilder.Entity<Appartenir>().HasKey(a => new { a.IdCategorie, a.IdProduit });

            modelBuilder.Entity<Ajouter>().HasKey(a => new { a.IdPanier, a.IdProduit });

            modelBuilder.Entity<Contenir>().HasKey(c => new { c.IdCommande, c.IdProduit });

            modelBuilder.Entity<Detenir>().HasKey(d => new { d.IdPermission, d.IdRole });


            // ----- Relations Utilisateur <-> Role -----

            modelBuilder.Entity<Utilisateur>()

                .HasOne(u => u.Role)                     // Un utilisateur a un rôle

                .WithMany(r => r.Utilisateur)            // Un rôle peut être lié à plusieurs utilisateurs

                .HasForeignKey(u => u.IdRole)
                .OnDelete(DeleteBehavior.Restrict);          // On pointe sur la clé étrangère dans Utilisateur


            // ----- Relations Utilisateur <-> Localite -----

            modelBuilder.Entity<Utilisateur>()

                .HasOne(u => u.Localite)

                .WithMany(l => l.Utilisateur)

                .HasForeignKey(u => u.IdLocalite)
                .OnDelete(DeleteBehavior.Restrict);


            // ----- Relations Produit <-> TVA -----

            modelBuilder.Entity<Produit>()

                .HasOne<TVA>()                           // Un produit a un seul taux de TVA

                .WithMany()                              // Pourquoi vide ? (PN dans P)

                .HasForeignKey(p => p.IdTVA)
                .OnDelete(DeleteBehavior.Restrict);


            // ----- Relations Panier <-> Utilisateur -----

            modelBuilder.Entity<Panier>()

                .HasOne<Utilisateur>()

                .WithMany()

                .HasForeignKey(p => p.IdUtilisateur)
                .OnDelete(DeleteBehavior.Restrict);


            // ----- Relations Commande <-> Panier -----

            modelBuilder.Entity<Commande>()

                .HasOne<Panier>()

                .WithMany()

                .HasForeignKey(c => c.IdPanier)
                .OnDelete(DeleteBehavior.Restrict);


            // ----- Relations Commande <-> Utilisateur -----

            modelBuilder.Entity<Commande>()

                .HasOne<Utilisateur>()

                .WithMany()

                .HasForeignKey(c => c.IdUtilisateur)
                .OnDelete(DeleteBehavior.Restrict);


            // ----- Relations Contenir <-> Produit & Commande -----

            modelBuilder.Entity<Contenir>()

                .HasOne(c => c.Produit)

                .WithMany()

                .HasForeignKey(c => c.IdProduit)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Contenir>()

                .HasOne(c => c.Commande)

                .WithMany()

                .HasForeignKey(c => c.IdCommande)
                .OnDelete(DeleteBehavior.Restrict);


            // ----- Relations Appartenir <-> Categorie & Produit -----

            modelBuilder.Entity<Appartenir>()

                .HasOne(a => a.Categorie)

                .WithMany()

                .HasForeignKey(a => a.IdCategorie)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Appartenir>()

                .HasOne(a => a.Produit)

                .WithMany()

                .HasForeignKey(a => a.IdProduit)
                .OnDelete(DeleteBehavior.Restrict);


            // ----- Relations Ajouter <-> Panier & Produit -----

            modelBuilder.Entity<Ajouter>()

                .HasOne(a => a.Panier)

                .WithMany()

                .HasForeignKey(a => a.IdPanier)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Ajouter>()

                .HasOne(a => a.Produit)

                .WithMany()

                .HasForeignKey(a => a.IdProduit)
                .OnDelete(DeleteBehavior.Restrict);


            // ----- Relations Detenir <-> Role & Permission -----

            modelBuilder.Entity<Detenir>()

                .HasOne(d => d.Role)

                .WithMany()

                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Detenir>()

                .HasOne(d => d.Permission)

                .WithMany()

                .HasForeignKey(d => d.IdPermission)
                .OnDelete(DeleteBehavior.Restrict);

        }

    }

}