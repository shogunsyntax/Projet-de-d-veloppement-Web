using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItFormationCentre.Models
{
    public class Adresse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAdresse { get; set; }

        [Required(ErrorMessage = "La rue est requise.")]
        [StringLength(100, ErrorMessage = "La rue ne peut pas dépasser 100 caractères.")]
        public string Rue { get; set; }

        [Required(ErrorMessage = "Le pays est requis.")]
        [StringLength(50, ErrorMessage = "Le pays ne peut pas dépasser 50 caractères.")]
        public string Pays { get; set; }

        [Required(ErrorMessage = "La ville est requise.")]
        [StringLength(50, ErrorMessage = "La ville ne peut pas dépasser 50 caractères.")]
        public string Ville { get; set; }

        [ForeignKey("Localite")]
        public int IdLocalite { get; set; }

        // Propriété de navigation
        public Localite? Localite { get; set; }
    }
}