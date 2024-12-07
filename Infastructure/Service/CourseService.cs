using Dapper;
using Npgsql;
using Domain;

namespace Infastructure;

public class CourseService:ICoursesService
{
    public bool CreateCourses(Courses courses)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.Server))
        {
            var sql = @"insert into courses(course_name,course_description) 
                        values(@course_name,@course_description)";
            int res = connection.Execute(sql,courses);
            return res != 0;
        }       
    }

    public List<Courses> GetCourses()
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.Server))
        {
            var sql = "select * from courses";
            var courses = connection.Query<Courses>(sql).ToList();
            return courses;
        }
    }

    public bool UpdateCourses(Courses courses)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.Server))
        {
            var sql = @"update courses 
                set course_name=@course_name,
                    course_description=@course_description,
                    where id=@Id";
            int res = connection.Execute(sql, courses);
            return res != 0;
        }  
    }

    public bool DeleteCourses(int id)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.Server))
        {
            var sql = "delete from courses where id=@Id;";
            int res = connection.Execute(sql, new { ID = id });
            return res != 0;
        } 
    }
}


file class SqlCommand
{
    public static string Server = "Server=localhost;Port=5432;Database=;Username=postgres;Password=;";
}