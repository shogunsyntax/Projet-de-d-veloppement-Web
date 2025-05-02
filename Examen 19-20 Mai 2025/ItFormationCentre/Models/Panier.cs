using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace ItFormationCentre.Models
{
    public class Panier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPanier { get; set; }

        [ForeignKey("Utilisateur")]
        public int IdUtilisateur { get; set; }

        // Propriété de navigation
        public Utilisateur? Utilisateur { get; set; }

        // Propriété de navigation pour les ajouts au panier
        public ICollection<Ajouter> Ajouts { get; set; } = new List<Ajouter>();

        // Autres propriétés du panier
        public DateTime DateCreation { get; set; }
        public decimal Total { get; set; }
    }
}