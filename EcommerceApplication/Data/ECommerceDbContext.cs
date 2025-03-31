using Microsoft.EntityFrameworkCore;
using EcommerceApplication.Models;
namespace EcommerceApplication.Data
{
    public class ECommerceDbContext : DbContext
    {
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Panier> Paniers { get; set; }
        public DbSet<PanierProduit> PaniersProduits { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<CommandeProduit> CommandesProduits { get; set; }
        public DbSet<Paiement> Paiements { get; set; }

        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PanierProduit>().HasKey(pp => new { pp.PanierId, pp.ProduitId });
            modelBuilder.Entity<CommandeProduit>().HasKey(cp => new { cp.CommandeId, cp.ProduitId });
            modelBuilder.Entity<Utilisateur>().HasKey(uu => new{uu.IdUtilisateur,uu.IdRole});
            modelBuilder.Entity<Utilisateur>().HasKey(ul=> new{ul.IdUtilisateur,ul.IdLocalite});
        }
    }
}