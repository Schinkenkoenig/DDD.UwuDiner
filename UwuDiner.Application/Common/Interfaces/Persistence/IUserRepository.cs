using UwuDiner.Domain.Entities;

namespace UwuDiner.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
  User? GetUserByEmail(string email);

  void Add(User user);
}
