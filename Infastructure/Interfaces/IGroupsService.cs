using Domain;



public interface IGroupsService
{
    bool CreateGroups(Groups groups);
    List<Groups> GetGroups();
    bool UpdateGroups(Groups groups);
    bool DeleteGroups(int id);
}


