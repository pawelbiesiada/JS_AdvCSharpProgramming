using MyRestAPI.Models;

namespace MyRestAPI
{
    public class UsersRepo : IUsersRepo
    {

        private List<User> _users = new List<User>();

        public User? GetUserById(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }

        public void AddUser(User u)
        {
            _users.Add(u);
        }

        public void RemoveUser(int id)
        {
            _users.RemoveAll(u => u.Id == id);
        }
    }
}
