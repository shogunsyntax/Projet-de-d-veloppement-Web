// Importation des outils nécessaires au MVC (Models, Controllers, Views)
using Microsoft.AspNetCore.Mvc;

// Importation pour utiliser SelectList et SelectListItem (dropdownList pour les vues)
using Microsoft.AspNetCore.Mvc.Rendering;

// Importation Entity Framework Core (requêtes, Include, SaveChanges,...)
using Microsoft.EntityFrameworkCore;

// Importation du DbContext de l'application
using EcommerceApplication.Data;

// Importation des modèles
using EcommerceApplication.Models;

using EcommerceApplication.Models.ViewModels;

[Route("admin/utilisateurs")]

public class AdminUtilisateurController : Controller
{
   // Dépendance vers la base de données (via DbContext)
        private readonly ECommerceDbContext _context;

        // Logger pour afficher des infos ou erreurs dans la console
        private readonly ILogger<AdminUtilisateurController> _logger;

        // Constructeur avec injection de dépendances
        // Injection de dépendances : Recevoir un objet prêt à l'emploi qui vient "d'ailleurs",
        // un service externe, des outils fournit par le framwork..
        public AdminUtilisateurController(ECommerceDbContext context, ILogger<AdminUtilisateurController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // ---------------------------
        // GET: Affiche le formulaire de création
        // ---------------------------
        [HttpGet("create")]
        public IActionResult Create()
        {
            // ATTENTION : Le ViewBag c'est un peu la méthode wish pour les ViewModels !
            // Vous savez que ça existe et il y aura peut-être des cas où ce sera adapté mais sinon on passe au ViewModels pour la suite
            // Remplit la liste des rôles pour le select dropdown
            ViewBag.Roles = _context.Role
                .Select(r => new SelectListItem
                {
                    Value = r.RoleId.ToString(),
                    Text = r.IntituleRole
                }).ToList();

            // Remplit la liste des localités pour le select dropdown
            ViewBag.Localites = _context.Localite
                .Select(l => new SelectListItem
                {
                    Value = l.LocaliteId.ToString(),
                    Text = l.Intitule
                }).ToList();

            // On renvoie la vue avec un objet Utilisateur vide
            return View(new Utilisateur
            {
                IdRole = null,
                IdLocalite = null,
                Nom = string.Empty,
                Prenom = string.Empty,
                Adresse = string.Empty,
                Email = string.Empty,
                MotDePasse = string.Empty
            });
        }

        // ---------------------------
        // POST: Traite le formulaire de création
        // ---------------------------
        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Nom,Prenom,Adresse,Email,MotDePasse,IdRole,IdLocalite")] Utilisateur utilisateur)
        {
            // --- LOGGING : Début de l'action POST ---
            _logger.LogInformation(">>> Début POST Create");
            _logger.LogInformation("Modèle reçu : Nom={Nom}, Prénom={Prenom}, Email={Email}, IdRole={IdRole}, IdLocalite={IdLocalite}",
                utilisateur.Nom, utilisateur.Prenom, utilisateur.Email, utilisateur.IdRole, utilisateur.IdLocalite);

            // Vérifie si le rôle fourni existe en db
            if (!_context.Role.Any(r => r.RoleId == utilisateur.IdRole))
            {
                _logger.LogWarning("Le rôle ID {IdRole} est invalide.", utilisateur.IdRole);
                ModelState.AddModelError("IdRole", "Le rôle sélectionné est invalide.");
            }
            else
            {
                _logger.LogInformation("Le rôle ID {IdRole} est valide.", utilisateur.IdRole);
            }

            // Vérifie si la localité fournie existe
            if (!_context.Localite.Any(l => l.LocaliteId == utilisateur.IdLocalite))
            {
                _logger.LogWarning("La localité ID {IdLocalite} est invalide.", utilisateur.IdLocalite);
                ModelState.AddModelError("IdLocalite", "La localité sélectionnée est invalide.");
            }
            else
            {
                _logger.LogInformation("La localité ID {IdLocalite} est valide.", utilisateur.IdLocalite);
            }

            // Si le modèle est invalide (erreurs de validation), on log tout et on retourne à la vue
            // Ici faire attention avec les validations ASP NET, ça ne semble pas fonctionner à 100%
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Modèle invalide, on retourne à la vue.");
                foreach (var key in ModelState.Keys)
                {
                    var state = ModelState[key];
                    foreach (var error in state.Errors)
                    {
                        _logger.LogWarning("Erreur champ '{Key}' : {Message}", key, error.ErrorMessage);
                    }
                }

                // On recharge les listes des dropdowns pour la vue
                ViewBag.Roles = _context.Role
                    .Select(r => new SelectListItem
                    {
                        Value = r.RoleId.ToString(),
                        Text = r.IntituleRole
                    }).ToList();

                ViewBag.Localites = _context.Localite
                    .Select(l => new SelectListItem
                    {
                        Value = l.LocaliteId.ToString(),
                        Text = l.Intitule
                    }).ToList();

                // On retourne le formulaire avec les erreurs affichées
                return View(utilisateur);
            }

            // Si tout est valide :
            _logger.LogInformation("Modèle valide, on enregistre l'utilisateur.");

            // Hash du mot de passe avant sauvegarde (très important pour la sécurité, sinon viré)
            utilisateur.MotDePasse = BCrypt.Net.BCrypt.HashPassword(utilisateur.MotDePasse);

            // Ajout de l'utilisateur en db
            _context.Utilisateur.Add(utilisateur);
            _context.SaveChanges();

            _logger.LogInformation("Utilisateur créé avec succès : {Email}", utilisateur.Email);

            // Redirection vers la liste
            return RedirectToAction("List");
        }

        // ---------------------------
        // GET: Liste des utilisateurs
        // ---------------------------
        [HttpGet("list")]
        public IActionResult List()
        {
            // Récupère tous les utilisateurs avec leurs rôles et localités 
            // Include = chargement des relations
            var users = _context.Utilisateur
                .Include(u => u.Role)
                .Include(u => u.Localite)
                .ToList();

            // Envoie la liste à la vue
            // users qu'on appelle dans la vue
            return View("AdminUtilisateur", users);
        }

        // ---------------------------
        // POST: Suppression d’un utilisateur
        // ---------------------------
         

        // ---------------------------
        // GET: Modification d’un utilisateur
        // ---------------------------
       [HttpGet("edit/{id}")]
public IActionResult Edit(int id)
{
    _logger.LogInformation(">>> [GET] Edit appelé pour l'utilisateur ID : {Id}", id);

    // Étape 1 : Récupération de l'utilisateur dans la db
    var utilisateur = _context.Utilisateur.FirstOrDefault(u => u.IdUtilisateur == id);

    if (utilisateur == null)
    {
        _logger.LogWarning("Aucun utilisateur trouvé avec l'ID : {Id}", id);
        return NotFound(); // Affiche une 404 si l'utilisateur n'existe pas
    }

    // Étape 2 : Log des données récupérées
    _logger.LogInformation("Utilisateur récupéré : {Nom} {Prenom}, Email : {Email}, IdRole : {IdRole}, IdLocalite : {IdLocalite}",
        utilisateur.Nom, utilisateur.Prenom, utilisateur.Email, utilisateur.IdRole, utilisateur.IdLocalite);

    // Étape 3 : Création du ViewModel avec les données de l'utilisateur
    var vm = new UtilisateurEditViewModel
    {
        IdUtilisateur = utilisateur.IdUtilisateur,
        Nom = utilisateur.Nom,
        Prenom = utilisateur.Prenom,
        Adresse = utilisateur.Adresse,
        Email = utilisateur.Email,
        IdRole = utilisateur.IdRole,
        IdLocalite = utilisateur.IdLocalite,

        // Remplissage des listes déroulantes
        Roles = _context.Role.Select(r => new SelectListItem
        {
            Value = r.RoleId.ToString(),
            Text = r.IntituleRole
        }).ToList(),

        Localites = _context.Localite.Select(l => new SelectListItem
        {
            Value = l.LocaliteId.ToString(),
            Text = l.Intitule
        }).ToList()
    };

    // Étape 4 : Log pour valider le contenu du ViewModel
    _logger.LogInformation("ViewModel prêt à être envoyé à la vue. Nom : {Nom}, Email : {Email}", vm.Nom, vm.Email);

    // Étape 5 : Affichage de la vue
    return View(vm);
}


[HttpPost("edit/{id}")]
[ValidateAntiForgeryToken]
public IActionResult Edit(int id, UtilisateurEditViewModel vm)
{
    _logger.LogInformation(">>> POST Edit pour ID {id}", id);

    if (!ModelState.IsValid)
    {
        _logger.LogWarning("Modèle invalide.");
        vm.Roles = _context.Role.Select(r => new SelectListItem
        {
            Value = r.RoleId.ToString(),
            Text = r.IntituleRole
        }).ToList();

        vm.Localites = _context.Localite.Select(l => new SelectListItem
        {
            Value = l.LocaliteId.ToString(),
            Text = l.Intitule
        }).ToList();

        return View(vm);
    }

    var utilisateur = _context.Utilisateur.Find(id);
    if (utilisateur == null) return NotFound();

    utilisateur.Nom = vm.Nom;
    utilisateur.Prenom = vm.Prenom;
    utilisateur.Adresse = vm.Adresse;
    utilisateur.Email = vm.Email;
    utilisateur.IdRole = vm.IdRole;
    utilisateur.IdLocalite = vm.IdLocalite;

    if (!string.IsNullOrWhiteSpace(vm.MotDePasse))
    {
        utilisateur.MotDePasse = BCrypt.Net.BCrypt.HashPassword(vm.MotDePasse);
    }

    _context.SaveChanges();
    _logger.LogInformation("Utilisateur mis à jour avec succès.");

    return RedirectToAction("List");
        }

    }



