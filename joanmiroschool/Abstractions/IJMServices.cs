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

        [Get("/alumno/{id}")]
        Task<List<StudentData>> GetDataStudent(string id);

        [Get("/cliente-pagos-all/{id}")]
        Task<List<StatementData>> GetStatements(string id);

    }
}
