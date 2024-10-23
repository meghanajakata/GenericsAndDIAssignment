using ECommerceApplication.Data;
using ECommerceApplication.Models;

namespace ECommerceApplication.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly List<string> _activeSessions;
        private readonly Context context;
        public UserRepository(Context _context)
        {
            context = _context;
            _activeSessions = new List<string>();
        }

        /// <summary>
        /// Get users from database
        /// </summary>
        /// <returns></returns>
        public List<User> GetUsers()
        {
            try
            {
                var users = context.Users.ToList();
                return users;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Add user to database
        /// </summary>
        /// <param name="user"></param>
        public bool AddUser(User userModel)
        {
            try
            {
                User user = context.Users.FirstOrDefault(u => u.UserName == userModel.UserName);
                if(user != null)
                {
                    return false;
                }
                context.Users.Add(userModel);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateUser(User userModel)
        {
            try
            {
                var user = context.Users.FirstOrDefault(u => u.UserId == userModel.UserId);
                if (user == null)
                {
                    return false;
                }
                user.UserName = userModel.UserName;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteUser(int Id)
        {
            try
            {
                var user = context.Users.FirstOrDefault(u => u.UserId == Id);
                if(user != null)
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Login(string username, string password)
        {
            var user = context.Users.FirstOrDefault(u => u.UserName == username && u.Password == password);
            if (user == null)
            {
                return null;
            }

            string token = Guid.NewGuid().ToString();
            _activeSessions.Add(token);
            return token;
        }

        public void Logout(string token)
        {
            _activeSessions.Remove(token);
        }

        public bool IsAuthenticated(string token)
        {
            return _activeSessions.Contains(token);
        }
    }
}
