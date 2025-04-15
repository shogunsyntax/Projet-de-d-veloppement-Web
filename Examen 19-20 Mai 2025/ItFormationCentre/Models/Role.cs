using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItFormationCentre.Models
{
    public class Role
    {
      [Key]
    public int IdRole { get; set; }

    [Required]
    [StringLength(100)]
    public string IntituleRole { get; set; }

    public  ICollection<Utilisateur> Utilisateurs { get; set; }
    public  ICollection<Detenir> Permissions { get; set; }
    }
}
