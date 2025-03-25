using Microsoft.AspNetCore.Mvc;
using EcommerceApplication.Data;
using EcommerceApplication.Models;
using BCrypt.Net;
using EcommerceApplication.Models.ViewModels;

[Route("admin/utilisateurs")]

public class AdminUtilisateurController: Controller
{
    private readonly ECommerceDbContext _context;

    //! Constructeur qui injecte le contexte de base de données
    public AdminUtilisateurController(ECommerceDbContext context){
        _context = context;
    }

    //* Affiche la liste  des utilisateurs
    [HttpGet("list")]
    public IActionResult List()
    {
        var users = _context.Utilisateurs.ToList();
        return View("AdminUtilisateur",users);

    }

    //* Affiche un formulaire vide avec des valeurs par défaut pour créer un utilisateur
    [HttpGet("create")]
    public IActionResult Create(){
        return View(new Utilisateur{

            Nom = string.Empty,
            Prenom = string.Empty,
            Email= string.Empty,
            MotDePasse = string.Empty,
            Adresse = string.Empty,
            Role = "Client"
        });
    }

    //* Traite l'ajout d'un utilisateur
    [HttpPost("create")]
    public IActionResult Create(Utilisateur utilisateur){
        if(!ModelState.IsValid){
            return View(utilisateur);
        }

        //? Hachage du mot de passe
        utilisateur.MotDePasse = BCrypt.Net.BCrypt.HashPassword(utilisateur.MotDePasse);

        //! Ajout en base de données
        _context.Utilisateurs.Add(utilisateur);
        _context.SaveChanges();

        return RedirectToAction("List");
    }

    //* Supprime un utilisateur
    [HttpPost("delete/{id}")]
    public IActionResult Delete(int id)
    {
        var utilisateur = _context.Utilisateurs.Find(id);
        if(utilisateur == null )
        {
            return NotFound();
        }

        _context.Utilisateurs.Remove(utilisateur);
        _context.SaveChanges();

        return RedirectToAction("List");
    }
    [HttpGet("edit/{id}")]
public IActionResult Edit(int id)
{
    var utilisateur = _context.Utilisateurs.Find(id);
    if (utilisateur == null)
    {
        return NotFound();
    }

    // Convertir en ViewModel
    var viewModel = new UtilisateurViewModel
    {
        Nom = utilisateur.Nom,
        Prenom = utilisateur.Prenom,
        Email = utilisateur.Email,
        Adresse = utilisateur.Adresse,
        Role = utilisateur.Role
    };

    return View(viewModel);
}


[HttpPost("edit/{id}")]
public IActionResult Edit(int id,UtilisateurViewModel utilisateurViewModel)
{
    Console.WriteLine($"🔹 Modification utilisateur ID={id}, Nouveau Nom={utilisateurViewModel.Nom}, Email={utilisateurViewModel.Email}");

    if (!ModelState.IsValid)
    {
        Console.WriteLine("⚠ ModelState invalide !");
        foreach (var error in ModelState)
        {
            Console.WriteLine($"🔸 {error.Key}: {string.Join(", ", error.Value.Errors.Select(e => e.ErrorMessage))}");
        }
        return View(utilisateurViewModel);
    }

    var existingUser = _context.Utilisateurs.Find(id);
    if (existingUser == null)
    {
        return NotFound();
    }

    Console.WriteLine("✅ Utilisateur trouvé, mise à jour en cours...");

    existingUser.Nom = utilisateurViewModel.Nom;
    existingUser.Prenom = utilisateurViewModel.Prenom;
    existingUser.Email = utilisateurViewModel.Email;
    existingUser.Adresse = utilisateurViewModel.Adresse;
    existingUser.Role = utilisateurViewModel.Role;

    // Vérifier si un mot de passe a été fourni
    if (!string.IsNullOrEmpty(utilisateurViewModel.MotDePasse))
    {
        existingUser.MotDePasse = BCrypt.Net.BCrypt.HashPassword(utilisateurViewModel.MotDePasse);
        Console.WriteLine("🔒 Mot de passe mis à jour !");
    }

    try
    {
        _context.SaveChanges();
        Console.WriteLine("✅ Utilisateur mis à jour avec succès !");
        return RedirectToAction("List");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Erreur lors de la mise à jour : {ex.Message}");
        return View(utilisateurViewModel);
    }
}


}