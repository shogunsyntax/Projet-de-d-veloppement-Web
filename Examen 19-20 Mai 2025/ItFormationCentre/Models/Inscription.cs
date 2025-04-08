using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItFormationCentre.Models
{
    public class Inscription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdInscription { get; set; }

        public DateTime DateInscription { get; set; }

        public string? Statut { get; set; }

        //public int IdPanier { get; set; }
        //public Panier? Panier { get; set; }

        public int IdSessionFormation { get; set; }
        public SessionFormation? SessionFormation { get; set; }
        public int IdUtilisateur{ get; set; }
        public Utilisateur? Utilisateur { get; set; }
    }
}
