using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItFormationCentre.Models
{
    public class Paiement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPaiement { get; set; }

        public decimal Montant { get; set; }

        public string? TypePaiement { get; set; }

        public DateTime DatePaiement { get; set; }

        public string? StatutPaiement { get; set; }

        public int IdPanier { get; set; }
        public Panier? Panier { get; set; }
    }
}
