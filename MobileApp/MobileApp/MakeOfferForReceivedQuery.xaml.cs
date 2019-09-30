using MobileApp.Models;
using MobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MakeOfferForReceivedQuery : TabbedPage
    {
        public MakeOfferForReceivedQuery(Query query)
        {
            InitializeComponent();
            this.BindingContext = new MakeOfferForReceivedQueryViewModel(query, Navigation);
        }
    }
}