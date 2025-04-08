using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ItFormationCentre.Models
{
    public class Ajouter
    {
       [Key]
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Required]
        public int IdPanier { get; set; }
        public Panier Panier { get; set; }

        [Required]
        public int IdFormation { get; set; }
        public Formation Formation { get; set; }
    }
}
