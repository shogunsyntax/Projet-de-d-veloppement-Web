using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItFormationCentre.Models
{
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRole { get; set; }

        [Required(ErrorMessage = "L'intitulé du rôle est obligatoire.")]
        [StringLength(100)]
        public required string IntituleRole { get; set; }

        // Liste des utilisateurs ayant ce rôle
        public ICollection<Utilisateur> Utilisateurs { get; set; }

        // Liste des permissions associées au rôle
        public ICollection<Permission> Permissions { get; set; }
    }
}
