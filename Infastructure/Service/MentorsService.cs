using Domain;
using Npgsql;
using Dapper;

namespace Infastructure;

public class MentorsService:IMentorsService
{
    public bool CreateMentors(Mentors mentors)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.Server))
        {
            var sql = @"insert into mentors(mentor_name,mentor_email,course_id) 
                        values(@mentor_name,@mentor_email,@course_id)";
            int res = connection.Execute(sql,mentors);
            return res != 0;
        }    
    }

    public List<Mentors> GetMentors()
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.Server))
        {
            var sql = "select * from mentors";
            var mentors = connection.Query<Mentors>(sql).ToList();
            return mentors;
        }
    }

    public bool UpdateMentors(Mentors mentors)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.Server))
        {
            var sql = @"update mentors 
                set mentor_name=@mentor_name,
                    mentor_email=@mentor_email,
                    course_id=@course_id,
                    where id=@Id";
            int res = connection.Execute(sql, mentors);
            return res != 0;
        }    
    }

    public bool DeleteMentors(int id)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.Server))
        {
            var sql = "delete from mentors where id=@Id;";
            int res = connection.Execute(sql, new { ID = id });
            return res != 0;
        }    
    }
}

file class SqlCommand
{
    public static string Server = "Server=localhost;Port=5432;Database=;Username=postgres;Password=;";
}