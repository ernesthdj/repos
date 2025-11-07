using System.Collections.ObjectModel;
using SweetBalance.Models;
using SweetBalance.ViewModels.Base;

namespace SweetBalance.ViewModels
{
    /// <summary>
    /// ViewModel pour la gestion des commandes
    /// </summary>
    public class OrderViewModel : ObservableObject
    {
        private ObservableCollection<Order> _orders;

        public OrderViewModel()
        {
            Orders = new ObservableCollection<Order>();
        }

        public ObservableCollection<Order> Orders
        {
            get => _orders;
            set => SetProperty(ref _orders, value);
        }
    }
}
