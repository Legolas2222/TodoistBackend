using TodoistClone.Application.Common.Interfaces.Persistence;
using TodoistClone.Domain.Entities;

namespace TodoistClone.Infrastructure.Persistence
{
    public class UserRepositoryInMemory : IUserRepository
    {
        private static List<User> _users = [];
        public void Add(User user)
        {
            _users.Add(user);
        }

        public User? GetUserByEmail(string email)
        {
            return _users.SingleOrDefault(x => x.Email == email);
        }
    }
}
