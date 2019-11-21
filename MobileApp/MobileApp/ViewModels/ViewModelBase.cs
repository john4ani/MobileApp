using System.ComponentModel;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        private INavigation _navigation;

        public ViewModelBase(INavigation navigation)
        {
            _navigation = navigation;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public INavigation Navigation { get { return _navigation; } }

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                NotifyPropertyChanged("IsLoading");
            }
        }

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
    }
}
