using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ItFormationCentre.Models
{
    public class Local
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLocal { get; set; }

        [Required(ErrorMessage = "Le numéro du local est obligatoire.")]
        [StringLength(100)]
        public required string NumeroLocal { get; set; }

        [Required(ErrorMessage = "La capacité du local est obligatoire.")]
        public required int Capacite { get; set; }
        [Required(ErrorMessage = "La disponibilité du local est obligatoire.")]
        public required string Disponibilite { get; set; } // "Disponible" ou "Occupé"

       

        
    }
}
