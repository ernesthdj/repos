using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using SweetBalance.Helpers;
using SweetBalance.Models;
using SweetBalance.ViewModels.Base;

namespace SweetBalance.ViewModels
{
    /// <summary>
    /// ViewModel pour la gestion des stocks
    /// </summary>
    public class StockViewModel : ObservableObject
    {
        private ObservableCollection<Stock> _stocks;
        private bool _showForm;
        private Stock _currentStock;
        private bool _isEditing;

        public StockViewModel()
        {
            // Initialisation avec des données de test
            Stocks = new ObservableCollection<Stock>
            {
                new Stock { Id = 1, Nom = "Farine T45", PrixUnitaire = 1.2m, Unite = "kg", StockActuel = 10, StockMin = 5 },
                new Stock { Id = 2, Nom = "Sucre", PrixUnitaire = 1.5m, Unite = "kg", StockActuel = 8, StockMin = 3 },
                new Stock { Id = 3, Nom = "Beurre", PrixUnitaire = 8m, Unite = "kg", StockActuel = 5, StockMin = 2 },
                new Stock { Id = 4, Nom = "Oeufs", PrixUnitaire = 0.3m, Unite = "pièce", StockActuel = 50, StockMin = 20 }
            };

            CurrentStock = new Stock();

            // Commandes
            AddNewCommand = new RelayCommand(ExecuteAddNew);
            SaveCommand = new RelayCommand(ExecuteSave, CanExecuteSave);
            CancelCommand = new RelayCommand(ExecuteCancel);
            EditCommand = new RelayCommand(ExecuteEdit);
            DeleteCommand = new RelayCommand(ExecuteDelete);
            IncreaseStockCommand = new RelayCommand(ExecuteIncreaseStock);
            DecreaseStockCommand = new RelayCommand(ExecuteDecreaseStock);
        }

        #region Properties

        public ObservableCollection<Stock> Stocks
        {
            get => _stocks;
            set
            {
                SetProperty(ref _stocks, value);
                OnPropertyChanged(nameof(StocksFaibles));
                OnPropertyChanged(nameof(ValeurTotale));
                OnPropertyChanged(nameof(HasStocksFaibles));
            }
        }

        public Stock CurrentStock
        {
            get => _currentStock;
            set => SetProperty(ref _currentStock, value);
        }

        public bool ShowForm
        {
            get => _showForm;
            set => SetProperty(ref _showForm, value);
        }

        public bool IsEditing
        {
            get => _isEditing;
            set => SetProperty(ref _isEditing, value);
        }

        /// <summary>
        /// Liste des stocks faibles
        /// </summary>
        public ObservableCollection<Stock> StocksFaibles
        {
            get
            {
                if (Stocks == null) return new ObservableCollection<Stock>();
                return new ObservableCollection<Stock>(Stocks.Where(s => s.EstFaible));
            }
        }

        /// <summary>
        /// Indique s'il y a des stocks faibles
        /// </summary>
        public bool HasStocksFaibles => StocksFaibles.Count > 0;

        /// <summary>
        /// Valeur totale de tous les stocks
        /// </summary>
        public decimal ValeurTotale
        {
            get
            {
                if (Stocks == null) return 0;
                return Stocks.Sum(s => s.ValeurTotale);
            }
        }

        #endregion

        #region Commands

        public ICommand AddNewCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand IncreaseStockCommand { get; }
        public ICommand DecreaseStockCommand { get; }

        #endregion

        #region Command Implementations

        private void ExecuteAddNew()
        {
            CurrentStock = new Stock();
            IsEditing = false;
            ShowForm = true;
        }

        private bool CanExecuteSave()
        {
            return CurrentStock != null &&
                   !string.IsNullOrWhiteSpace(CurrentStock.Nom) &&
                   CurrentStock.PrixUnitaire > 0;
        }

        private void ExecuteSave()
        {
            if (string.IsNullOrWhiteSpace(CurrentStock.Nom))
            {
                MessageBox.Show("⚠️ Le nom est obligatoire", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (CurrentStock.PrixUnitaire <= 0)
            {
                MessageBox.Show("⚠️ Le prix doit être supérieur à 0", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (IsEditing)
            {
                // Mise à jour d'un stock existant
                var existingStock = Stocks.FirstOrDefault(s => s.Id == CurrentStock.Id);
                if (existingStock != null)
                {
                    existingStock.Nom = CurrentStock.Nom.Trim();
                    existingStock.PrixUnitaire = CurrentStock.PrixUnitaire;
                    existingStock.Unite = CurrentStock.Unite;
                    existingStock.StockActuel = CurrentStock.StockActuel;
                    existingStock.StockMin = CurrentStock.StockMin;
                }
                MessageBox.Show("✅ Ingrédient modifié !", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                // Ajout d'un nouveau stock
                CurrentStock.Id = Stocks.Count > 0 ? Stocks.Max(s => s.Id) + 1 : 1;
                CurrentStock.Nom = CurrentStock.Nom.Trim();
                Stocks.Add(CurrentStock);
                MessageBox.Show("✅ Ingrédient ajouté !", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            RefreshStockProperties();
            ShowForm = false;
        }

        private void ExecuteCancel()
        {
            ShowForm = false;
            CurrentStock = new Stock();
        }

        private void ExecuteEdit(object parameter)
        {
            if (parameter is Stock stock)
            {
                CurrentStock = new Stock
                {
                    Id = stock.Id,
                    Nom = stock.Nom,
                    PrixUnitaire = stock.PrixUnitaire,
                    Unite = stock.Unite,
                    StockActuel = stock.StockActuel,
                    StockMin = stock.StockMin
                };
                IsEditing = true;
                ShowForm = true;
            }
        }

        private void ExecuteDelete(object parameter)
        {
            if (parameter is Stock stock)
            {
                var result = MessageBox.Show(
                    "Supprimer cet ingrédient ?",
                    "Confirmation",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    Stocks.Remove(stock);
                    MessageBox.Show("✅ Supprimé !", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                    RefreshStockProperties();
                }
            }
        }

        private void ExecuteIncreaseStock(object parameter)
        {
            if (parameter is Stock stock)
            {
                stock.StockActuel++;
                RefreshStockProperties();
            }
        }

        private void ExecuteDecreaseStock(object parameter)
        {
            if (parameter is Stock stock && stock.StockActuel > 0)
            {
                stock.StockActuel--;
                RefreshStockProperties();
            }
        }

        private void RefreshStockProperties()
        {
            OnPropertyChanged(nameof(StocksFaibles));
            OnPropertyChanged(nameof(ValeurTotale));
            OnPropertyChanged(nameof(HasStocksFaibles));
        }

        #endregion
    }
}
