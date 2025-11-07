using System;

namespace SweetBalance.Models
{
    /// <summary>
    /// Représente un ingrédient en stock
    /// </summary>
    public class Stock
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public decimal PrixUnitaire { get; set; }
        public string Unite { get; set; }
        public decimal StockActuel { get; set; }
        public decimal StockMin { get; set; }

        /// <summary>
        /// Indique si le stock est en dessous du seuil minimum
        /// </summary>
        public bool EstFaible => StockActuel <= StockMin;

        /// <summary>
        /// Calcule la valeur totale du stock actuel
        /// </summary>
        public decimal ValeurTotale => StockActuel * PrixUnitaire;

        public Stock()
        {
            Unite = "kg";
        }
    }
}
