using System;
using System.Threading.Tasks;
using Firebase.Auth;
using joanmiroschool.Abstractions;
using Xamarin.Forms;

[assembly: Dependency(typeof(joanmiroschool.Droid.Services.FirebaseAuth))]
namespace joanmiroschool.Droid.Services
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
                await Firebase.Auth.FirebaseAuth.
                Instance.SignInWithEmailAndPasswordAsync(email, password);
                return true;
            }
            catch (FirebaseAuthWeakPasswordException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (FirebaseAuthInvalidCredentialsException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (FirebaseAuthUserCollisionException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception es)
            {
                throw new Exception("Error desconocido, "+es.ToString()+" . Por favor intente nuevamente o mas tarde.");
            }
        }

        public string GetCurrentUserId()
        {
            return Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid;
        }

        public bool IsAuthenticated()
        {
            return Firebase.Auth.FirebaseAuth.Instance.CurrentUser != null;
        }

        public async Task<bool> RegisterUser(string name, string email, string password )
        {
            try
            {
                await Firebase.Auth.FirebaseAuth.
                Instance.CreateUserWithEmailAndPasswordAsync(email, password);
                var profileUpdate = new Firebase.Auth.UserProfileChangeRequest.Builder();
                profileUpdate.SetDisplayName(name);
                 
                var build = profileUpdate.Build();

                var user = Firebase.Auth.FirebaseAuth.Instance.CurrentUser;
                await user.UpdateProfileAsync(build);

                return true;
            }
            catch (FirebaseAuthWeakPasswordException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (FirebaseAuthInvalidCredentialsException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (FirebaseAuthUserCollisionException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception es)
            {
                throw new Exception("Error desconocido, por favor intente nuevamente o mas tarde." + es.Message);
            }

        }
    }
}
