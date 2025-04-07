using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace EcommerceApplication.Models.ViewModels{
  
public class UtilisateurEditViewModel{ 
        public int IdUtilisateur { get; set; }

        //[Required(ErrorMessage = "Le rôle est obligatoire.")]
        public int? IdRole { get; set; }

        //[Required(ErrorMessage = "La localité est obligatoire.")]
        public int? IdLocalite { get; set; }

        //[Required, StringLength(50)]
        public string Nom { get; set; } = "";

        //[Required, StringLength(50)]
        public string Prenom { get; set; } = "";

        //[Required, StringLength(255)]
        public string Adresse { get; set; } = "";

        //[Required, EmailAddress]
        public string Email { get; set; } = "";

        public string? MotDePasse { get; set; }

        // On ajoute les listes directement dans le ViewModel
        public List<SelectListItem> Roles { get; set; } = new();
        public List<SelectListItem> Localites { get; set; } = new();
}}