using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItFormationCentre.Models
{
    public abstract class Utilisateur
    {
        [Key]
        public int IdUtilisateur { get; set; }

        [ForeignKey("Role")]
        [Required] // Rendre obligatoire la relation avec Role
        public int IdRole { get; set; }

        [ForeignKey("Localite")]
        [Required] // Rendre obligatoire la relation avec Localite
        public int IdLocalite { get; set; }

        [Required] // Rendre obligatoire
        [StringLength(100)]
        public string Nom { get; set; }

        [Required] // Rendre obligatoire
        [StringLength(100)]
        public string Prenom { get; set; }

        [Required] // Rendre obligatoire
        [StringLength(50)]
        public string NomUtilisateur { get; set; }

        [Required] // Rendre obligatoire
        [EmailAddress] 
        public string Email { get; set; }

        [Required] // Rendre obligatoire
        [StringLength(100)]
        public string MotDePasse { get; set; }

        [Phone]
        public string Telephone { get; set; }

        public string Diplome { get; set; }

        [Required] // Rendre obligatoire
        public int IdAdresse { get; set; }

        // Propriétés de navigation
        [Required] // Rendre obligatoire la relation avec Adresse
        public Adresse Adresse { get; set; }

        [Required] // Rendre obligatoire la relation avec Role
        public Role Role { get; set; }

        [Required] // Rendre obligatoire la relation avec Localite
        public Localite Localite { get; set; }

        // Collections pour les évaluations
        public ICollection<Evaluation> EvaluationsStagiaire { get; set; } = new List<Evaluation>();
        public ICollection<Evaluation> EvaluationsFormateur { get; set; } = new List<Evaluation>();
    }
}
