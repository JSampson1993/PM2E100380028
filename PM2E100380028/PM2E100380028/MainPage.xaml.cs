using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PM2E100380028.Modelo;
using Plugin.Geolocator;
using Xamarin.Essentials;

namespace PM2E100380028
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //var Personas = (Modelos.Personas)BindingContext;

            var personas = new Coordenadas
            {
                latitud = Convert.ToDouble(txtLati.Text),
                longitud = Convert.ToDouble(txtLongi.Text),
                descripcionL = Descrip.Text,
                descripcionC = txtDescripC.Text

            };

            var resultado = await App.BaseDatos.CrearPersonas(personas);
            if (resultado == 1)
            {
                await DisplayAlert("Se Guardo", " Exitosamente", "Ok");
            }
            else
            {
                await DisplayAlert("Error", "No Se Guardo Exitosamente", "Ok");
            }

            Limpiar();
        }



        public void Limpiar()
        {
            txtLati.Text = String.Empty;
            txtLongi.Text = String.Empty;
            Descrip.Text = String.Empty;
            txtDescripC.Text = String.Empty;
        }

        private async void Button_Clicked_1(object sender, EventArgs e)

        {
            await Navigation.PushModalAsync(new Vistas.ListaCoo());

        }

        public async void GetLocation()
        {
            var localizacion = CrossGeolocator.Current;
            Location Location = await Geolocation.GetLastKnownLocationAsync();

            if (Location == null)
            {
                Location = await Geolocation.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.Medium,
                    Timeout = TimeSpan.FromSeconds(30)
                }); ;
            }

            txtLati.Text = Location.Latitude.ToString();
                
                txtLongi.Text = Location.Longitude.ToString();


        }


        private void btnNewUbication_Clicked(object sender, EventArgs e)
        {
            GetLocation();
            Descrip.Text = "";
            txtDescripC.Text = "";

        }
    }
}