using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApplication.Models{
    public class Commande
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
    public required int Id { get; set; }
    [Range(0, 9999999999999999.99)]
    public int UtilisateurId { get; set; }
    [Range(0, 9999999999999999.99)]
    public required Utilisateur Utilisateur { get; set; }
    
}
}