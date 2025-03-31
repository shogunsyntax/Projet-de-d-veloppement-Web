using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApplication.Models{
    public class Detenir
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required int RoleId { get; set; }
    public required int PermissionId{get;set;}

    public ICollection<Role> Role{get;set;} = new List<Role>();

    public ICollection<Permission> Permission{get;set;} = new List<Permission>();
}
}