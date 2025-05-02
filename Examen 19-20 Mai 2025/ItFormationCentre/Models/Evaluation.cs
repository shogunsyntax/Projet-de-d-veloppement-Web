using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItFormationCentre.Models
{
    public class Evaluation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEvaluation { get; set; }

        public int IdUtilisateurFormateur { get; set; }
        public int IdUtilisateurStagiaire { get; set; }
        public int IdSessionFormation { get; set; }

        [Range(0, 20)]
        public decimal Note { get; set; }

        public string? Commentaire { get; set; }
        public DateTime DateEvaluation { get; set; }

        [ForeignKey("IdUtilisateurFormateur")]
        public Formateur? Formateur { get; set; }

        [ForeignKey("IdUtilisateurStagiaire")]
        public Stagiaire? Stagiaire { get; set; }

        [ForeignKey("IdSessionFormation")]
        public SessionFormation? SessionFormation { get; set; }
    }
}
