using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApplication.Models{
    public class Permission
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public  int? IdPermission { get; set; }

    public required string Intitule{get;set;}


    public required string Description{get;set;}
}
}