using System.ComponentModel.DataAnnotations;
namespace EcommerceApplication.Models.ViewModels{
  
    public class UtilisateurViewModel{ 
        [Required]
        public required string Nom{get;set;}

        [Required]
        public required string Prenom{get;set;}

        [Required,EmailAddress]
        public required string Email{get;set;}

        public string? MotDePasse{get;set;} //! Pas obligatoire
      
        [Required]
        public required string Adresse{get;set;}

        [Required]
        public required string Role{get;set;}

}}
   