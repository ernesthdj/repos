using System.Collections.Generic;

namespace SweetBalance.Models
{
    /// <summary>
    /// Ingrédient utilisé dans une recette
    /// </summary>
    public class RecipeIngredient
    {
        public int StockId { get; set; }
        public string NomIngredient { get; set; }
        public decimal Quantite { get; set; }
        public string Unite { get; set; }
    }

    /// <summary>
    /// Représente une recette de pâtisserie
    /// </summary>
    public class Recipe
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public List<RecipeIngredient> Ingredients { get; set; }
        public decimal TempsPreparation { get; set; } // en minutes
        public decimal TempsCuisson { get; set; } // en minutes
        public int NombreParts { get; set; }

        public Recipe()
        {
            Ingredients = new List<RecipeIngredient>();
        }

        /// <summary>
        /// Temps total de réalisation (préparation + cuisson)
        /// </summary>
        public decimal TempsTotal => TempsPreparation + TempsCuisson;
    }
}
