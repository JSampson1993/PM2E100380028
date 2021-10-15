using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace PM2E100380028
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapasPage : ContentPage
    {
        Double latitud;
        Double longitud;
        public MapasPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();



            longitud = Convert.ToDouble(txtLongitudMap.Text);
            latitud = Convert.ToDouble(txtLactitudMap.Text);

            Pin ubicacion = new Pin();
            {
                ubicacion.Label = txtShortDesciptionMap.Text;
                ubicacion.Address = txtLargeDescriptionMap.Text;
                ubicacion.Type = PinType.Place;
                ubicacion.Position = new Position(latitud, longitud);

            }
            mpMapa.Pins.Add(ubicacion);


            var localizacion = await Geolocation.GetLastKnownLocationAsync();

            if (localizacion == null)
            {

                localizacion = await Geolocation.GetLocationAsync();
            }
            mpMapa.MoveToRegion(MapSpan.FromCenterAndRadius(ubicacion.Position, Distance.FromKilometers(1)));
        }
    }

}