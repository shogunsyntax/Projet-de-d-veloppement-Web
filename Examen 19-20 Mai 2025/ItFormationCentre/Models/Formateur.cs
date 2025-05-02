using System.Collections.Generic;

namespace ItFormationCentre.Models
{
    public class Formateur : Utilisateur
    {
        public string? Specialite { get; set; }

        // Sessions de formation que ce formateur anime
        public ICollection<SessionFormation> Sessions { get; set; } = new List<SessionFormation>();

        // Évaluations que ce formateur a données
        public ICollection<Evaluation> Evaluations { get; set; } = new List<Evaluation>();
        
    }
}
