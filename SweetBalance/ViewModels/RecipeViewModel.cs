using System.Collections.ObjectModel;
using SweetBalance.Models;
using SweetBalance.ViewModels.Base;

namespace SweetBalance.ViewModels
{
    /// <summary>
    /// ViewModel pour la gestion des recettes
    /// </summary>
    public class RecipeViewModel : ObservableObject
    {
        private ObservableCollection<Recipe> _recipes;

        public RecipeViewModel()
        {
            Recipes = new ObservableCollection<Recipe>();
        }

        public ObservableCollection<Recipe> Recipes
        {
            get => _recipes;
            set => SetProperty(ref _recipes, value);
        }
    }
}
