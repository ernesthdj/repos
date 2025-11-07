using System.Windows.Input;
using SweetBalance.Helpers;
using SweetBalance.Models;
using SweetBalance.ViewModels.Base;

namespace SweetBalance.ViewModels
{
    /// <summary>
    /// ViewModel principal de l'application
    /// </summary>
    public class MainViewModel : ObservableObject
    {
        private object _currentViewModel;
        private Settings _settings;

        public MainViewModel()
        {
            // Initialisation des paramètres
            Settings = new Settings();

            // Initialisation des ViewModels
            StockViewModel = new StockViewModel();
            RecipeViewModel = new RecipeViewModel();
            QuoteViewModel = new QuoteViewModel();
            OrderViewModel = new OrderViewModel();
            ProductionViewModel = new ProductionViewModel();
            StatisticsViewModel = new StatisticsViewModel();
            SettingsViewModel = new SettingsViewModel(Settings);

            // ViewModel par défaut
            CurrentViewModel = StockViewModel;

            // Commandes de navigation
            NavigateToStocksCommand = new RelayCommand(() => CurrentViewModel = StockViewModel);
            NavigateToRecipesCommand = new RelayCommand(() => CurrentViewModel = RecipeViewModel);
            NavigateToQuotesCommand = new RelayCommand(() => CurrentViewModel = QuoteViewModel);
            NavigateToOrdersCommand = new RelayCommand(() => CurrentViewModel = OrderViewModel);
            NavigateToProductionCommand = new RelayCommand(() => CurrentViewModel = ProductionViewModel);
            NavigateToStatisticsCommand = new RelayCommand(() => CurrentViewModel = StatisticsViewModel);
            NavigateToSettingsCommand = new RelayCommand(() => CurrentViewModel = SettingsViewModel);
        }

        #region Properties

        public Settings Settings
        {
            get => _settings;
            set => SetProperty(ref _settings, value);
        }

        public object CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
        }

        // ViewModels des modules
        public StockViewModel StockViewModel { get; }
        public RecipeViewModel RecipeViewModel { get; }
        public QuoteViewModel QuoteViewModel { get; }
        public OrderViewModel OrderViewModel { get; }
        public ProductionViewModel ProductionViewModel { get; }
        public StatisticsViewModel StatisticsViewModel { get; }
        public SettingsViewModel SettingsViewModel { get; }

        #endregion

        #region Navigation Commands

        public ICommand NavigateToStocksCommand { get; }
        public ICommand NavigateToRecipesCommand { get; }
        public ICommand NavigateToQuotesCommand { get; }
        public ICommand NavigateToOrdersCommand { get; }
        public ICommand NavigateToProductionCommand { get; }
        public ICommand NavigateToStatisticsCommand { get; }
        public ICommand NavigateToSettingsCommand { get; }

        #endregion
    }
}
