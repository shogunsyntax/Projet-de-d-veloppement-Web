using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApplication.Models{
    public class Paiement{
        
    public required int Id { get; set; }
    public required int CommandeId { get; set; }
    public required Commande Commande { get; set; }
    public decimal Montant { get; set; }
    public required string Statut { get; set; } 
    public required string Methode { get; set; }
    }
}