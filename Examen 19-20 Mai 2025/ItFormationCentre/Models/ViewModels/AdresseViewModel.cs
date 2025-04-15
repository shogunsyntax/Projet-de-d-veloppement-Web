using System.ComponentModel.DataAnnotations;

namespace ItFormationCentre.ViewModels
{
    public class AdresseViewModel
    {
        public int IdAdresse { get; set; }

        [Required(ErrorMessage = "La rue est requise.")]
        [StringLength(100, ErrorMessage = "La rue ne peut pas dépasser 100 caractères.")]
        public string Rue { get; set; }

        [Required(ErrorMessage = "Le pays est requis.")]
        [StringLength(50, ErrorMessage = "Le pays ne peut pas dépasser 50 caractères.")]
        public string Pays { get; set; }

        public int IdLocalite { get; set; }

        // Propriétés supplémentaires pour les listes déroulantes
        public IEnumerable<Localite> Localites { get; set; }
    }
}