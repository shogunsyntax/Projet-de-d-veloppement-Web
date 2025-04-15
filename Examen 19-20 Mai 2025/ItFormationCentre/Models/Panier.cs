using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItFormationCentre.Models
{
    public class Panier
    {
      [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPanier { get; set; }

        public DateTime DateCreation { get; set; }
        public DateTime? DateValidation { get; set; }
        public string? Statut { get; set; }
        public decimal Total { get; set; }
        public string? MethodePaiement { get; set; }
        public string? CodePromo { get; set; }
        public decimal? Reduction { get; set; }
        public decimal Tva { get; set; }
        public decimal NetAPayer { get; set; }

        public int IdUtilisateur { get; set; }
        public Utilisateur? Utilisateur { get; set; }

        public ICollection<Ajouter> Ajouts { get; set; } 

     
    }
}
