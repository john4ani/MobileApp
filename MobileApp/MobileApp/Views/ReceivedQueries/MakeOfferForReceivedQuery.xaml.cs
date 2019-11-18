using MobileApp.Models;
using MobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views.ReceivedQueries
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MakeOfferForReceivedQuery : TabbedPage
    {
        public MakeOfferForReceivedQuery(Query query, INavigation navigation)
        {
            InitializeComponent();
            this.BindingContext = new MakeOfferForReceivedQueryViewModel(query, navigation);
        }
    }
}