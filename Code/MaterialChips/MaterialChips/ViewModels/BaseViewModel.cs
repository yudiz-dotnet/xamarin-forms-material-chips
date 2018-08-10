using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace MaterialChips.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected INavigation Navigation { get; set; }

        private string _AppName;
        protected string AppName { get { return _AppName; } set { _AppName = value; NotifyPropertyChanged("AppName"); } }

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}