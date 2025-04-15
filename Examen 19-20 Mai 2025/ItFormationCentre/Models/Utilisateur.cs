using System;

using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace ItFormationCentre.Models 
{
public class Utilisateur{
  [Key]
    public int IdUtilisateur { get; set; }

    [ForeignKey("Role")]
    public int IdRole { get; set; }

    [ForeignKey("Localite")]
    public int IdLocalite { get; set; }

    [Required]
    [StringLength(100)]
    public string Nom { get; set; }

    [Required]
    [StringLength(100)]
    public string Prenom { get; set; }

    [Required]
    [StringLength(50)]
    public string NomUtilisateur { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [StringLength(100)]
    public string MotDePasse { get; set; }

    [Phone]
    public string Telephone { get; set; }

    public string Diplome { get; set; }

    [StringLength(250)]
    public int IdAdresse { get; set; }
    public Adresse? Adresse { get; set; }


    public  Role? Role { get; set; }
    public  Localite? Localite { get; set; }

  public ICollection<Evaluation> EvaluationsStagiaire { get; set; }
  public ICollection<Evaluation> EvaluationsFormateur { get; set; }

  //public ICollection<Adresse> Adresses { get; set; }

}
}