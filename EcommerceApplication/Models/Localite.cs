using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApplication.Models{
    public class Localite
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public  int? LocaliteId { get; set; }

    public required string NomLocalite{get; set;}

    public required int CodePostal{get;set;}


    public required string Intitule{get;set;}

     public ICollection<Utilisateur> Utilisateur{get;set;} = new List<Utilisateur>();
}
}