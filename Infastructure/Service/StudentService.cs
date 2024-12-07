using Dapper;
using Npgsql;
using Domain;
 
namespace Infastructure;
public class StudentService:IStudentService
{
    public bool CreateStudent(Student student)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.Server))
        {
            var sql = @"insert into students(student_name,student_email,group_id,course_id,mentor_id) 
                        values(@student_name,@student_email,@group_id,@course_id,@mentor_id)";
            int res = connection.Execute(sql,student);
            return res != 0;
        }
    }

    public List<Student> GetStudents()
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.Server))
        {
            var sql = "select * from students";
            var students = connection.Query<Student>(sql).ToList();
            return students;
        }
    }

    public bool UpdateStudent(Student student)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.Server))
        {
            var sql = @"update students 
                set student_name=@student_name,
                    student_email=@student_email,
                    group_id=@group_id,
                    course_id=@course_id,
                    mentor_id=@mentor_id
                    where id=@Id";
            int res = connection.Execute(sql, student);
            return res != 0;
        }
    }

    public bool DeleteStudent(int id)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.Server))
        {
            var sql = "delete from students where id=@Id;";
            int res = connection.Execute(sql, new { ID = id });
            return res != 0;
        }
    }
}

file class SqlCommand
{
    public static string Server = "Server=localhost;Port=5432;Database=;Username=postgres;Password=;";
}