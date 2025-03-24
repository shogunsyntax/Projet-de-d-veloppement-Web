using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApplication.Models{
    public class PanierProduit
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]    public int PanierId { get; set; }
    public Panier Panier { get; set; }
    public int ProduitId { get; set; }
    public Produit Produit { get; set; }
    public int Quantite { get; set; }
}
}