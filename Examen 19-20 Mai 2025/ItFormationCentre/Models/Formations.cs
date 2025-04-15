using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItFormationCentre.Models
{
    public class Formation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdFormation { get; set; }

        [Required(ErrorMessage = "Le nom de la formation est obligatoire.")]
        public required string NomFormation { get; set; }

        public string? Description { get; set; }

        [Required]
        public decimal Prix { get; set; }

        [Required]
        public int Duree { get; set; } // en heures ou jours selon la convention

        // Liste des sessions de cette formation
        public  ICollection<SessionFormation> SessionsFormation { get; set; } // Assurez-vous que cette propriété existe

         public  ICollection<Ajouter> Paniers { get; set; }
    }
}
