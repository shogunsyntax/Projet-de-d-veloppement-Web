using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApplication.Models{
    public class Role
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public  int? RoleId { get; set; }
    public required string IntituleRole{get;set;}

    public required string DetailRole{get;set;}

    public ICollection<Utilisateur> Utilisateur{get;set;} = new List<Utilisateur>();
}
}