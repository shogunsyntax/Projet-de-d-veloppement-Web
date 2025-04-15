using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItFormationCentre.Models
{
    public class Permission
    {
      [Key]
    public int IdPermission { get; set; }

    [Required]
    [StringLength(100)]
    public string IntitulePermission { get; set; }

    public ICollection<Detenir> Roles { get; set; }
    }
}
