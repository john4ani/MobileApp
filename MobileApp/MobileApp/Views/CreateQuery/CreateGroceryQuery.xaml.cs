using MobileApp.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views.CreateQuery
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreateGroceryQuery : ContentPage
	{
		public CreateGroceryQuery()
		{
			InitializeComponent ();
		}

        private async void SubmitQuery_ButtonClicked(object sender, EventArgs e)
        {
            var query = new Query
            {
                Name = queryGroceryList.Text,
                Description = queryDescription.Text,
                Category = "Grocery",
                EventDate = queryDate.Date + queryTime.Time,
                UserId = App.GetUserService().GetLoggedInUserAsync().Result.Id,
                Id = Guid.NewGuid().ToString()
            };
            await App.GetQueriesService().MakeQuery(query);
            await Navigation.PushAsync(new HomePage());
        }
    }
}