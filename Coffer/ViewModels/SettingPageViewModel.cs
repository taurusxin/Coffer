using System.ComponentModel;
using Coffer.Tools;
using Xamarin.Forms;

namespace Coffer.ViewModels
{
    public class SettingPageViewModel : BaseViewModel
    {
        
        public bool AutoUpdate
        {
            get => Settings.Settings.AutoUpdate;
            set
            {
                Settings.Settings.AutoUpdate = value;
                OnPropertyChanged(nameof(AutoUpdate));
            }
        }

        private string _latestUpdate;

        public string LatestUpdate
        {
            get => _latestUpdate;
            set
            {
                _latestUpdate = value;
                OnPropertyChanged(nameof(LatestUpdate));
            }
        }
        
        public SettingPageViewModel()
        {
            LatestUpdate = Settings.Settings.LatestUpdate;
            MessagingCenter.Subscribe<Util>(this, "UpdateComplete", sender =>
            {
                LatestUpdate = Settings.Settings.LatestUpdate;
            });
        }
    }
}