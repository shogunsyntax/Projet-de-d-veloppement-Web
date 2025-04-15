using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ItFormationCentre.ViewModels
{
    public class UtilisateurViewModel
    {
        public int IdUtilisateur { get; set; }

        public int IdRole { get; set; }

        public int IdLocalite { get; set; }

        [Required(ErrorMessage = "Le nom est requis.")]
        [StringLength(100, ErrorMessage = "Le nom ne peut pas dépasser 100 caractères.")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le prénom est requis.")]
        [StringLength(100, ErrorMessage = "Le prénom ne peut pas dépasser 100 caractères.")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Le nom d'utilisateur est requis.")]
        [StringLength(50, ErrorMessage = "Le nom d'utilisateur ne peut pas dépasser 50 caractères.")]
        public string NomUtilisateur { get; set; }

        [Required(ErrorMessage = "L'email est requis.")]
        [EmailAddress(ErrorMessage = "L'email n'est pas valide.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Le mot de passe est requis.")]
        [StringLength(100, ErrorMessage = "Le mot de passe ne peut pas dépasser 100 caractères.")]
        public string MotDePasse { get; set; }

        [Phone(ErrorMessage = "Le numéro de téléphone n'est pas valide.")]
        public string Telephone { get; set; }

        public string Diplome { get; set; }

        public int IdAdresse { get; set; }

        // Propriétés supplémentaires pour les listes déroulantes
        public IEnumerable<Role> Roles { get; set; }
        public IEnumerable<Localite> Localites { get; set; }
    }
}