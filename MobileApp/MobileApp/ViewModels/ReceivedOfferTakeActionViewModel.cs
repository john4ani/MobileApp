using MobileApp.Models;
using MobileApp.Views.User;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    public class ReceivedOfferTakeActionViewModel : ViewModelBase
    {
        private QueryOffer _offer;

        public ReceivedOfferTakeActionViewModel(QueryOffer offer, INavigation navigation) : base(navigation)
        {
            _offer = offer;
            AcceptOffer = new Command(ExecuteAcceptOffer);
            ShowUserDetails = new Command(ExecuteShowUserDetails);
        }       

        public QueryOffer Offer
        {
            get { return _offer; }
            set
            {
                _offer = value;
                NotifyPropertyChanged(nameof(Offer));
            }
        }

        public ICommand AcceptOffer { get; private set; }
        public ICommand ShowUserDetails { get; private set; }

        public async void ExecuteAcceptOffer(object parameter)
        {
            _offer.Status = OfferStatus.Accepted;
            await App.GetQueringService().UpdateQueryOfferAsync(_offer);
            
            MessagingCenter.Send(this, Constants.MSG_ITEMUPDATED, Offer);

            //move back to the page they were on before bidding
            await Navigation.PopAsync();

        }

        private async void ExecuteShowUserDetails(object obj)
        {
           await  Navigation.PushAsync(new UserDetails(_offer.UserId));
        }
    }
}
