using MobileApp.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views.CreateQuery
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreateFoodQuery : ContentPage
	{
		public CreateFoodQuery ()
		{
			InitializeComponent ();
		}

        private async void SubmitQuery_ButtonClicked(object sender, EventArgs e)
        {
            var query = new Query
            {
                Name = queryName.Text,
                Description = queryDescription.Text,
                Category = "Food",
                EventDate = queryDate.Date + queryTime.Time,
                UserId = App.GetUserService().GetLoggedInUserAsync().Result.Id,
                Id = Guid.NewGuid().ToString()
            };
            await App.GetQueringService().MakeQuery(query);
            await Navigation.PushAsync(new HomePage());
        }
    }
}