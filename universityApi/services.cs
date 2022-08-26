using universityApi.Models.DataModels;

namespace universityApi
{
    public class Services
    {

        public User BuscarUsuriosPorMail(List<User> users, string email)
        {
            var userByEmail = from user in users where user.Email == email select user;
            return (User)userByEmail;
        }

        public IEnumerable<Student> BuscarUsuariosMayoresDe18(List<Student> students)
        {
            var studentsOlderThan18 = from student in students where student.DateOfBirth >= DateTime.Now.AddYears(-18) select student;
            return studentsOlderThan18;
        }

        public IEnumerable<Student> BuscarUsuariosConAlMenosUnCurso(List<Student> students)
        {
            var studentsWithAtLeastOneCourse = from student in students where student.Courses.Count > 0 select student;
            return studentsWithAtLeastOneCourse;
        }

        public IEnumerable<Course> BuscarCursosConDeterminadoNivelConAlMenos1Alumno(List<Course> courses, Level level)
        {
            var courseWithDeterminatedLevelAndOneStudentAtLeast = from course in courses where course.Level == level && course.Students.Count > 0 select course;
            return courseWithDeterminatedLevelAndOneStudentAtLeast;
        }

        public IEnumerable<Course> BuscarCursosConDeterminadoNivelConCategoriaDeterminada(List<Course> courses, Level level, Category category)
        {
            var coursesWithDeterminatedLevelAndCategory = from course in courses where course.Level == level && course.Categories.Contains(category) select course;
            return coursesWithDeterminatedLevelAndCategory;
        }

        public IEnumerable<Course> BuscarCursosSinAlumnos(List<Course> courses)
        {
            var coursesWithoutStudents = from course in courses where course.Students.Count == 0 select course;
            return coursesWithoutStudents;
        }

    }
}
