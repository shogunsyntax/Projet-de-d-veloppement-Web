using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItFormationCentre.Models
{
    public class Evaluation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEvaluation { get; set; }

        [Range(0, 20)]
        public float Note { get; set; }

        public string? Commentaire { get; set; }

        public DateTime DateEvaluation { get; set; }

        public int IdUtilisateur { get; set; }
        public Utilisateur? Utilisateur { get; set; }

        public int IdSessionFormation { get; set; }
        public SessionFormation? SessionFormation { get; set; }
    }
}
