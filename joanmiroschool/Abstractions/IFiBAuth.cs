using System;
using System.Threading.Tasks;

namespace joanmiroschool.Abstractions
{
    public interface IFiBAuth
    {
        Task<bool> RegisterUser(string name, string email, string password);
        Task<bool> AuthenticateUser(string email, string password);
        bool IsAuthenticated();
        string GetCurrentUserId();
        void LogOut();
        void ResetPassword(string email);
    }
}
