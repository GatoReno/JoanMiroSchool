using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using joanmiroschool.Abstractions;
using joanmiroschool.View;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace joanmiroschool.Services
{
    public class FirebaseAuthService
    {
        private static IFiBAuth auth = DependencyService.Get<IFiBAuth>();


        public static async Task<bool> RegisterUser(string name, string email, string password )
        {
            
            try
            {
                return await auth.RegisterUser(name, email, password);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "ok");
                return false;
            }
          
        }
        public static async Task<bool> AuthenticateUser(string email, string password)
        {
             try
            {
                bool au = await auth.AuthenticateUser(email, password);
                if (au)
                {
                    Preferences.Set("AccountEmail", email);
                }
                return au;
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "ok");
                return false;
            }
         }
        public static bool IsAuthenticated()
        {
             return auth.IsAuthenticated();
         }

        public static string GetCurrentUserId()
        {
            return auth.GetCurrentUserId();
        }

        public static void LogOut()
        {
            UserDialogs.Instance.ShowLoading();
            auth.LogOut();
            Preferences.Set("AccountEmail", "");

            Application.Current.MainPage = new LoginPage();
            UserDialogs.Instance.HideLoading();
        }

        public async static void RestartPassword(string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                {
                    await App.Current.MainPage.DisplayAlert("Error",
                        "Se requiere un email para recuperar contraseña", "ok");
                }
                else
                {
                    auth.ResetPassword(email);
                    await App.Current.MainPage.DisplayAlert("Recuperar contraseña",
                        $"Se ha envidado un correo de recupeacion al correo {email}" +
                        " favor de confirmar e intentar ingresar de nuevo.",
                        "ok");
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "ok");
            }
           
        }
    }
}
