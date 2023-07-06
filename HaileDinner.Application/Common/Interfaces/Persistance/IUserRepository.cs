using HaileDinner.Domain.Entities;


namespace HaileDinner.Application.Common.Interfaces.Persistance
{
    public interface IUserRepository
    {
        ICollection<User> GetAll();
        User? GetUserByEmail(string email);
        void Add(User user);

    }
}
