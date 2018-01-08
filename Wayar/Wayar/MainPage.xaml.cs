using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Wayar
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var stackLayout = new StackLayout() { Spacing = 0 };
            InitialiseMap(stackLayout);

            Content = stackLayout;
        }

        public void InitialiseMap(StackLayout stackLayout)
        {
            var map = new Map(
    MapSpan.FromCenterAndRadius(
            new Position(37, -122), Distance.FromMiles(0.3)))
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand,
                MapType = MapType.Street
            };

            var pin = new Pin
            {
                Type = PinType.Place,
                Position = new Position(37.8044866, -122.4324132),
                Label = "Pin Title Goes Here",
                Address = "Pin Address Goes Here"
            };
            map.Pins.Add(pin);

            stackLayout.Children.Add(map);

            var slider = new Slider(1, 18, 1);
            slider.ValueChanged += (sender, e) =>
            {
                var zoomLevel = e.NewValue;
                var latLongDegrees = 360 / (Math.Pow(2, zoomLevel));
                map.MoveToRegion(
                    new MapSpan(map.VisibleRegion.Center, latLongDegrees, latLongDegrees));
            };

            stackLayout.Children.Insert(0, slider);
        }
    }
}
