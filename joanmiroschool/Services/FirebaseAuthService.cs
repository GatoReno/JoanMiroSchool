using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using joanmiroschool.Abstractions;
using Xamarin.Forms;

namespace joanmiroschool.Services
{
    public class FirebaseAuthService
    {
        private static IFiBAuth auth = DependencyService.Get<IFiBAuth>();


        public static async Task<bool> RegisterUser(string name, string email, string password )
        {
            UserDialogs.Instance.ShowLoading();
            try
            {
                return await auth.RegisterUser(name, email, password);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "ok");
                return false;
            }
            UserDialogs.Instance.HideLoading();
        }
        public static async Task<bool> AuthenticateUser(string email, string password)
        {
            UserDialogs.Instance.ShowLoading();
            try
            {
                return await auth.AuthenticateUser(email, password);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "ok");
                return false;
            }
            UserDialogs.Instance.HideLoading();
        }
        public static bool IsAuthenticated()
        {
            UserDialogs.Instance.ShowLoading();
            return auth.IsAuthenticated();
            UserDialogs.Instance.HideLoading();
        }

        public static string GetCurrentUserId()
        {
            return auth.GetCurrentUserId();
        }

        public static void LogOut()
        {
            UserDialogs.Instance.ShowLoading();
            auth.LogOut();

            UserDialogs.Instance.HideLoading();
        }

        public async static void RestartPassword(string email)
        {
            try
            {
                auth.ResetPassword(email);
                await App.Current.MainPage.DisplayAlert("Recuperar contraseña",
                    $"Se ha envidado un correo de recupeacion al correo {email}"+
                    " favor de confirmar e intentar ingresar de nuevo.",
                    "ok");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "ok");
            }
           
        }
    }
}
