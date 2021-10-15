using System;
using Xamarin.Forms;
using System.IO;
using PM2E100380028.Controlador;
using Xamarin.Forms.Xaml;

namespace PM2E100380028
{
    public partial class App : Application
    {
       static Controller basedatos;
        public static string UbicacionDB = string.Empty;

        public static Controller BaseDatos
        {
            get
            {
                if (basedatos == null)
                {
                    basedatos = new Controller(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Movil2Xamarin"));
                }
                return basedatos;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }
        public App(String DBLocal)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
            UbicacionDB = DBLocal;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
