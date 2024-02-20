using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDataLibraryProject2P4
{
    public class Teacher
    {
        public string? Name { get;}
        public string? Subject { get;}

        public Teacher(string? name, string? subject)
        {
            Name = name;
            Subject = subject;
        }

        public bool Validate()
        {
            return !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Subject);
        }

    }

    //TeacherService.cs
    public class TeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        public void Add(Teacher teacher)
        {
            if (teacher.Validate())
            {
                _teacherRepository.Add(teacher);
            }
        }

    }

    public interface ITeacherRepository
    {
        void Add(Teacher teacher);
    }

}
