using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItFormationCentre.Models
{
    public class Adresse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAdresse { get; set; }

        [Required]
        [StringLength(100)]
        public string Rue { get; set; }

        [Required]
        [StringLength(50)]
        public string Pays { get; set; }

        public int IdLocalite { get; set; }
    
        public Localite? Localite { get; set; }

        public int IdUtilisateur { get; set; }
        public Utilisateur? Utilisateur { get; set; }
    }
}