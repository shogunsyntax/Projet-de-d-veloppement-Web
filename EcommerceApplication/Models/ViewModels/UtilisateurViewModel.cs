using System.ComponentModel.DataAnnotations;
namespace EcommerceApplication.Models.ViewModels{
  
    public class UtilisateurViewModel{ 
        [Required]
        public string Nom{get;set;}

        [Required]
        public string Prenom{get;set;}

        [Required,EmailAddress]
        public string Email{get;set;}

        public string? MotDePasse{get;set;} //! Pas obligatoire
      
        public string Adresse{get;set;}

        [Required]
        public string Role{get;set;}

}}
   