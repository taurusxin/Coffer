using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Coffer.ViewModels
{
    public abstract class BaseViewModel
    {
        protected event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}