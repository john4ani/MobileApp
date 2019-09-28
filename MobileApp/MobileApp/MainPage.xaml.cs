using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace MobileApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Message.Text = "Create a profile";

            //MobileServiceClient client = new MobileServiceClient("https://mobileappbackendion.azurewebsites.net/");
            //var items = await client.GetTable<TodoItem>().ReadAsync();
            //var item = items.First();
            //Message.Text = item.Text;
        }
    }
}
