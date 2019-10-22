using MobileApp.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreateFoodQuery : ContentPage
	{
		public CreateFoodQuery ()
		{
			InitializeComponent ();
		}

        private async void SubmitFoodQuery_ButtonClicked(object sender, EventArgs e)
        {
            var query = new Query
            {
                Description = queryDescription.Text,
                Category = "Food",
                //EventDate = new DateTime(DateTime.Now.Ticks, DateTimeKind.Utc)
            };
            await App.GetQueringService().MakeQuery(query);
            await Navigation.PushAsync(new Queries());
        }
    }
}