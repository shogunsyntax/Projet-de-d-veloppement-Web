using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItFormationCentre.Models
{
    public class SessionFormation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSessionFormation { get; set; }
 [ForeignKey("Localite")]
    public int IdLocalite { get; set; }

    [ForeignKey("Formateur")]
    public int IdUtilisateur { get; set; }

    [ForeignKey("Formation")]
    public int IdFormation { get; set; }

    public  Localite Localite { get; set; } 
    public Formateur Formateur { get; set; } 
    public  Formation Formation { get; set; } 
    public  ICollection<Inscription> Inscriptions { get; set; }
    public  ICollection<Plannifier> Heures { get; set; }

     public ICollection<Evaluation> Evaluations { get; set; }

     public ICollection<Local> Locaux { get; set; }
    }
}
