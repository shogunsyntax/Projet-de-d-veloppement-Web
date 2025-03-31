using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApplication.Models{
    public class Commande
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
    public int CommandeId { get; set; }

    public required int PanierId{get;set;}
    public int UtilisateurId { get; set; }
    public required Utilisateur Utilisateur { get; set; }
    public required DateTime DateCommande { get; set; } 
    public required decimal Total { get; set; }
    public required string Statut { get; set; } 
    
}
}