using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApplication.Models{
    public class Appartenir
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public  int IdCategorie { get; set; }
    public int? IdProduit{get;set;}
    public Categorie? Categorie{get;set;} 
    public Produit? Produit{get;set;}
}
}
