using ApiRickMorty.Models;

namespace ApiRickMorty.Repositories
{
    public static class UserRepository
    {
        public static User Get(string username, string password) 
        {
            var users = new List<User>();

            users.Add(new User { Id = 1, UserName = "joao", Password = "123456", Role = "manager" });

            return users.Where(x => x.UserName.ToLower() == username && x.Password == x.Password).First();
        }
    }
}
