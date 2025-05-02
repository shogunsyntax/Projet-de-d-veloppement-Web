
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using ItFormationCentre.Models;

namespace ItFormationCentre.Models.ViewModels
{
    public class UtilisateurEditViewModel
    {
        public int IdUtilisateur { get; set; }

        [Required(ErrorMessage = "Le nom est requis.")]
        public string Nom { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le prénom est requis.")]
        public string Prenom { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le nom d'utilisateur est requis.")]
        public string NomUtilisateur { get; set; } = string.Empty;

        [Required(ErrorMessage = "L'email est requis.")]
        [EmailAddress(ErrorMessage = "L'email n'est pas valide.")]
        public string Email { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        // Mot de passe non requis en édition
        public string? MotDePasse { get; set; }

        [Required(ErrorMessage = "Le téléphone est requis.")]
        public string Telephone { get; set; } = string.Empty;

        public string? Diplome { get; set; }

        [Required(ErrorMessage = "Le rôle est requis.")]
        public int IdRole { get; set; }

        [Required(ErrorMessage = "La localité est requise.")]
        public int IdLocalite { get; set; }

        public int IdAdresse { get; set; }

        [Required(ErrorMessage = "La rue est requise.")]
        public string Rue { get; set; } = string.Empty;

        [Required(ErrorMessage = "La ville est requise.")]
        public string Ville { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le pays est requis.")]
        public string Pays { get; set; } = string.Empty;

        // Champs spécifiques non obligatoires en déclaration, validation conditionnelle dans contrôleur
        public string? CarteEtudiant { get; set; }
        public string? Specialite { get; set; }

        // Listes pour les Dropdown
        public List<SelectListItem> Roles { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Localites { get; set; } = new List<SelectListItem>();
    }
}
