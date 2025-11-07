using System;

namespace SweetBalance.Models
{
    /// <summary>
    /// Représente une commande issue d'un devis accepté
    /// </summary>
    public class Order
    {
        public int Id { get; set; }
        public int QuoteId { get; set; }
        public string NumeroCommande { get; set; }
        public string NomClient { get; set; }
        public DateTime DateCommande { get; set; }
        public DateTime DateLivraison { get; set; }
        public string Statut { get; set; } // "En attente", "En production", "Terminée", "Livrée"
        public decimal MontantTotal { get; set; }
        public bool EstPayee { get; set; }
        public string Notes { get; set; }

        public Order()
        {
            DateCommande = DateTime.Now;
            DateLivraison = DateTime.Now.AddDays(7);
            Statut = "En attente";
            EstPayee = false;
        }
    }
}
