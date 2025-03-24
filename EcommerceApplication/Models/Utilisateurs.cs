using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApplication.Models
{
    public class Utilisateur
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //! Identity correspond au Identity SQL
        public int IdUtilisateur { get; set; }

        [Required(ErrorMessage = "Le nom est obligatoire.")]
        [StringLength(50, ErrorMessage = "Le nom ne peut pas dépasser 50 caractères.")]
        public required string Nom { get; set; }

        [Required(ErrorMessage = "Le prénom est obligatoire.")]
        [StringLength(50, ErrorMessage = "Le prénom ne peut pas dépasser 50 caractères.")]
        public required string Prenom { get; set; }

        [Required(ErrorMessage = "L'email est obligatoire.")]
        [EmailAddress(ErrorMessage = "L'email n'est pas valide.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Le mot de passe est obligatoire.")]
        [MinLength(8, ErrorMessage = "Le mot de passe doit contenir au moins 8 caractères.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$", 
        ErrorMessage = "Le mot de passe doit contenir au moins une lettre, un chiffre et un caractère spécial.")]
        public required string MotDePasse { get; set; }

        [Required(ErrorMessage = "L'adresse est obligatoire.")]
        [StringLength(255, ErrorMessage = "L'adresse ne peut pas dépasser 255 caractères.")]
        public required string Adresse { get; set; }

        [Required(ErrorMessage = "Le rôle est obligatoire.")]
        [RegularExpression("^(Client|Admin)$", ErrorMessage = "Le rôle doit être 'Client' ou 'Admin'.")]
        public required string Role { get; set; }
    }
}