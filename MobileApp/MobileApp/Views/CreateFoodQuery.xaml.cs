using MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Category = "Food"
            };
            await App.GetQueringService().MakeQuery(query);
            await Navigation.PushAsync(new Queries());
        }
    }
}