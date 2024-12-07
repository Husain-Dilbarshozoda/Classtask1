using Domain;



public interface IMentorsService
{
    bool CreateMentors(Mentors mentors);
    List<Mentors> GetMentors();
    bool UpdateMentors(Mentors mentors);
    bool DeleteMentors(int id);
}

