using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApplication.Models{
    public class Detenir
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required int IdRole { get; set; }
    public required int IdPermission{get;set;}

    public Role? Role{get;set;}

    public Permission? Permission{get;set;} 
}
}