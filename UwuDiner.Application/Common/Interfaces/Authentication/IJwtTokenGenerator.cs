using UwuDiner.Domain.Entities;

namespace UwuDiner.Application.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
  string GenerateToken(User user);
}
