using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApplication.Models{
    public class Panier
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdPanier { get; set; }
    public int? IdUtilisateur { get; set; }
    public  Utilisateur? Utilisateur { get; set; }

    public DateTime DatePanier {get;set;}
}
}