using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using UwuDiner.Application.Interfaces.Authentication;
using Microsoft.IdentityModel.Tokens;
using UwuDiner.Application.Interfaces.Services;
using Microsoft.Extensions.Options;
using UwuDiner.Domain.Entities;

namespace UwuDiner.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{

  private readonly JwtSettings jwtSettings;
  private readonly IDateTimeProvider dateTimeProvider;

  public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtSettings)
  {
    this.dateTimeProvider = dateTimeProvider;
    this.jwtSettings = jwtSettings.Value;
  }
  public string GenerateToken(User user)
  {
    var signingCredentials = new SigningCredentials(
      new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(jwtSettings.Secret)),
        SecurityAlgorithms.HmacSha256);

    var claims = new[]
    {
      new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
      new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
      new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
      new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
    };

    var securityToken = new JwtSecurityToken(
      issuer: jwtSettings.Issuer,
      audience: jwtSettings.Audience,
      claims: claims,
      expires: dateTimeProvider.UtcNow.AddMinutes(jwtSettings.ExpiryMinutes),
      signingCredentials: signingCredentials);

    return new JwtSecurityTokenHandler().WriteToken(securityToken);
  }
}
