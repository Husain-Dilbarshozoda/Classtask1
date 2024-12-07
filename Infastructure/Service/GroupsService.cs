using Dapper;
using Npgsql;
using Domain;

namespace Infastructure;

public class GroupsService:IGroupsService
{
    public bool CreateGroups(Groups groups)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.Server))
        {
            var sql = @"insert into groups(group_name,course_id) 
                        values(@group_name,@course_id)";
            int res = connection.Execute(sql,groups);
            return res != 0;
        }   
    }

    public List<Groups> GetGroups()
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.Server))
        {
            var sql = "select * from groups";
            var groups = connection.Query<Groups>(sql).ToList();
            return groups;
        }
    }

    public bool UpdateGroups(Groups groups)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.Server))
        {
            var sql = @"update groups 
                set group_name=@group_name,
                    course_id=@course_id,
                    where id=@Id";
            int res = connection.Execute(sql, groups);
            return res != 0;
        }  
    }

    public bool DeleteGroups(int id)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.Server))
        {
            var sql = "delete from groups where id=@Id;";
            int res = connection.Execute(sql, new { ID = id });
            return res != 0;
        }  
    }
}


file class SqlCommand
{
    public static string Server = "Server=localhost;Port=5432;Database=;Username=postgres;Password=;";
}