using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItFormationCentre.Models
{

        public class Ajouter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAjouter { get; set; } // Clé primaire

        [ForeignKey("Panier")]
        public int IdPanier { get; set; } // Clé étrangère vers Panier

        [ForeignKey("Formation")]
        public int IdFormation { get; set; } // Clé étrangère vers Formation

        public Panier Panier { get; set; } // Navigation vers Panier
        public Formation Formation { get; set; } // Navigation vers Formation
    }
}