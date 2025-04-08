using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ItFormationCentre.Models
{
    public class Localite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLocalite { get; set; }

        [Required(ErrorMessage = "Le nom de la localité est obligatoire.")]
        [StringLength(100)]
        public required string NomLocalite { get; set; }

        [Required(ErrorMessage = "Le code postal est obligatoire.")]
        [StringLength(10)]
        public required string CodePostal { get; set; }

        // Liste des utilisateurs habitant dans cette localité
        public ICollection<Utilisateur> Utilisateurs { get; set; }
    }
}
