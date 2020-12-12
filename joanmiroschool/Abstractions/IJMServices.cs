using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using joanmiroschool.Models;
using Refit;

namespace joanmiroschool.Abstractions
{
    public interface IJMServices
    {
        [Get("/t/client/alumnos/{id}")]
        Task<List<StudentData>> GetStudents(string id);

        [Get("/t/client-by-mail/{email}")]
        Task<List<AccountData>> GetAccount(string email);
        //Task<IList<Event>> GetEvents();
        //Task<IList<Annoucement>> GetAnnouncements();
        //Task<AccountData> GetAccount(string email);
    }
}
