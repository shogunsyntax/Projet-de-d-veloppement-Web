using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItFormationCentre.Models;
using ItFormationCentre.Models.ViewModels;
using ItFormationCentre.Data;
using Microsoft.EntityFrameworkCore; // Pour ToListAsync et EntityState

[Route("api/[controller]")]
[ApiController]
public class UtilisateursController : ControllerBase
{
    private readonly ItFormationCentreDbContext _context;

    public UtilisateursController(ItFormationCentreDbContext context)
    {
        _context = context;
    }

    // POST: Utilisateurs/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(UtilisateurViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var utilisateur = new Utilisateur
            {
                Nom = viewModel.Nom,
                Prenom = viewModel.Prenom,
                NomUtilisateur = viewModel.NomUtilisateur,
                Email = viewModel.Email,
                MotDePasse = viewModel.MotDePasse,
                Telephone = viewModel.Telephone,
                Diplome = viewModel.Diplome,
                IdRole = viewModel.IdRole,
                IdLocalite = viewModel.IdLocalite,
                IdAdresse = viewModel.IdAdresse
            };

            _context.Utilisateurs.Add(utilisateur);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUtilisateur), new { id = utilisateur.IdUtilisateur }, utilisateur);
        }

        // Si le modèle n'est pas valide, renvoyer les listes pour les dropdowns
        viewModel.Roles = await _context.Roles.ToListAsync();
        viewModel.Localites = await _context.Localites.ToListAsync();
        return BadRequest(viewModel); // Renvoie un BadRequest avec le viewModel
    }

    // GET: api/utilisateurs/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Utilisateur>> GetUtilisateur(int id)
    {
        var utilisateur = await _context.Utilisateurs.FindAsync(id);

        if (utilisateur == null)
        {
            return NotFound();
        }

        return utilisateur;
    }

    // POST: api/utilisateurs
    [HttpPost]
    public async Task<ActionResult<Utilisateur>> PostUtilisateur(Utilisateur utilisateur)
    {
        _context.Utilisateurs.Add(utilisateur);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUtilisateur), new { id = utilisateur.IdUtilisateur }, utilisateur);
    }

    // PUT: api/utilisateurs/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUtilisateur(int id, Utilisateur utilisateur)
    {
        if (id != utilisateur.IdUtilisateur)
        {
            return BadRequest();
        }

        _context.Entry(utilisateur).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UtilisateurExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/utilisateurs/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUtilisateur(int id)
    {
        var utilisateur = await _context.Utilisateurs.FindAsync(id);
        if (utilisateur == null)
        {
            return NotFound();
        }

        _context.Utilisateurs.Remove(utilisateur);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool UtilisateurExists(int id)
    {
        return _context.Utilisateurs.Any(e => e.IdUtilisateur == id);
    }
}