using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApplication.Models{
    public class TVA
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required int TvaId { get; set; }
    public required int TauxTva {get;set;}

    public required string TypeProduitTva{get;set;}
}
}