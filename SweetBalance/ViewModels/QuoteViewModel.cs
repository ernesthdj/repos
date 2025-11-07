using System.Collections.ObjectModel;
using SweetBalance.Models;
using SweetBalance.ViewModels.Base;

namespace SweetBalance.ViewModels
{
    /// <summary>
    /// ViewModel pour la gestion des devis
    /// </summary>
    public class QuoteViewModel : ObservableObject
    {
        private ObservableCollection<Quote> _quotes;

        public QuoteViewModel()
        {
            Quotes = new ObservableCollection<Quote>();
        }

        public ObservableCollection<Quote> Quotes
        {
            get => _quotes;
            set => SetProperty(ref _quotes, value);
        }
    }
}
