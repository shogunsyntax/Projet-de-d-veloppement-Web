using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItFormationCentre.Models
{
    public class Stagiaire : Utilisateur
    {
        [Required]
        public string Niveau { get; set; }

       
    }
}
