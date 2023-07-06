
using HaileDinner.Application.Common.Interfaces.Persistance;
using HaileDinner.Domain.Entities;

namespace HaileDinner.infrastructure.Persistance
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new() { };
        public void Add(User user)
        {
            _users.Add(user);
        }

        public ICollection<User> GetAll()
        {
           return _users.ToList();
        }

        public User? GetUserByEmail(string email)
        {
            return _users.SingleOrDefault(x => x.Email == email);
        }
    }
}
