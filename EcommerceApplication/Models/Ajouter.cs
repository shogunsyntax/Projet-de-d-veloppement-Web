using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApplication.Models{
    public class Ajouter
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]    
    public int IdPanier { get; set; }
    public Panier? Panier { get; set; }
    public required int IdProduit { get; set; }
    public required Produit Produit { get; set; }
    public required int Quantite { get; set; }
}
}