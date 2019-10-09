﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class QueryCategoriesPage : ContentPage
	{
		public QueryCategoriesPage ()
		{
			InitializeComponent ();
		}

        private async void OnFoodButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateFoodQuery());
        }

        private void OnTaxiButtonClicked(object sender, EventArgs e)
        {

        }

        private void OnDrugsButtonClicked(object sender, EventArgs e)
        {

        }

        private void OnGroceryButtonClicked(object sender, EventArgs e)
        {

        }

        private void OnP2pButtonClicked(object sender, EventArgs e)
        {

        }
    }
}