using NUnit.Framework;
using Moq;
using SchoolDataLibraryProject2P4;


namespace SchoolDataTestNUnitprj
{
    [TestFixture]
    public class Tests
    {
        private Mock<ITeacherRepository> teacherRepositoryMock;
        private Mock<IStudentRepository> studentRepositoryMock;
        private Mock<ISubjectRepository> subjectRepositoryMock;
        private StudentService studentService;
        private SubjectService subjectService; 
        private TeacherService teacherService;

        [SetUp]
        public void Setup()
        {
            //Initialize mocks
            teacherRepositoryMock = new Mock<ITeacherRepository>();
            studentRepositoryMock = new Mock<IStudentRepository>();
            subjectRepositoryMock = new Mock<ISubjectRepository>();

            teacherService = new TeacherService(teacherRepositoryMock.Object);  
            studentService = new StudentService(studentRepositoryMock.Object);
            subjectService = new SubjectService(subjectRepositoryMock.Object);

        }

        [Test]
        public void Teacher_Add_ValidTeacher_ShouldSucceed()
        {
            //Arrange
            var validTeacher = new Teacher("Rashmi", "ComputerScience");

            //Act
            teacherService.Add(validTeacher);

            //Assert
            //Assert.Pass();
            teacherRepositoryMock.Verify(repo => repo.Add(validTeacher),Times.Once);
        }


        [Test]
        public void Student_Add_ValidStudent_ShouldSucceed()
        {
            //Arrange
            var validStudent = new Student("Prakash", 10);
            //Act
            studentService.Add(validStudent);
            //Assert
            studentRepositoryMock.Verify(repo=>repo.Add(validStudent), Times.Once);

        }

        [Test]
        public void Subject_Add_ValidSubject_ShouldSucceed()
        {
            //Arrange
            var validSubject = new Subject("Math");
            //Act
            subjectService.Add(validSubject);

            //Assert
            subjectRepositoryMock.Verify(repo=>repo.Add(validSubject),Times.Once);

        }

        [Test]
        public void Subject_Validate_ValidSubject_ShouldSucceed()
        {
            //Arrange
            var validSubject = new Subject("History");
            //Act
            bool result = validSubject.Validate();
            //Assert
            Assert.IsTrue(result);

        }




        [Test]
        public void Teacher_Add_InvalidTeacher_ShouldNotCallRepository()
        {
            //Arrange
            var invalidTeacher = new Teacher("", "InvalidSubject");

            //Act
            teacherService.Add(invalidTeacher);

            //Assert
            teacherRepositoryMock.Verify(repo => repo.Add(It.IsAny<Teacher>()), Times.Never);
        }

        [Test]
        public void Subject_Add_InvalidSubject_ShouldNotCallRepository()
        {
            //Arrange
            var invalidSubject = new Subject("");
            //Act
            subjectService.Add(invalidSubject);
            //Assert
            subjectRepositoryMock.Verify(repo => repo.Add(It.IsAny<Subject>()), Times.Never);

        }


        [Test]
        [TestCase("Rashmi","ComputerScience",true)]
        [TestCase("", "ComputerScience", false)]
        public void Teacher_Validate(string name, string subject, bool expected)
        {
            //Arrange
            var teacher = new Teacher(name, subject);
            //Act
            bool result = teacher.Validate();
            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase("Prakash",10,true)]
        [TestCase("Shivam",-1, false)]
        [TestCase("",8,false)]
        public void Student_Validate(string name, int grade, bool expected)
        {
            //Arrange
            var student = new Student(name, grade);
            //Act
            bool result = student.Validate();
            //Assert
            Assert.AreEqual(expected,result);

        }

        [Test]
        [TestCase("Math",true)]
        [TestCase("", false)]
        public void Subject_Validate(string name, bool expected)
        {
            // Arrange
            var subject = new Subject(name);

            // Act
            bool result = subject.Validate();

            // Assert
            Assert.AreEqual(expected, result);
        }

    }
}