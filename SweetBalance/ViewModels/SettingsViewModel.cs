using SweetBalance.Models;
using SweetBalance.ViewModels.Base;

namespace SweetBalance.ViewModels
{
    /// <summary>
    /// ViewModel pour les paramètres de l'application
    /// </summary>
    public class SettingsViewModel : ObservableObject
    {
        private Settings _settings;

        public SettingsViewModel(Settings settings)
        {
            Settings = settings;
        }

        public Settings Settings
        {
            get => _settings;
            set => SetProperty(ref _settings, value);
        }
    }
}
