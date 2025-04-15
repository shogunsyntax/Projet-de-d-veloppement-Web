using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItFormationCentre.Models
{
    public class Evaluation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEvaluation { get; set; }

    [ForeignKey("Formateur")]
    public int IdUtilisateurFormateur { get; set; }

    [ForeignKey("Stagiaire")]
    public int IdUtilisateurStagiaire { get; set; }

    [ForeignKey("SessionFormation")]
    public int IdSessionFormation { get; set; }
    [Range(0,20)]
    public decimal Note { get; set; }
    public string Commentaire { get; set; }
    public DateTime DateEvaluation { get; set; }

    public  Formateur Formateur { get; set; }
    public Stagiaire Stagiaire { get; set; }
    public  SessionFormation SessionFormation { get; set; }
    }
}
