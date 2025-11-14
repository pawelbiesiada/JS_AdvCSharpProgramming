using MyRestAPI.Models;

namespace MyRestAPI
{
    public interface IUsersRepo
    {
        void AddUser(User u);
        User? GetUserById(int id);
        void RemoveUser(int id);
    }
}