using System;
using System.Threading.Tasks;
using Foundation;
using joanmiroschool.Abstractions;
using Xamarin.Forms;

[assembly: Dependency(typeof(joanmiroschool.iOS.Services.FirebaseAuth))]
namespace joanmiroschool.iOS.Services
{
    public class FirebaseAuth : IFiBAuth
    {
        public FirebaseAuth()
        {
        }

        public async Task<bool> AuthenticateUser(string email, string password)
        {
            try
            {

                await Firebase.Auth.Auth.DefaultInstance.SignInWithPasswordAsync(email, password);
                return true;
            }
            catch (NSErrorException ex)
            {
                string msn = ex.Message.Substring(ex.Message.IndexOf("NSLocalizedDescription=", StringComparison.CurrentCulture));
                msn = msn.Replace("NSLocalizedDescription", "").Split('.')[0];
                msn += ".";
                throw new Exception(msn);
            }
            catch (Exception msn)
            {
                throw new Exception("Error desconocido, " + msn.ToString() + " . Por favor intente nuevamente o mas tarde.");
            }
        }

        public string GetCurrentUserId()
        {
            return Firebase.Auth.Auth.DefaultInstance.CurrentUser.Uid;
        }

        public bool IsAuthenticated()
        {
            return Firebase.Auth.Auth.DefaultInstance.CurrentUser != null;
        }

        public void LogOut()
        {
            try
            {
                Firebase.Auth.Auth.DefaultInstance.SignOut(out NSError error);
            }
            catch (NSErrorException ex)
            {
                string msn = ex.Message.Substring(ex.Message.IndexOf("NSLocalizedDescription=", StringComparison.CurrentCulture));
                msn = msn.Replace("NSLocalizedDescription", "").Split('.')[0];
                msn += ".";
                throw new Exception(msn);
            }
            catch (Exception msn)
            {
                throw new Exception("Error desconocido, " + msn.ToString() + " . Por favor intente nuevamente o mas tarde.");
            }
        }

        public void ResetPassword(string email)
        {
            Firebase.Auth.Auth.DefaultInstance.SendPasswordResetAsync(email);
        }

        public async Task<bool> RegisterUser(string name, string email, string password)
        {
            try
            {
                await Firebase.Auth.Auth.DefaultInstance.CreateUserAsync(email, password);
                var changeRequest = Firebase.Auth.Auth.DefaultInstance.CurrentUser.ProfileChangeRequest();
                changeRequest.DisplayName = name;
                await changeRequest.CommitChangesAsync();
                return true;
            }
            catch (NSErrorException ex)
            {
                string msn = ex.Message.Substring(ex.Message.IndexOf("NSLocalizedDescription=", StringComparison.CurrentCulture));
                msn = msn.Replace("NSLocalizedDescription", "").Split('.')[0];
                msn += ".";
                throw new Exception(msn);
            }
            catch (Exception msn)
            {
                throw new Exception("Error desconocido, " + msn.ToString() + " . Por favor intente nuevamente o mas tarde.");
            }
        }
    }
}
