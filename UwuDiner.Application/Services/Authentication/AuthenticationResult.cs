using UwuDiner.Domain.Entities;

namespace UwuDiner.Application.Services.Authentication;

public record AuthenticationResult(
  User User,
  string Token);
