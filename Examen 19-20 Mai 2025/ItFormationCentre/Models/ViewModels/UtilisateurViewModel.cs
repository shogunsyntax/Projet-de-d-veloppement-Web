using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ItFormationCentre.Models;

namespace ItFormationCentre.Models.ViewModels
{
    public class UtilisateurViewModel
    {
        public int IdUtilisateur { get; set; }

        [Required(ErrorMessage = "Le nom est requis.")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le prénom est requis.")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Le nom d'utilisateur est requis.")]
        public string NomUtilisateur { get; set; }

        [Required(ErrorMessage = "L'email est requis.")]
        [EmailAddress(ErrorMessage = "L'email n'est pas valide.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Le mot de passe est requis.")]
        [DataType(DataType.Password)]
        public string MotDePasse { get; set; }

        [Required(ErrorMessage = "Le numéro de téléphone est requis.")]
        public string Telephone { get; set; }

        public string Diplome { get; set; }

        [Required(ErrorMessage = "Le rôle est requis.")]
        public int IdRole { get; set; }

        [Required(ErrorMessage = "La localité est requise.")]
        public int IdLocalite { get; set; }

        public int IdAdresse { get; set; }

        // Ajout des propriétés liées à l'adresse
        [Required(ErrorMessage = "La rue est requise.")]
        public string Rue { get; set; } // Rue de l'adresse

        [Required(ErrorMessage = "La ville est requise.")]
        public string Ville { get; set; } // Ville

        [Required(ErrorMessage = "Le pays est requis.")]
        public string Pays { get; set; } // Pays

         // Ajout des champs spécifiques
        // Champ pour stagiaire
        public string CarteEtudiant { get; set; }

        // Champ pour formateur
        public string Specialite { get; set; }

        // Propriétés pour les listes déroulantes
        public List<Role> Roles { get; set; } = new List<Role>();
        public List<Localite> Localites { get; set; } = new List<Localite>();
    }
}