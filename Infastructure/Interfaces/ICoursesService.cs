using Domain;



public interface ICoursesService
{
    bool CreateCourses(Courses courses);
    List<Courses> GetCourses();
    bool UpdateCourses(Courses courses);
    bool DeleteCourses(int id);
}


