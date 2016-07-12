namespace SocialNetwork.Model.User
{
    public interface IUserRepository
    {
        User Insert(string username);
        User Get(string username);
    }
}