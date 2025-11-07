using System.Collections.Generic;

namespace SweetBalance.Models
{
    /// <summary>
    /// Paramètres de l'application
    /// </summary>
    public class Settings
    {
        public string NomActivite { get; set; }
        public decimal TauxHoraire { get; set; }
        public decimal MargeCible { get; set; }
        public decimal ChargesFixesPourcent { get; set; }
        public decimal CoutElectriciteHeure { get; set; }
        public int HeuresMaxJour { get; set; }
        public List<string> JoursDisponibles { get; set; }
        public string HeureLimite { get; set; }

        public Settings()
        {
            // Valeurs par défaut
            NomActivite = "Ma Pâtisserie";
            TauxHoraire = 25;
            MargeCible = 30;
            ChargesFixesPourcent = 15;
            CoutElectriciteHeure = 0.5m;
            HeuresMaxJour = 8;
            JoursDisponibles = new List<string> { "Lun", "Mar", "Mer", "Jeu", "Ven", "Sam" };
            HeureLimite = "23:00";
        }
    }
}
