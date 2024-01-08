using AuthProcessInWeb.Models;

namespace AuthProcessInWeb.Services
{
    public class UserService
    {
        private List<User> _users;
        public UserService()
        {
            _users = new List<User>()
            {
                 new(){ Id=1, UserName="turkay", Password="123456", Email="t@test.com", Role="Admin"},
                 new(){ Id=2, UserName="esmanur", Password="123456", Email="e@test.com", Role ="Editör"},
                 new(){ Id=3, UserName="hakan", Password="123456", Email="h@test.com", Role="Client"}

            };
        }
        public User ValidateUser(string username, string password)
        {
            return _users.SingleOrDefault(u => u.UserName == username && u.Password == password);

        }
    }
}
