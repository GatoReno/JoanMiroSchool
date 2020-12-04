using System;
using System.Threading.Tasks;
using joanmiroschool.Abstractions;
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
                return await auth.AuthenticateUser(email, password);
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
    }
}
