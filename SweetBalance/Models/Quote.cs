using System;
using System.Collections.Generic;

namespace SweetBalance.Models
{
    /// <summary>
    /// Article dans un devis
    /// </summary>
    public class QuoteItem
    {
        public int RecipeId { get; set; }
        public string NomRecette { get; set; }
        public int Quantite { get; set; }
        public decimal PrixUnitaire { get; set; }
        public decimal Total => Quantite * PrixUnitaire;
    }

    /// <summary>
    /// Représente un devis
    /// </summary>
    public class Quote
    {
        public int Id { get; set; }
        public string NumeroDevis { get; set; }
        public string NomClient { get; set; }
        public string EmailClient { get; set; }
        public string TelephoneClient { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime? DateValidite { get; set; }
        public List<QuoteItem> Articles { get; set; }
        public string Statut { get; set; } // "En attente", "Accepté", "Refusé"
        public string Notes { get; set; }

        public Quote()
        {
            Articles = new List<QuoteItem>();
            DateCreation = DateTime.Now;
            DateValidite = DateTime.Now.AddDays(30);
            Statut = "En attente";
        }

        /// <summary>
        /// Montant total HT du devis
        /// </summary>
        public decimal MontantTotal
        {
            get
            {
                decimal total = 0;
                foreach (var article in Articles)
                {
                    total += article.Total;
                }
                return total;
            }
        }
    }
}
