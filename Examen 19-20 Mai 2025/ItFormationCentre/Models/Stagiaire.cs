using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ItFormationCentre.Models
{
    public class Stagiaire : Utilisateur
    {
        [Required]
        public string? CarteEtudiant { get; set; }

        public ICollection<Evaluation> Evaluations { get; set; } = new List<Evaluation>();


       
    }
}
