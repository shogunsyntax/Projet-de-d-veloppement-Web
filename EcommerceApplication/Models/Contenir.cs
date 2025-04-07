using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApplication.Models{
    public class Contenir
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
   public required int IdCommande { get; set; }
    public required Commande Commande { get; set; }
    public required int IdProduit { get; set; }
    public required Produit Produit { get; set; }
    [Range(0,999999)]
    public required int Quantite { get; set; }
  
}
}