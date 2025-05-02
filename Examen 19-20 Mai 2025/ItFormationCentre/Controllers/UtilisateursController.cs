using Microsoft.AspNetCore.Mvc;
using ItFormationCentre.Data;
using ItFormationCentre.Models;
using ItFormationCentre.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering; 
using BCrypt.Net;
using Microsoft.Extensions.Logging;



namespace ItFormationCentre.Controllers
{
    public class UtilisateursController : Controller
    {
        private readonly ItFormationCentreDbContext _context;
        private readonly ILogger<UtilisateursController> _logger;

        public UtilisateursController(ItFormationCentreDbContext context, ILogger<UtilisateursController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: utilisateurs/list
        [HttpGet("utilisateurs/list")]
        public IActionResult List()
        {
            var users = _context.Utilisateurs
                .Include(u => u.Role)
                .Include(u => u.Localite)
                 .Include(u => u.Adresse)
                .ToList();

            return View("Display", users); 
        }
        [HttpGet("Utilisateurs/Create")]
        public IActionResult Create()
        {
            var viewModel = ChargerViewModel();
            return View(viewModel);
        }

[HttpPost("utilisateurs/create")]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create(UtilisateurViewModel viewModel)
{
    _logger.LogInformation("Début de la méthode Create POST.");

    // Validation des champs requis en fonction du rôle
    if (viewModel.IdRole == 1 && string.IsNullOrEmpty(viewModel.CarteEtudiant))
    {
        ModelState.AddModelError("CarteEtudiant", "La Carte Étudiant est requise pour les stagiaires.");
    }

    if (viewModel.IdRole == 2 && string.IsNullOrEmpty(viewModel.Specialite))
    {
        ModelState.AddModelError("Specialite", "La Spécialité est requise pour les formateurs.");
    }

    if (!ModelState.IsValid)
    {
        _logger.LogWarning("ModelState invalide.");
        foreach (var entry in ModelState)
        {
            foreach (var error in entry.Value.Errors)
            {
                _logger.LogWarning($"Erreur sur la propriété {entry.Key}: {error.ErrorMessage}");
            }
        }

        ModelState.AddModelError("", "Données invalides. Veuillez corriger les erreurs.");
        return View(ChargerViewModel(viewModel));
    }

    Utilisateur utilisateur;

    if (viewModel.IdRole == 1) // Stagiaire
    {
        var stagiaire = new Stagiaire
        {
            CarteEtudiant = viewModel.CarteEtudiant
        };
        utilisateur = stagiaire;
    }
    else if (viewModel.IdRole == 2) // Formateur
    {
        var formateur = new Formateur
        {
            Specialite = viewModel.Specialite
        };
        utilisateur = formateur;
    }
    else
    {
        _logger.LogWarning($"Rôle non valide: {viewModel.IdRole}");
        ModelState.AddModelError("", "Rôle non valide.");
        return View(ChargerViewModel(viewModel));
    }

    var localiteExists = await _context.Localites.AnyAsync(l => l.IdLocalite == viewModel.IdLocalite);
    if (!localiteExists)
    {
        _logger.LogWarning($"IdLocalite non valide: {viewModel.IdLocalite}");
        ModelState.AddModelError("", "La localité sélectionnée n'est pas valide.");
        return View(ChargerViewModel(viewModel));
    }

    var adresse = new Adresse
    {
        Rue = viewModel.Rue,
        Ville = viewModel.Ville,
        Pays = viewModel.Pays,
        IdLocalite = viewModel.IdLocalite
    };

    try
    {
        _context.Adresses.Add(adresse);
        await _context.SaveChangesAsync();
        _logger.LogInformation($"Adresse ajoutée avec Id: {adresse.IdAdresse}");

        utilisateur.Nom = viewModel.Nom;
        utilisateur.Prenom = viewModel.Prenom;
        utilisateur.NomUtilisateur = viewModel.NomUtilisateur;
        utilisateur.Email = viewModel.Email;
        utilisateur.MotDePasse = BCrypt.Net.BCrypt.HashPassword(viewModel.MotDePasse);
        utilisateur.Telephone = viewModel.Telephone;
        utilisateur.Diplome = viewModel.Diplome;
        utilisateur.IdRole = viewModel.IdRole;
        utilisateur.IdLocalite = viewModel.IdLocalite;
        utilisateur.IdAdresse = adresse.IdAdresse;

        _context.Utilisateurs.Add(utilisateur);
        await _context.SaveChangesAsync();

        _logger.LogInformation($"Utilisateur créé avec Id: {utilisateur.IdUtilisateur}");

        return RedirectToAction("List");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Erreur lors de la création de l'utilisateur.");
        ModelState.AddModelError("", $"Erreur lors de la création : {ex.Message}");
        return View(ChargerViewModel(viewModel));
    }
}

[HttpGet]
public IActionResult Edit(int id)
{
    var utilisateur = _context.Utilisateurs
        .Include(u => u.Adresse)
        .FirstOrDefault(u => u.IdUtilisateur == id);

    if (utilisateur == null) return NotFound();

    var viewModel = new UtilisateurEditViewModel
    {
        IdUtilisateur = utilisateur.IdUtilisateur,
        Nom = utilisateur.Nom,
        Prenom = utilisateur.Prenom,
        Email = utilisateur.Email,
        Telephone = utilisateur.Telephone,
        Diplome = utilisateur.Diplome,
        IdRole = utilisateur.IdRole,
        IdLocalite = utilisateur.IdLocalite,
        Rue = utilisateur.Adresse?.Rue,
        Ville = utilisateur.Adresse?.Ville,
        Pays = utilisateur.Adresse?.Pays,

        CarteEtudiant = (utilisateur is Stagiaire stagiaire) ? stagiaire.CarteEtudiant : null,
        Specialite = (utilisateur is Formateur formateur) ? formateur.Specialite : null,

        Roles = _context.Roles.Select(r => new SelectListItem
        {
            Value = r.IdRole.ToString(),
            Text = r.IntituleRole
        }).ToList(),

        Localites = _context.Localites.Select(l => new SelectListItem
        {
            Value = l.IdLocalite.ToString(),
            Text = l.NomLocalite
        }).ToList()
    };

    return View(viewModel);
}

[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Edit(int id, UtilisateurEditViewModel model)
{
    if (!ModelState.IsValid)
    {
        foreach (var key in ModelState.Keys)
{
    var state = ModelState[key];
    foreach (var error in state.Errors)
    {
        _logger.LogWarning("ModelState error for '{Key}': {Error}", key, error.ErrorMessage);
    }
}
if (model.IdUtilisateur <= 0)
{
    _logger.LogWarning("L'IdUtilisateur est invalide dans le modèle : {IdUtilisateur}", model.IdUtilisateur);
    return BadRequest("L'ID de l'utilisateur est invalide.");
}

        _logger.LogWarning("ModelState invalide pour utilisateur {IdUtilisateur}", id);
        model.Roles = _context.Roles.Select(r => new SelectListItem
        {
            Value = r.IdRole.ToString(),
            Text = r.IntituleRole
        }).ToList();

        model.Localites = _context.Localites.Select(l => new SelectListItem
        {
            Value = l.IdLocalite.ToString(),
            Text = l.NomLocalite
        }).ToList();

        return View(model);
    }

    var utilisateur = _context.Utilisateurs
        .Include(u => u.Adresse)
        .FirstOrDefault(u => u.IdUtilisateur == id);

    if (utilisateur == null)
    {
        _logger.LogError("Utilisateur {IdUtilisateur} non trouvé", id);
        return NotFound();
    }

    _logger.LogInformation("Chargé utilisateur de type {Type}", utilisateur.GetType().Name);

    utilisateur.Nom = model.Nom;
    utilisateur.Prenom = model.Prenom;
    utilisateur.Email = model.Email;
    utilisateur.Telephone = model.Telephone;
    utilisateur.Diplome = model.Diplome;
    utilisateur.IdLocalite = model.IdLocalite;

    if (utilisateur.Adresse == null)
    {
        utilisateur.Adresse = new Adresse();
        _logger.LogInformation("Adresse inexistante, créée pour l'utilisateur {IdUtilisateur}", id);
    }

    utilisateur.Adresse.Rue = model.Rue;
    utilisateur.Adresse.Ville = model.Ville;
    utilisateur.Adresse.Pays = model.Pays;

    if (utilisateur is Stagiaire stagiaire)
    {
        _logger.LogInformation("Utilisateur {IdUtilisateur} est un Stagiaire. Mise à jour CarteEtudiant: {Carte}",
            id, model.CarteEtudiant);
        stagiaire.CarteEtudiant = model.CarteEtudiant;
    }
    else if (utilisateur is Formateur formateur)
    {
        _logger.LogInformation("Utilisateur {IdUtilisateur} est un Formateur. Mise à jour Spécialité: {Spec}",
            id, model.Specialite);
        formateur.Specialite = model.Specialite;
    }
    else
    {
        _logger.LogWarning("Utilisateur {IdUtilisateur} n'est ni Stagiaire ni Formateur", id);
    }

    try
    {
        _context.SaveChanges();
        _logger.LogInformation("Modifications sauvegardées pour utilisateur {IdUtilisateur}", id);
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Erreur lors de la sauvegarde des modifications de l'utilisateur {IdUtilisateur}", id);
    }

    return RedirectToAction("List");
}



        // POST: Utilisateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var utilisateur = _context.Utilisateurs.Find(id);
            if (utilisateur == null) return NotFound();

            _context.Utilisateurs.Remove(utilisateur);
            _context.SaveChanges();

            return RedirectToAction("List");
        }

        // Méthode utilitaire pour charger les listes dans le ViewModel
    private UtilisateurViewModel ChargerViewModel(UtilisateurViewModel? model = null)
{
    var vm = model ?? new UtilisateurViewModel();
    vm.Roles = _context.Roles.ToList();
    vm.Localites = _context.Localites.ToList();
    return vm;
}

    }
}
