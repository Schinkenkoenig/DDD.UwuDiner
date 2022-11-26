using UwuDiner.Application.Common.Interfaces.Persistence;
using UwuDiner.Domain.Entities;

namespace UwuDiner.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{

  public static readonly List<User> UserDb = new();

  public void Add(User user)
  {
    UserDb.Add(user);
  }

  public User? GetUserByEmail(string email)
  {
    return UserDb.SingleOrDefault(u => u.Email == email);
  }
}
