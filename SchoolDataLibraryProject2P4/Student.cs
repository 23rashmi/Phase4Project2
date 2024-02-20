using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDataLibraryProject2P4
{
    public class Student
    {
        public string? Name { get;}
        public int Grade { get;}

        public Student(string? name, int grade)
        {
            Name = name;
            Grade = grade;
        }
        public bool Validate()
        {
            return !string.IsNullOrEmpty(Name) && Grade >= 0 && Grade <= 12;
        }
    }
    //StudentService.cs
    public class StudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public void Add(Student student)
        {
            if (student.Validate())
            {
                _studentRepository.Add(student);
            }
        }

    }

    public interface IStudentRepository
    {
        void Add(Student student);
    }
}
