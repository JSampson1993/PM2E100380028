using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using PM2E100380028.Controlador;
using Xamarin.Forms.Xaml;
using PM2E100380028.Modelo;
using Plugin.Geolocator;
using SQLite;

namespace PM2E100380028.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaCoo : ContentPage
    {
        public ListaCoo()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();


            var listmaps = await App.BaseDatos.ObtenerListaPersonas();
            lspersonas.ItemsSource = listmaps;


        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {

        }

        private async void btnEliminar_Clicked_1(object sender, EventArgs e)
        {
            


        }


        private async void lspersonas_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Modelo.Coordenadas item = (Modelo.Coordenadas)e.Item;

            if (item.codigo != 0)
            {
                await DisplayAlert("Elemento Seleccionado", "Para Eliminar:" + item.codigo, "Ok");
                var eliminar = await App.BaseDatos.EliminarPersonas(item);


            }
            else
            {
                messagetSelect();
            }

        }
        private async void messagetSelect()
        {
            await DisplayAlert("Sin Seleccion", "Por Favor Seleccione un Dato", "OK");
        }


       
    }
}


