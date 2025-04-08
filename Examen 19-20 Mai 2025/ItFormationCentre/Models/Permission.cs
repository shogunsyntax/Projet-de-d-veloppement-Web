using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItFormationCentre.Models
{
    public class Permission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPermission { get; set; }

        [Required(ErrorMessage = "L'intitulé de la permission est obligatoire.")]
        public required string IntitulePermission { get; set; }

        // Liste des rôles qui possèdent cette permission
        public ICollection<Role> Roles { get; set; }
    }
}
