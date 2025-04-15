using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItFormationCentre.Models
{
    public class Heure
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdHeure { get; set; }

        public TimeSpan HeureDebut { get; set; }
        public TimeSpan HeureFin { get; set; }

        public  ICollection<Plannifier> SessionsFormation { get; set; }

    }
}
