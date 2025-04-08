using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItFormationCentre.Models
{
    public class SessionFormation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSessionFormation { get; set; }

        [Required]
        public DateTime DateDebut { get; set; }

        [Required]
        public DateTime DateFin { get; set; }

        public int NombreParticipant { get; set; }

        [Required]
        public string StatusSession { get; set; }

        // Clé étrangère vers la formation
        public int IdFormation { get; set; }
        public Formation? Formation { get; set; }

        // Relation avec Heures
        //public ICollection<Heure> Heures { get; set; }

        // Relation avec les inscriptions
        public ICollection<Inscription> Inscriptions { get; set; }

        // Relation avec les évaluations
        public ICollection<Evaluation> Evaluations { get; set; }

        public ICollection<Localite> Localites{get;set;}
    }
}
