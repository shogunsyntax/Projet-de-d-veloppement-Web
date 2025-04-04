using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApplication.Models{
    public class Panier
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PanierId { get; set; }
    public int? UtilisateurId { get; set; }
    public  Utilisateur? Utilisateur { get; set; }

    public DateTime DatePanier {get;set;}
}
}