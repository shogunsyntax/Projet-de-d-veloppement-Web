using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItFormationCentre.Models
{
    public class Formateur : Utilisateur
    {
        [Required]
        public string Specialite { get; set; }

        [Range(0, 50)]
        public int Experience { get; set; }

        public ICollection<SessionFormation> SessionsAnimees { get; set; }

    }
}
