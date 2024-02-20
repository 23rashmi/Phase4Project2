using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDataLibraryProject2P4
{
    public class Subject
    {
        public string? Name { get;}
        public Subject(string name)
        {
            Name = name;
        }

        public bool Validate()
        {
            return !string.IsNullOrEmpty(Name);
        }

    }

    //SubjectService.cs
    public class SubjectService
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }
        public void Add(Subject subject)
        {
            if (subject.Validate())
            {
                _subjectRepository.Add(subject);
            }
        }

    }

    public interface ISubjectRepository
    {
        void Add(Subject subject);
    }


}
