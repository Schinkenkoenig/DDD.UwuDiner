using UwuDiner.Application.Common.Interfaces.Persistence;
using UwuDiner.Application.Interfaces.Authentication;
using UwuDiner.Domain.Entities;

namespace UwuDiner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
  private readonly IJwtTokenGenerator jwtTokenGenerator;

  private readonly IUserRepository userRepository;

  public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
  {
    this.jwtTokenGenerator = jwtTokenGenerator;
    this.userRepository = userRepository;
  }

  AuthenticationResult IAuthenticationService.Login(string email, string password)
  {
    // Get user first and throw when not exists
    if (this.userRepository.GetUserByEmail(email) is not User user)
    {
      throw new Exception("User does not exist");
    }

    if (user.Password != password)
    {
      throw new Exception("Password is invalid");
    }

    // Create JWT token
    var token = jwtTokenGenerator.GenerateToken(user);

    return new AuthenticationResult(user, token);
  }

  AuthenticationResult IAuthenticationService.Register(string firstName, string lastName, string email, string password)
  {
    // Check user exists
    if (userRepository.GetUserByEmail(email) is not null)
    {
      throw new Exception("User already exists");
    }

    // Create and persist user
    var user = new User
    {
      Id = Guid.NewGuid(),
      FirstName = firstName,
      LastName = lastName,
      Email = email,
      Password = password
    };

    userRepository.Add(user);

    // Create JWT token
    var token = jwtTokenGenerator.GenerateToken(user);

    return new AuthenticationResult(user, token);
  }
}
