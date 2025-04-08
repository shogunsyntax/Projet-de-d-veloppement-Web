using System;

using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace ItFormationCentre.Models 
{
public class Utilisateur{
  // Indique à Entity Framework que c'est la clé primaire de la table
        [Key] 
        // Spécifie que la valeur est auto-incrémentée 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        // Déclaration de la propriété id de l'utilisateur
        public int IdUtilisateur { get; set; }
        // Liaison avec la table Role
        // Validation : ce champ doit être renseigné (sinon erreur affichée)
        [Required(ErrorMessage = "Le Role est obligatoire.")] 
        // Clé étrangère qui peut être null vers la table Role (Apparement c'est qqchose propre au binding ASP NET CORE.... à creuser)
        // Binding : ASP.NET Core fait correspondre les champs du formulaire HTML (grâce au name="...") 
        // avec les propriétés du modèle C# (ex: name="Nom" =  Utilisateur.Nom)


        // ----- RELATION AVEC ROLE -----
        public int? IdRole { get; set; } 
        // Propriété de navigation vers l'objet Role (Accèder directement à l'objet rôle pour par exemple, récupérer l'intitulé du rôle)
        public Role? Role { get; set; } 
        // Liaison avec la table Localite
        // Validation : champ obligatoire
        [Required(ErrorMessage = "Le Localite est obligatoire.")] 
        // Clé étrangère qui peut-être null vers la table Localite (Apparement c'est qqchose propre au binding ASP NET CORE.... à creuser)


        // ----- RELATION AVEC LOCALITE -----
        public int? IdLocalite { get; set; } 
        // Propriété de navigation vers l'objet Localité (Accèder directement à l'objet localité pour par exemple, récupérer le nom de la localité)
        public Localite? Localite { get; set; } 
        // Informations personnelles de l'utilisateur
        // Champ requis pour le nom
        [Required(ErrorMessage = "Le nom est obligatoire.")] 
        // Limite de longueur
        [StringLength(50, ErrorMessage = "Le nom ne peut pas dépasser 50 caractères.")] 
        // Le mot-clé required impose l'initialisation à l’instanciation


        // ----- INFOS PERSOS SUR UN UTILISATEUR -----
        public required string Nom { get; set; } 
        // Champ requis pour le prénom
        [Required(ErrorMessage = "Le prénom est obligatoire.")] 
        // Limite de longueur
        [StringLength(50, ErrorMessage = "Le prénom ne peut pas dépasser 50 caractères.")] 
        public required string Prenom { get; set; }

        [StringLength(50, ErrorMessage = "Le nom d'utilisateur ne peut pas dépasser 50 caractères.")] 
        public required string NomUtilisateur { get; set; }
        [Phone]
        public string Telephone{get;set;}

        // Champ requis
        [Required(ErrorMessage = "L'adresse est obligatoire.")] 
        // Limite de longueur
        [StringLength(255, ErrorMessage = "L'adresse ne peut pas dépasser 255 caractères.")] 
        public required string Adresse { get; set; }
        // Champ requis
        [Required(ErrorMessage = "L'email est obligatoire.")] 
        // Vérifie que le champ est bien une adresse mail valide (jordano@gmail.com)
        [EmailAddress(ErrorMessage = "L'email n'est pas valide.")] 
        public required string Email { get; set; }
        // Champ requis pour le mot de passe
        [Required(ErrorMessage = "Le mot de passe est obligatoire.")] 
        public required string MotDePasse { get; set; } 

    public  ICollection<Panier> Paniers { get; set; }

    public ICollection<Evaluation> Evaluations { get; set; }
}
}