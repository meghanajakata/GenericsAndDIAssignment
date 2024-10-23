using ECommerceApplication.Models;

namespace ECommerceApplication.Repository
{
    public interface IUserRepository
    {
        public List<User> GetUsers();
        public bool AddUser(User userModel);
        public bool UpdateUser(User userModel);
        public bool DeleteUser(int Id);
        string Login(string username, string password);
        void Logout(string token);
        bool IsAuthenticated(string token);
    }
}
