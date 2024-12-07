using Domain;

public interface IStudentService
{
    bool CreateStudent(Student student);
    List<Student> GetStudents();
    bool UpdateStudent(Student student);
    bool DeleteStudent(int id);
}
