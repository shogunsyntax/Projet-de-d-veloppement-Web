using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApplication.Models{
    public class Appartenir
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required int CategorieId { get; set; }
    public required int ProduitId{get;set;}
     public ICollection<Categorie> Categorie{get;set;} = new List<Categorie>();
      public ICollection<Produit> Produit{get;set;} = new List<Produit>();
}
}
