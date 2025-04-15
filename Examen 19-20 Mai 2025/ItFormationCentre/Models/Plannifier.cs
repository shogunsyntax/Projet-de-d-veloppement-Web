using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItFormationCentre.Models
{
    public class Plannifier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]    

        [Required]
        public int IdSessionFormation { get; set; }
        public SessionFormation SessionFormation { get; set; }

        [Required]
        public int IdHeure { get; set; }
        public Heure Heure { get; set; }
    }
}
