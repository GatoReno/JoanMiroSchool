using System;
using System.Threading.Tasks;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace joanmiroschool.Helpers
{
    public class ConetctivityManager
    {
        public static bool CheckConnectivity()
        {
            bool conn  = CrossConnectivity.Current.IsConnected;
            return conn;
        }

        public static void  ConnectivityAlert()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await App.Current.MainPage.DisplayAlert("Error de conexion",
                    "Asegurece de estar conectado a wifi o activar los datos" +
                    " moviles para el correcto uso de esta aplicacion",
                "ok");
            }
                            );
        }
    }
}
