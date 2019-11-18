using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views.User
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserDetails : ContentPage
	{
		public UserDetails (string userId)
		{
			InitializeComponent ();
            var user = App.GetUserService().GetUserAsync(userId).Result;
            User.Text = user.DisplayName + " - " + user.CurrentAddress;
		}
	}
}