using System;
using joanmiroschool.Abstractions;
using Refit;

namespace joanmiroschool.ViewModel
{
    public class StudentsViewModel
    {
        public StudentsViewModel()
        {
        }
        async void GetStudents(string email)
        {
            var students = RestService.For<IJMServices>("");
            var respoinse = await students.GetStudents(email);
        }
    }
}
