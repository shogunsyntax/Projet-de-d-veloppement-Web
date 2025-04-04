using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApplication.Models{
    public class Categorie
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public  int CategorieId { get; set; }

    [Required(ErrorMessage = "Le nom de la catégorie est obligatoire.")]
    [StringLength(50, ErrorMessage = "Le nom de la catégorie ne peut pas dépasser 50 caractères.")]
    public required string NomCategorie { get; set; }
}
}
