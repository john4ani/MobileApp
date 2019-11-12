using MobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapView : ContentPage
	{
		public MapView ()
		{
			InitializeComponent ();
            BindingContext = new MapViewModel(Navigation,null);
            CalculateCommand = new Command<List<Position>>(Calculate);
            UpdateCommand = new Command<Position>(Update);
        }

        public static readonly BindableProperty CalculateCommandProperty =
            BindableProperty.Create(nameof(CalculateCommand), typeof(ICommand), typeof(MapView), null, BindingMode.TwoWay);

        public ICommand CalculateCommand
        {
            get { return (ICommand)GetValue(CalculateCommandProperty); }
            set { SetValue(CalculateCommandProperty, value); }
        }

        public static readonly BindableProperty UpdateCommandProperty =
          BindableProperty.Create(nameof(UpdateCommand), typeof(ICommand), typeof(MapView), null, BindingMode.TwoWay);

        public ICommand UpdateCommand
        {
            get { return (ICommand)GetValue(UpdateCommandProperty); }
            set { SetValue(UpdateCommandProperty, value); }
        }       

        async void Update(Position position)
        {
            if (GoogleMap.Pins.Count == 1 && GoogleMap.Polylines != null && GoogleMap.Polylines?.Count > 1)
                return;

            var cPin = GoogleMap.Pins.FirstOrDefault();

            if (cPin != null)
            {
                cPin.Position = new Position(position.Latitude, position.Longitude);
                cPin.Icon = BitmapDescriptorFactory.FromView(new Image() { Source = "ic_taxi.png", WidthRequest = 25, HeightRequest = 25 });

                await GoogleMap.MoveCamera(CameraUpdateFactory.NewPosition(new Position(position.Latitude, position.Longitude)));
                var previousPosition = GoogleMap?.Polylines?.FirstOrDefault()?.Positions?.FirstOrDefault();
                GoogleMap.Polylines?.FirstOrDefault()?.Positions?.Remove(previousPosition.Value);
            }
            else
            {
                //END TRIP
                GoogleMap.Polylines?.FirstOrDefault()?.Positions?.Clear();
            }


        }

        void Calculate(List<Position> list)
        {
            searchLayout.IsVisible = false;
            stopRouteButton.IsVisible = true;
            GoogleMap.Polylines.Clear();
            var polyline = new Polyline();
            foreach (var p in list)
            {
                polyline.Positions.Add(p);

            }
            GoogleMap.Polylines.Add(polyline);
            GoogleMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(polyline.Positions[0].Latitude, polyline.Positions[0].Longitude), Xamarin.Forms.GoogleMaps.Distance.FromMiles(0.50f)));

            var pin = new Pin
            {
                Type = PinType.Place,
                Position = new Position(polyline.Positions.First().Latitude, polyline.Positions.First().Longitude),
                Label = "First",
                Address = "First",
                Tag = string.Empty,
                Icon = BitmapDescriptorFactory.FromView(new Image() { Source = "ic_taxi.png", WidthRequest = 25, HeightRequest = 25 })

            };
            GoogleMap.Pins.Add(pin);
            var pin1 = new Pin
            {
                Type = PinType.Place,
                Position = new Position(polyline.Positions.Last().Latitude, polyline.Positions.Last().Longitude),
                Label = "Last",
                Address = "Last",
                Tag = string.Empty
            };
            GoogleMap.Pins.Add(pin1);
        }

        public async void OnEnterAddressTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchPlacePage() { BindingContext = this.BindingContext }, false);

        }

        public void Handle_Stop_Clicked(object sender, EventArgs e)
        {
            searchLayout.IsVisible = true;
            stopRouteButton.IsVisible = false;
            GoogleMap.Polylines.Clear();
            GoogleMap.Pins.Clear();
        }

    }
}