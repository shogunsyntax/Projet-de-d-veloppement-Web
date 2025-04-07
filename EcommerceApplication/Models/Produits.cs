using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApplication.Models
{
    public class Produit
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProduit { get; set; }
        [Required(ErrorMessage = "Le nom du produit est obligatoire.")]
        [StringLength(50, ErrorMessage = "Le nom du produit ne peut pas dépasser 50 caractères.")]

        public required int IdTVA{get;set;}
        public required string NomProduit { get; set; }
        [Required(ErrorMessage = "La description du produit est obligatoire.")]
        [StringLength(50, ErrorMessage = "La description du produit ne peut pas dépasser 50 caractères.")]
        public required string DescriptionProduit { get; set; }

        [Required(ErrorMessage = "Le prix est obligatoire.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0, 9999999999999999.99)]
        public required decimal Prix { get; set; }
        [Required(ErrorMessage = "Le stock est obligatoire.")]
        [Range(0, int.MaxValue, ErrorMessage = "Entrer un nombre valide")]
        [StringLength(50, ErrorMessage = "Le stock n'est pas valide.")]
        public required int Stock { get; set; }
        [Required(ErrorMessage = "La categorie est obligatoire.")]
        [Range(0, int.MaxValue, ErrorMessage = "Entrer un nombre valide")]
        [StringLength(50, ErrorMessage = "La categorie n'est pas valide.")]
        public  int IdCategorie { get; set; }
        [Required(ErrorMessage = "La categorie est obligatoire.")]
        
        public  Categorie? Categorie { get; set; }
        [Required(ErrorMessage = "L'image est obligatoire.")]
        [Url(ErrorMessage = "L'Image n'est pas valide.")]
        public required string Image { get; set; }
    }
}
